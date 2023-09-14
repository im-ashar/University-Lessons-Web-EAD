using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using ConsoleTables;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ItemDAL
    {
        //static string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=POS_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string conString = @"server=containers-us-west-90.railway.app;port=6749;user=root;database=railway;password=J1DqfAPTyYHALDNzCCez;";
        MySqlConnection con = new MySqlConnection(conString);
        //Item ID Generation
        public int ItemIdGenerationDAL()
        {
            string query = @"SELECT Max(itemId) FROM Item";
            MySqlCommand cmd = new MySqlCommand(query, con);
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
        //Storing Items To DB
        public void ItemStoreToDbDAL(ItemDTO objItemDTO)
        {
            string query = $@"SET IDENTITY_INSERT Item ON INSERT INTO Item (itemId,description,price,quantity,creationDate) values({objItemDTO.ItemId},'{objItemDTO.ItemDescription}','{objItemDTO.ItemPrice}','{objItemDTO.ItemQuantity}','{objItemDTO.ItemCreationDate}') SET IDENTITY_INSERT Item OFF";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            int check = cmd.ExecuteNonQuery();
            if (check == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Item Has Been Stored Successfully***\n");
                Console.ResetColor();
            }
            con.Close();
        }
        //Modifying Existing Items
        public int ModifyItemDAL(int itemId)
        {
            string query = $@"SELECT * FROM Item WHERE itemId='{itemId}'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Item Has Been Found***\n");
                Console.ResetColor();
                while (dr.Read())
                {
                    Console.WriteLine("Item Id: " + dr[0]);
                    Console.WriteLine("Description: " + dr[1]);
                    Console.WriteLine("Price: " + dr[2]);
                    Console.WriteLine("Quantity: " + dr[3]);
                    Console.WriteLine("Creation Date: " + dr[4]);
                }
                con.Close();
                return 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***No Item Has Been Found***\n");
                Console.ResetColor();
                con.Close();
                return 0;
            }
        }
        //Sending Modified Item To DB
        public void ModifyItemToDbDAL(ItemDTO objItemDTO)
        {
            string query = $@"UPDATE Item
                            SET description= (CASE WHEN '{objItemDTO.ItemDescription}' IS NULL OR LTRIM('{objItemDTO.ItemDescription}') = '' THEN description ELSE '{objItemDTO.ItemDescription}' end),
                            price=(CASE WHEN '{objItemDTO.ItemPrice}' IS NULL OR LTRIM('{objItemDTO.ItemPrice}') = '' THEN price ELSE '{objItemDTO.ItemPrice}' end),
                            quantity=(CASE WHEN '{objItemDTO.ItemQuantity}' IS NULL OR LTRIM('{objItemDTO.ItemQuantity}') = '' THEN quantity ELSE '{objItemDTO.ItemQuantity}' end),
                            updateDate='{objItemDTO.ItemUpdateDate}'
                            WHERE itemId={objItemDTO.ItemId}";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            int check = cmd.ExecuteNonQuery();
            if (check == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Item Has Been Updated Successfully***\n");
                Console.ResetColor();
            }
            con.Close();
        }
        //Finding Items
        public void FindItemDAL(ItemDTO objItemDTO)
        {
            string query = $@"SELECT * FROM Item WHERE itemId='{objItemDTO.ItemId}' OR description='{objItemDTO.ItemDescription}' OR price='{objItemDTO.ItemPrice}' OR quantity='{objItemDTO.ItemQuantity}' OR creationDate='{objItemDTO.ItemCreationDate}'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            var table = new ConsoleTable("Item ID", "Description", "Price", "Quantity", "Creation Date");
            while (dr.Read())
            {
                table.AddRow(dr[0], dr[1], dr[2], dr[3], dr[4]);
            }
            table.Options.EnableCount = false;
            Console.ForegroundColor = ConsoleColor.Red;
            if (table.Rows.Count >= 1)
            {
                table.Write();
            }
            else
            {
                Console.WriteLine("***No Item Has Been Found***\n");
            }
            Console.ResetColor();
            con.Close();
        }
        //Removing Items
        public int RemoveItemDAL(int itemId)
        {
            int check = CheckSaleRecordedAgainstItemDAL(itemId);
            if (check != 0)
            {
                return -1;
            }
            else
            {
                string query = $@"SELECT * FROM Item WHERE itemId='{itemId}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
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
        //Checking If A Sale Exist Against A Item Provided For Deleting
        public int CheckSaleRecordedAgainstItemDAL(int itemId)
        {
            string query = $@"SELECT COUNT(itemId) FROM SaleLineItem WHERE itemId='{itemId}'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;
        }
        //Removing Items From DB
        public void RemoveItemFromDbDAL(int itemId)
        {
            string query = $@"DELETE FROM Item WHERE itemId='{itemId}'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            int check = cmd.ExecuteNonQuery();
            if (check == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Your Item Has Been Deleted***\n");
                Console.ResetColor();
            }
            con.Close();
        }
    }
}

