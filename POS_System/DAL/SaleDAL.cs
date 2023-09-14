using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class SaleDAL
    {
        //static string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=POS_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string conString = @"server=containers-us-west-90.railway.app;port=6749;user=root;database=railway;password=J1DqfAPTyYHALDNzCCez;";
        
        SqlConnection con = new SqlConnection(conString);
        //Generating Sale Id
        public int SaleIdGenerationDAL()
        {
            string query = @"SELECT Max(saleId) FROM Sale";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            if (Convert.IsDBNull(cmd.ExecuteScalar()))
            {
                con.Close();
                return 0;
            }
            else
            {
                int count = (Int32)cmd.ExecuteScalar();
                return count;
            }
        }
        //Getting Item Details For On Going Sale
        public ItemDTO GetItemForSaleFromDbDAL(int itemId)
        {
            string query = $@"SELECT * FROM Item WHERE itemId={itemId}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            ItemDTO objItemDTO = new ItemDTO();

            if (dr.HasRows)
            {
                objItemDTO.ItemDescription = (string)dr[1];
                objItemDTO.ItemPrice = (string)dr[2];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***No Item Is Avaiable In Stock***\n");
                Console.ResetColor();
                objItemDTO.ItemId = -1;
                con.Close();
            }
            return objItemDTO;
        }
        //Creating New Sale In DB
        public bool CreateNewSaleInDbDAL(SaleDTO objSaleDTO)
        {
            try
            {
                int? customerLimt = GetCustomerSaleLimitDAL(objSaleDTO);
                if (customerLimt == null)
                {
                    return false;
                }
                int saleLimt = CheckSaleLimitIncreaseDAL(objSaleDTO);
                if ((objSaleDTO.Total + saleLimt) > customerLimt)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Customer Maximum Limit For One Day Has Been Reached***\n");
                    Console.ResetColor();
                    return false;
                }
                else
                {
                    string query = $@"SET IDENTITY_INSERT Sale ON INSERT INTO Sale (saleId,customerId,date,status,amountPaid,amountLeft,totalAmount) values('{objSaleDTO.SaleId}','{objSaleDTO.CustomerId}','{objSaleDTO.SaleDate}','{objSaleDTO.SaleStatus}','0','0','0') SET IDENTITY_INSERT Sale OFF";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }

            }
            catch (SqlException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Customer Doesnt Exist***\n");
                Console.ResetColor();
                return false;
            }
        }
        //Getting Customer Sale Limit
        public int? GetCustomerSaleLimitDAL(SaleDTO objSaleDTO)
        {
            string query = $@"SELECT MAX(salesLimit) FROM Customer WHERE customerId = {objSaleDTO.CustomerId}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int customerLimit = 0;
            if (DBNull.Value == cmd.ExecuteScalar())
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("\n***Customer Doesnt Exist***\n");
                Console.ResetColor();
                con.Close();
                return null;
            }
            else
            {
                customerLimit = Convert.ToInt32(cmd.ExecuteScalar());
            }

            con.Close();
            return customerLimit;
        } 
        //Checking If Customer Has Increase Its Daily Limit Or Not
        public int CheckSaleLimitIncreaseDAL(SaleDTO objSaleDTO) 
        {
            string date = DateTime.Today.ToString("dd-MM-yyyy");
            string query = $@"SELECT SUM(amount) FROM SaleLineItem 
                            INNER JOIN Sale ON Sale.saleId=SaleLineItem.saleId
                            WHERE customerId={objSaleDTO.CustomerId} AND date='{date}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int saleLimit = 0;
            if (DBNull.Value == cmd.ExecuteScalar())
            {
                saleLimit = 0;
            }
            else  
            {
                saleLimit = Convert.ToInt32(cmd.ExecuteScalar());
            }
            con.Close();
            return saleLimit;
        }
        //Ending Sale
        public void EndSaleDAL(List<SaleDTO> CurrentSaleItemsIds)
        {
            try
            {
                int saleId = 0;
                foreach (SaleDTO x in CurrentSaleItemsIds)
                {
                    string query = $@"INSERT INTO SaleLineItem (saleId,itemId,quantity,amount) values('{x.SaleId}','{x.ItemId}','{x.ItemQuantity}','{x.Total}')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    saleId = x.SaleId;
                }
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("\n***Sale Store To DB***\n");
                Console.ResetColor();
                string query2 = $@"SELECT Customer.name,Customer.customerId,Sale.saleId, Sale.date,Item.description,Item.price,SaleLineItem.itemId,SaleLineItem.quantity,SaleLineItem.amount
                                   FROM Customer
                                   INNER JOIN Sale ON Customer.customerId=Sale.customerId
                                   INNER JOIN SaleLineItem ON Sale.saleId=SaleLineItem.saleId
                                   INNER JOIN Item ON Item.itemId=SaleLineItem.itemId
                                   WHERE Sale.saleId={saleId}";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                con.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                string name = string.Empty, date = string.Empty;
                int customerId = 0, saleId2 = 0, totalSum = 0;
                var table = new ConsoleTable("Item ID", "Description", "Quantity", "Amount");
                while (dr.Read())
                {
                    name = (string)dr[0];
                    customerId = (int)dr[1];
                    saleId2 = (int)dr[2];
                    date = (string)dr[3];
                    table.AddRow(dr[6], dr[4], dr[7], dr[8]);
                    totalSum = totalSum + Convert.ToInt32(dr[8]);
                }
                Console.WriteLine($"\nSale Id: {saleId2} \t\t\tCustomer Id: {customerId}");
                Console.WriteLine($"Sale Date: {date} \t\tName: {name}");
                table.Options.EnableCount = false;
                Console.ForegroundColor= ConsoleColor.Red;
                table.Write();
                Console.WriteLine($"\t\t\t\tTotal: {totalSum}");
                Console.ResetColor();
                con.Close();
                SetTotalAmountOfSaleDAL(saleId2, totalSum);
                SetPayableAmountOfCustomerAfterSaleDAL(totalSum, customerId);
            }
            catch (SqlException)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("\n***Sale Id OR ItemId Doesnt Exist***\n");
                Console.ResetColor();
            }
        }
        //Updaing Customers Payable Amount After Sale
        public void SetPayableAmountOfCustomerAfterSaleDAL(int totalSum, int customerId)
        {
            con.Open();
            string query2 = $@"SELECT MAX(amountPayable) FROM Customer WHERE customerId={customerId}";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            totalSum = Convert.ToInt32(cmd2.ExecuteScalar()) + totalSum;
            string query = $@"UPDATE Customer SET amountPayable='{totalSum}' WHERE customerId={customerId}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Setting Total Amount Of Sale
        public void SetTotalAmountOfSaleDAL(int saleId, int totalSum)
        {
            con.Open();
            string query = $@"UPDATE Sale SET totalAmount='{totalSum}' WHERE saleId={saleId}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Making Payment
        public void MakePaymentDAL(int saleId)
        {
            string query = $@"SELECT Sale.saleId,Customer.name,Sale.amountPaid,Sale.amountLeft,Customer.customerId,Sale.totalAmount FROM Sale
                              INNER JOIN Customer ON Customer.customerId=Sale.customerId
                              WHERE saleId={saleId}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int customerId = 0, amountPaying = 0, remainigAmount = 0, amountPaid = 0;
            if (!dr.HasRows)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("\n***No Sale Is Available Against This Id***\n");
                Console.ResetColor();
                return;
            }
            while (dr.Read())
            {
                Console.WriteLine($"Sale Id: {dr[0]}");
                Console.WriteLine($"Customer Name: {dr[1]}");
                Console.WriteLine($"Total Sale Amount: {dr[5]}");
                amountPaid = Convert.ToInt32(dr[2]);
                Console.WriteLine($"Amount Paid: {amountPaid}");
                remainigAmount = Convert.ToInt32(dr[5]) - Convert.ToInt32(dr[2]);
                customerId = Convert.ToInt32(dr[4]);
                Console.WriteLine($"Remaining Amount: {remainigAmount}");
            }
            Console.Write("Amount To Be Paid: ");
            amountPaying = int.Parse(Console.ReadLine());
            remainigAmount = remainigAmount - amountPaying;
            if(remainigAmount<0)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("\n***You Have Given More Amount Than Sale***.\n***Extra Amount Has Been Deposited In Your Account***");
                Console.ResetColor();
            }
            amountPaid = amountPaying + amountPaid;
            con.Close();
            UpdateCustomerAfterPaymentDAL(customerId, amountPaid);
            MakeReceiptDAL(saleId, amountPaid);
            UpdateSaleAfterPaymentDAL(saleId, amountPaid, remainigAmount);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n***Payment Successful***");
            Console.ResetColor();
        }
        //Updating Customer's Payable Amount After Payment
        public void UpdateCustomerAfterPaymentDAL(int customerId, int amounPaid)
        {
            con.Open();
            string query2 = $@"SELECT MAX(amountPayable) FROM Customer WHERE customerId={customerId}";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            amounPaid = Convert.ToInt32(cmd2.ExecuteScalar()) - amounPaid;
            string query = $@"UPDATE Customer SET amountPayable='{amounPaid}' WHERE customerId={customerId}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Making Receipt In DB
        public void MakeReceiptDAL(int saleId, int amountPaid)
        {
            string date = DateTime.Today.ToString("dd-MM-yyyy");
            string query = $@"INSERT INTO Receipt (receiptDate,saleId,amount) values('{date}','{saleId}','{amountPaid}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Updating Sale After Payment
        public void UpdateSaleAfterPaymentDAL(int saleId, int amountPaid, int remainigAmount)
        {
            con.Open();
            string query = $@"UPDATE SALE SET amountPaid='{amountPaid}',amountLeft='{remainigAmount}' WHERE saleId={saleId}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}


