using Microsoft.Data.SqlClient;

string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbPractice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

SqlConnection con=new SqlConnection(conString);

string query = "Select * from Drivers";
SqlCommand cmd = new SqlCommand(query,con);

con.Open();

SqlDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader[1]);
    Console.WriteLine(reader[2]);
}