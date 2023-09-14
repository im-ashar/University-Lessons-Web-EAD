using Microsoft.Data.SqlClient;

/////*READING DATA FROM DATABASE*/

//UPDATE DB_Practice SET username='Ashar', password = 'Bhatti123'
//INSERT INTO DB_Practice (UserName, Password) values('Talha', 'Riaz')
//UPDATE DB_Practice SET UserName='Pirogrammer', Password = 'asdasdsad123123213123' WHERE UserName='Talha'
//DELETE FROM DB_Practice WHERE Id='1002'


/////*READING DATA FROM DATABASE*/

//string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//SqlConnection con = new SqlConnection(conString);
//string query = "SELECT * FROM DB_Practice";
//SqlCommand cmd = new SqlCommand(query, con);
//con.Open();
//SqlDataReader dr = cmd.ExecuteReader();
//while (dr.Read())
//{
//    Console.WriteLine(dr[0]);
//    Console.WriteLine(dr[1]);
//    Console.WriteLine(dr[2]);
//}
//con.Close();


/////*UPDATING DATA IN DATABASE*/


//string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//SqlConnection con = new SqlConnection(conString);
//string query = @"UPDATE DB_Practice SET username='Talha',password='happy123' WHERE username='Pirogrammer'";
//SqlCommand cmd = new SqlCommand(query, con);
//con.Open();
//int count = cmd.ExecuteNonQuery();
//con.Close();


/////*INSERTING DATA IN DATABASE*/


//string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//SqlConnection con = new SqlConnection(conString);
//string query = @"INSERT INTO DB_Practice (username,password) values('kashif','hassan')";
//SqlCommand cmd = new SqlCommand(query, con);
//con.Open();
//int count = cmd.ExecuteNonQuery();
//con.Close();


/////*DELETING DATA IN DATABASE*/


//string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//SqlConnection con = new SqlConnection(conString);
//string query = @"DELETE FROM DB_Practice WHERE username='kashif'";
//SqlCommand cmd = new SqlCommand(query, con);
//con.Open();
//int count = cmd.ExecuteNonQuery();
//con.Close();


/////*USER AUTHENTICATION IN DATABASE*/

/////*SQL INJECTION EXIST*/

//string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//SqlConnection con = new SqlConnection(conString);
//Console.WriteLine("Enter UserName: ");
//string userName = Console.ReadLine();
//Console.WriteLine("Enter Password: ");
//string passWord = Console.ReadLine();
//string query = $"SELECT * FROM DB_Practice WHERE username='{userName}' and password='{passWord}'";
//SqlCommand cmd = new SqlCommand(query, con);
//con.Open();
//SqlDataReader dr = cmd.ExecuteReader();
//if (dr.HasRows)
//{
//    Console.WriteLine("User Authenticated");
//}
//else
//{
//    Console.WriteLine("Invalid Credentials");
//}
//con.Close();


/////*SQL INJECTION PREVENTION*/

//string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//SqlConnection con = new SqlConnection(conString);
//Console.WriteLine("Enter UserName: ");
//string userName = Console.ReadLine();
//Console.WriteLine("Enter Password: ");
//string passWord = Console.ReadLine();
//string query = $"SELECT * FROM DB_Practice WHERE username=@u and password=@p";
//SqlCommand cmd = new SqlCommand(query, con);

////USE THIS

//SqlParameter p1 = new SqlParameter("u",userName);
//SqlParameter p2 = new SqlParameter("p",passWord);
//cmd.Parameters.Add(p1);
//cmd.Parameters.Add(p2);

////OR USE THIS

////cmd.Parameters.AddWithValue("u", userName);
////cmd.Parameters.AddWithValue("p", passWord);

//con.Open();
//SqlDataReader dr = cmd.ExecuteReader();
//if (dr.HasRows)
//{
//    Console.WriteLine("User Authenticated");
//}
//else
//{
//    Console.WriteLine("Invalid Credentials");
//}
//con.Close();


//Count Find


//string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=POS_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//SqlConnection con = new SqlConnection(conString);
//string query = "SELECT Count(*) FROM Item";
//SqlCommand cmd = new SqlCommand(query, con);
//con.Open();
//var count = cmd.ExecuteScalar();
//Console.WriteLine(count);
//con.Close();



//string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=POS_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//SqlConnection con = new SqlConnection(conString);
//string query = $@"SELECT * FROM Item WHERE itemId={5}";
//SqlCommand cmd = new SqlCommand(query, con);
//con.Open();
//SqlDataReader dr = cmd.ExecuteReader();
//dr.Read();
//if (Convert.IsDBNull(dr))
//{
//    Console.WriteLine("No Item Is Avaiable In Stock");
//    con.Close();
//}



