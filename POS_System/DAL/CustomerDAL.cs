using ConsoleTables;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL
    {
        //static string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=POS_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string conString = @"mysql://root:J1DqfAPTyYHALDNzCCez@containers-us-west-90.railway.app:6749/railway";
        SqlConnection con = new SqlConnection(conString);
        //Generating Id For Customer
        public int CustomerIdGenerationDAL()
        {
            string query = @"SELECT Max(customerId) FROM Customer";
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
        //Storing Customers To Db
        public void CustomerStoreToDbDAL(CustomerDTO objCustomerDTO)
        {
            string query = $@"SET IDENTITY_INSERT Customer ON INSERT INTO Customer (customerId,name,address,phone,email,amountPayable,salesLimit,registrationDate) values({objCustomerDTO.CustomerId},'{objCustomerDTO.CustomerName}','{objCustomerDTO.CustomerAddress}','{objCustomerDTO.CustomerPhone}','{objCustomerDTO.CustomerEmail}','{objCustomerDTO.CustomerAmountPayable}','{objCustomerDTO.CustomerSalesLimit}','{objCustomerDTO.CustomerRegistrationDate}') SET IDENTITY_INSERT Customer OFF";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int check = cmd.ExecuteNonQuery();
            if (check == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Customer Has Been Stored Successfully***\n");
                Console.ResetColor();
            }
            con.Close();
        }
        //Modifying Customers
        public int ModifyCustomerDAL(int customerId)
        {
            string query = $@"SELECT * FROM Customer WHERE customerId='{customerId}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Customer Has Been Found***\n");
                Console.ResetColor();
                while (dr.Read())
                {
                    Console.WriteLine("Customer Id: " + dr[0]);
                    Console.WriteLine("Name: " + dr[1]);
                    Console.WriteLine("Address: " + dr[2]);
                    Console.WriteLine("Phone: " + dr[3]);
                    Console.WriteLine("Email: " + dr[4]);
                    Console.WriteLine("Amount Payable: " + dr[5]);
                    Console.WriteLine("Sales Limit: " + dr[6]);
                    Console.WriteLine("Registration Date: " + dr[7]);
                }
                con.Close();
                return 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***No Customer Has Been Found***\n");
                Console.ResetColor();
                con.Close();
                return 0;
            }
        }
        //Storing Modified Customer To DB
        public void ModifyCustomerToDbDAL(CustomerDTO objCustomerDTO)
        {
            string query = $@"UPDATE Customer 
                            SET name= (CASE WHEN '{objCustomerDTO.CustomerName}' IS NULL OR LTRIM('{objCustomerDTO.CustomerName}') = '' THEN name ELSE '{objCustomerDTO.CustomerName}' end),
                            address=(CASE WHEN '{objCustomerDTO.CustomerAddress}' IS NULL OR LTRIM('{objCustomerDTO.CustomerAddress}') = '' THEN address ELSE '{objCustomerDTO.CustomerAddress}' end),
                            phone=(CASE WHEN '{objCustomerDTO.CustomerPhone}' IS NULL OR LTRIM('{objCustomerDTO.CustomerPhone}') = '' THEN phone ELSE '{objCustomerDTO.CustomerPhone}' end),
                            email=(CASE WHEN '{objCustomerDTO.CustomerEmail}' IS NULL OR LTRIM('{objCustomerDTO.CustomerEmail}') = '' THEN email ELSE '{objCustomerDTO.CustomerEmail}' end),
                            amountPayable=(CASE WHEN '{objCustomerDTO.CustomerAmountPayable}' IS NULL OR LTRIM('{objCustomerDTO.CustomerAmountPayable}') = '' THEN amountPayable ELSE '{objCustomerDTO.CustomerAmountPayable}' end),
                            salesLimit=(CASE WHEN '{objCustomerDTO.CustomerSalesLimit}' IS NULL OR LTRIM('{objCustomerDTO.CustomerSalesLimit}') = '' THEN salesLimit ELSE '{objCustomerDTO.CustomerSalesLimit}' end)
                            WHERE customerId={objCustomerDTO.CustomerId}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int check = cmd.ExecuteNonQuery();
            if (check == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Customer Has Been Updated Successfully***\n");
                Console.ResetColor();
            }
            con.Close();
        }
        //Finding Customer
        public void FindCustomerDAL(CustomerDTO objCustomerDTO)
        {
            string query = $@"SELECT * FROM Customer WHERE customerId='{objCustomerDTO.CustomerId}' OR name='{objCustomerDTO.CustomerName}' OR address='{objCustomerDTO.CustomerAddress}' OR phone='{objCustomerDTO.CustomerPhone}' OR email='{objCustomerDTO.CustomerEmail}' OR amountPayable='{objCustomerDTO.CustomerAmountPayable}' OR salesLimit='{objCustomerDTO.CustomerSalesLimit}' OR registrationDate='{objCustomerDTO.CustomerRegistrationDate}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            var table = new ConsoleTable("Customer ID", "Name", "Address", "Phone", "Email", "Amount Payable", "Sales Limit", "Registration Date");
            while (dr.Read())
            {
                table.AddRow(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
            }
            table.Options.EnableCount = false;
            Console.ForegroundColor = ConsoleColor.Red;
            if (table.Rows.Count >= 1)
            {
                table.Write();
            }
            else
            {
                Console.WriteLine("\n***No Customer Has Been Found***");
            }
            Console.ResetColor();
            con.Close();
        }
        //Removing Customer
        public int RemoveCustomerDAL(int customerId)
        {
            int check = CheckIfCustomerAssociatedWithSaleDAL(customerId);
            if (check != 0)
            {
                return -1;
            }
            else
            {
                string query = $@"SELECT * FROM Customer WHERE customerId='{customerId}'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();
                    return 1;
                }
                else
                {
                    con.Close();
                    return 0;
                }
            }

        }
        //Checking If A Customer Is Associated With Sale Or Not
        public int CheckIfCustomerAssociatedWithSaleDAL(int customerId)
        {
            string query = $@"SELECT COUNT(saleId) FROM Sale WHERE customerId='{customerId}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;
        }
        //Removing Customer From DB
        public void RemoveCustomerFromDbDAL(int customerId)
        {
            string query = $@"DELETE FROM Customer WHERE customerId='{customerId}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int check = cmd.ExecuteNonQuery();
            if (check == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Your Customer Has Been Deleted***\n");
                Console.ResetColor();
            }
            con.Close();
        }
    }
}

