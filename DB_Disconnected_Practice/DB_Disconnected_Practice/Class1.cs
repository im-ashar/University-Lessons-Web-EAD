using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;////for datatable
namespace DB_Disconnected_Practice
{
    public class Class1
    {
        static public void Main()
        {

            //            /*------------SELECT---------------*/

            //string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlConnection con = new SqlConnection(conString);
            //string selectQuery = @"SELECT * FROM DB_Practice";
            //SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = selectCommand;
            //DataTable tablePractice = new DataTable();
            //da.Fill(tablePractice);
            //foreach (DataRow x in tablePractice.Rows)
            //{
            //    Console.WriteLine(x[0]);
            //    Console.WriteLine(x[1]);
            //}

            /*********************************************************************************************************************************************/

            //           /*------------INSERT---------------*/

            //            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //            SqlConnection con = new SqlConnection(conString);
            //            SqlDataAdapter da = new SqlDataAdapter();
            //            DataTable tablePractice = new DataTable();

            //            string selectQuery = @"SELECT * FROM DB_Practice";
            //            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            //            da.SelectCommand = selectCommand;
            //            da.Fill(tablePractice);

            //            string insertQuery = "INSERT INTO DB_Practice (UserName,Password) values(@u,@p)";
            //            SqlCommand insertCommand = new SqlCommand(insertQuery, con);
            //            da.InsertCommand = insertCommand;
            //            insertCommand.Parameters.Add("u", SqlDbType.VarChar, 50, "UserName");
            //            insertCommand.Parameters.Add("p", SqlDbType.VarChar, 50, "Password");

            //            DataRow newUser = tablePractice.NewRow();
            //            newUser["UserName"] = "Shani";
            //            newUser["Password"] = "123456";

            //            tablePractice.Rows.Add(newUser);
            //            da.Update(tablePractice);


            /*********************************************************************************************************************************************/

            //            /*------------UPDATE---------------*/

            //            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //            SqlConnection con = new SqlConnection(conString);
            //            SqlDataAdapter da = new SqlDataAdapter();
            //            DataTable tablePractice = new DataTable();

            //            string selectQuery = @"SELECT * FROM DB_Practice";
            //            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            //            da.SelectCommand = selectCommand;
            //            da.Fill(tablePractice);

            //            string updateQuery = @"UPDATE DB_Practice SET Password=@p WHERE UserName=@u";
            //            SqlCommand updateCommand = new SqlCommand(updateQuery, con);
            //            da.UpdateCommand = updateCommand;

            //            updateCommand.Parameters.Add("u", SqlDbType.VarChar, 50, "UserName");
            //            updateCommand.Parameters.Add("p", SqlDbType.VarChar, 50, "Password");

            //            tablePractice.Rows[0]["UserName"] = "Talha";
            //            tablePractice.Rows[0]["Password"] = "newpass1234";

            //            da.Update(tablePractice);

            /*********************************************************************************************************************************************/

            //            /*------------DELETE---------------*/

            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tablePractice = new DataTable();

            string selectQuery = @"SELECT * FROM DB_Practice";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            da.SelectCommand = selectCommand;
            da.Fill(tablePractice);

            tablePractice.PrimaryKey = new DataColumn[] { tablePractice.Columns["Id"] };

            string deleteQuery = @"DELETE FROM DB_Practice WHERE UserName=@u";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, con);
            da.DeleteCommand = deleteCommand;

            deleteCommand.Parameters.Add("u", SqlDbType.VarChar, 50, "UserName");

            /*Removing Data From In Memory Table And Updating DB*/

            for (int i = 0; i < tablePractice.Rows.Count; i++)
            {
                if (tablePractice.Rows[i]["UserName"].ToString() == "Ashar")
                {
                    tablePractice.Rows.Find(tablePractice.Rows[i]["Id"]).Delete();
                }
            }

            da.ContinueUpdateOnError= true;
            da.Update(tablePractice);
            tablePractice.AcceptChanges();
            foreach (DataRow dataRow in tablePractice.Rows)
            {
                Console.WriteLine(dataRow["UserName"].ToString());
            }

            /*Removing Data From DB Talha*/
            //foreach (DataRow row in tablePractice.Rows)
            //{
            //    if (row["UserName"].ToString() == "Ashar")   //u ki value set hoo jay gi or query mai chali jay gi or phir query us base pr sb data delete krday gi
            //    {
            //        row.Delete();
            //        break;
            //    }
            //}


        }
    }
}
