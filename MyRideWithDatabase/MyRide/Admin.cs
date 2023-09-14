using ConsoleTables;
using DriverLib;
using LocationLib;
using Microsoft.Data.SqlClient;
using VehicleLib;

namespace AdminLib
{
    public class Admin
    {
        private static List<Driver> listOfDrivers = new List<Driver>();
        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyRide;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void AdminMenu()
        {
            Console.WriteLine("1. Add Driver\n2. Remove Driver\n3. Update Driver\n4. Search Driver\n5. Exit as Admin");

            bool found = true;
            while (found)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    Console.ResetColor();
                    if (result < 1 || result > 5)
                    {
                        Console.WriteLine("***Wrong Input***");
                        Console.WriteLine("***Select Again: ");
                        continue;
                    }
                    else
                    {
                        switch (result)
                        {
                            case 1:
                                AddDriver();
                                break;
                            case 2:
                                RemoveDriver();
                                break;
                            case 3:
                                UpdateDriver();
                                break;
                            case 4:
                                SearchDriver();
                                break;
                            case 5:
                                break;
                        }

                        found = false;
                    }
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine("***Wrong Input***");
                    Console.WriteLine("***Select Again: ");
                }
            }

        }
        public void AddDriver()
        {
            bool found = true;
            object age = 0;
            var driverId = Guid.NewGuid();
            Console.WriteLine($"Id: {driverId}");

            Console.WriteLine("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ResetColor();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("**Name Cannot Be Empty***");
                Console.WriteLine("**Enter Again***");
                Console.ForegroundColor = ConsoleColor.Green;
                name = Console.ReadLine();
                Console.ResetColor();
            }

            Console.WriteLine("Enter Age: ");
            while (found)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                age = Console.ReadLine();
                Console.ResetColor();
                if (string.IsNullOrEmpty(age.ToString()))
                {
                    Console.WriteLine("Age Cannot Be Empty");
                    Console.WriteLine("**Enter Again***");
                    continue;
                }
                if (int.TryParse(age.ToString(), out int result))
                {

                    age = result;
                    found = false;
                }
                else
                {
                    Console.WriteLine("***Age Should Be a Number***");
                    Console.WriteLine("***Enter Again: ");
                }
            }

            Console.WriteLine("Enter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string gender = Console.ReadLine();
            Console.ResetColor();
            while (string.IsNullOrEmpty(gender))
            {
                Console.WriteLine("**Gender Cannot Be Empty***");
                Console.WriteLine("**Enter Again***");
                Console.ForegroundColor = ConsoleColor.Green;
                gender = Console.ReadLine();
                Console.ResetColor();
            }

            Console.WriteLine("Enter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string address = Console.ReadLine();
            Console.ResetColor();
            while (string.IsNullOrEmpty(address))
            {
                Console.WriteLine("**Address Cannot Be Empty***");
                Console.WriteLine("**Enter Again***");
                Console.ForegroundColor = ConsoleColor.Green;
                address = Console.ReadLine();
                Console.ResetColor();
            }

            Console.WriteLine("Enter Phone Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string phoneNumber = Console.ReadLine();
            Console.ResetColor();
            while (string.IsNullOrEmpty(phoneNumber))
            {
                Console.WriteLine("**Phone Number Cannot Be Empty***");
                Console.WriteLine("**Enter Again***");
                Console.ForegroundColor = ConsoleColor.Green;
                phoneNumber = Console.ReadLine();
                Console.ResetColor();
            }

            SqlConnection con = new SqlConnection(conString);
            string query = "INSERT INTO Driver (Id,Name,Age,Gender,Address,PhoneNumber,Availability) values(@driverId,@name,@age,@gender,@address,@phoneNumber,@availability)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@driverId", driverId);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@availability", "true");
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();

            
            if (count > 0)
            {
                con = new SqlConnection(conString);
                query = "INSERT INTO Location (Longitude,Latitude,DriverId) values(@longitude,@latitude,@driverId)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@longitude", 0);
                cmd.Parameters.AddWithValue("@latitude", 0);
                cmd.Parameters.AddWithValue("@driverId", driverId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("***Driver Added Successfully***");
                Console.WriteLine("Enter Vehicle Type: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string vehicleType = Console.ReadLine();
                Console.ResetColor();
                while (string.IsNullOrEmpty(vehicleType))
                {
                    Console.WriteLine("**Vehicle Type Cannot Be Empty***");
                    Console.WriteLine("**Enter Again***");
                    Console.ForegroundColor = ConsoleColor.Green;
                    vehicleType = Console.ReadLine();
                    Console.ResetColor();
                }
                Console.WriteLine("Enter Vehicle Model: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string vehicleModel = Console.ReadLine();
                Console.ResetColor();
                while (string.IsNullOrEmpty(vehicleModel))
                {
                    Console.WriteLine("**Vehicle Model Cannot Be Empty***");
                    Console.WriteLine("**Enter Again***");
                    Console.ForegroundColor = ConsoleColor.Green;
                    vehicleModel = Console.ReadLine();
                    Console.ResetColor();
                }
                Console.WriteLine("Enter License Plate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string vehicleLicensePlate = Console.ReadLine();
                Console.ResetColor();
                while (string.IsNullOrEmpty(vehicleLicensePlate))
                {
                    Console.WriteLine("***Vehicle License Plate Cannot Be Empty***");
                    Console.WriteLine("**Enter Again***");
                    Console.ForegroundColor = ConsoleColor.Green;
                    vehicleLicensePlate = Console.ReadLine();
                    Console.ResetColor();
                }
                query = "INSERT INTO Vehicle (Type,Model,LicensePlate,DriverId) values(@type,@model,@licenseplate,@driverid)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@type", vehicleType);
                cmd.Parameters.AddWithValue("@model", vehicleModel);
                cmd.Parameters.AddWithValue("@licenseplate", vehicleLicensePlate);
                cmd.Parameters.AddWithValue("@driverid", driverId);
                con.Open();
                count = cmd.ExecuteNonQuery();
                con.Close();
                if (count > 0)
                {
                    Console.WriteLine("Your Vehicle Has Been Registered");
                }
                else
                {
                    Console.WriteLine("Your Vehicle Cannot Be Registered");
                }
            }
            else
            {
                Console.WriteLine("***Driver Cannot Be Added***");
            }

        }
        public void RemoveDriver()
        {
            Console.WriteLine("Enter Id of the Driver to Remove: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string id = Console.ReadLine();
            Console.ResetColor();

            SqlConnection con = new SqlConnection(conString);
            string query = $"Select * from Driver where Id='{id}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            var dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                con.Close();


                query = $"Delete from Vehicle where driverId='{id}'";
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
                query = $"Delete from Location where driverId='{id}'";
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
                query = $"Delete from Rating where driverId='{id}'";
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                query = $"Delete from Driver where Id='{id}'";
                cmd = new SqlCommand(query, con);
                con.Open();
                var count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    Console.WriteLine("***Driver Deleted Successfully***");
                    con.Close();
                    return;
                }
            }
            con.Close();
            Console.WriteLine("***Driver Not Found***");
        }
        public void UpdateDriver()
        {
            Console.WriteLine("Enter Id of the Driver to Update: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string id = Console.ReadLine();
            Console.ResetColor();

            SqlConnection con = new SqlConnection(conString);
            string query = $"Select * from Driver where Id='{id}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            var dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Console.WriteLine($"Driver Exist With Id ***{id}***");
                con.Close();

                bool found = true;
                Console.WriteLine("Enter Name: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string name = Console.ReadLine();
                Console.ResetColor();

                Console.WriteLine("Enter Age: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string age = Console.ReadLine();
                Console.ResetColor();
                if (!string.IsNullOrEmpty(age))
                {
                    while (found)
                    {
                        if (int.TryParse(age, out int result))
                        {
                            found = false;
                        }
                        else
                        {
                            Console.WriteLine("***Wrong Input***");
                            Console.WriteLine("***Select Again: ");
                        }
                    }
                }


                Console.WriteLine("Enter Gender: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string gender = Console.ReadLine();
                Console.ResetColor();


                Console.WriteLine("Enter Address: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string address = Console.ReadLine();
                Console.ResetColor();

                Console.WriteLine("Enter Phone Number: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string phoneNumber = Console.ReadLine();
                Console.ResetColor();


                Console.WriteLine("Enter Vehicle Type: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string vehicleType = Console.ReadLine();
                Console.ResetColor();


                Console.WriteLine("Enter Vehicle Model: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string vehicleModel = Console.ReadLine();
                Console.ResetColor();


                Console.WriteLine("Enter License Plate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string vehicleLicensePlate = Console.ReadLine();
                Console.ResetColor();

                query = @"UPDATE Driver 
                     SET Name = COALESCE(@name, Name),
                         Age = COALESCE(@age, Age),
                         Gender = COALESCE(@gender, Gender),
                         Address = COALESCE(@address, Address),
                         PhoneNumber = COALESCE(@phoneNumber, PhoneNumber)
                     WHERE Id = @id";


                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", string.IsNullOrEmpty(name) ? (object)DBNull.Value : name);
                cmd.Parameters.AddWithValue("@age", string.IsNullOrEmpty(age) ? (object)DBNull.Value : age);
                cmd.Parameters.AddWithValue("@gender", string.IsNullOrEmpty(gender) ? (object)DBNull.Value : gender);
                cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);
                cmd.Parameters.AddWithValue("@phoneNumber", string.IsNullOrEmpty(phoneNumber) ? (object)DBNull.Value : phoneNumber);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                query = @"UPDATE Vehicle 
                     SET Type = COALESCE(@type, Type),
                         Model = COALESCE(@model, Model),
                         LicensePlate = COALESCE(@licensePlate, LicensePlate)
                     WHERE DriverId = @id";


                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@type", string.IsNullOrEmpty(vehicleType) ? (object)DBNull.Value : vehicleType);
                cmd.Parameters.AddWithValue("@model", string.IsNullOrEmpty(vehicleModel) ? (object)DBNull.Value : vehicleModel);
                cmd.Parameters.AddWithValue("@licensePlate", string.IsNullOrEmpty(vehicleLicensePlate) ? (object)DBNull.Value : vehicleLicensePlate);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                var count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    Console.WriteLine("Driver Updated Successfully");
                    con.Close();
                    return;
                }
            }
            Console.WriteLine("***Driver Not Found***");
        }
        public void SearchDriver()
        {
            bool found = true;

            Console.WriteLine("Enter Driver Id: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string id = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string age = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string gender = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string address = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter Phone Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string phoneNumber = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter Vehicle Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string vehicleType = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter Vehicle Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string vehicleModel = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter License Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string vehicleLicensePlate = Console.ReadLine();
            Console.ResetColor();

            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(age) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(address) && string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(vehicleType) && string.IsNullOrEmpty(vehicleModel) && string.IsNullOrEmpty(vehicleLicensePlate))
            {
                return;
            }

            string query = $@"SELECT Driver.Id,Driver.Name,Driver.Age,Driver.Gender,Driver.Address,Driver.PhoneNumber,Vehicle.Type,Vehicle.Model,Vehicle.LicensePlate
                            FROM Driver
                            INNER JOIN Vehicle ON Driver.Id = Vehicle.DriverId
                            WHERE Driver.Id='{id}' OR Driver.Name = '{name}' OR Driver.Age='{age}' OR Driver.Gender='{gender}' OR Driver.Address='{address}' OR Driver.PhoneNumber='{phoneNumber}' OR Vehicle.Type = '{vehicleType}' OR Vehicle.Model='{vehicleModel}' OR Vehicle.LicensePlate='{vehicleLicensePlate}';";
            SqlConnection con = new SqlConnection(conString);
            var cmd = new SqlCommand(query, con);
            con.Open();
            var dr = cmd.ExecuteReader();
            var table = new ConsoleTable("Id", "Name", "Age", "Gender", "Address", "Phone Number", "Vehicle Type", "Vehicle Model", "Vehicle License");
            while (dr.Read())
            {
                table.AddRow(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8]);
            }
            table.Options.EnableCount = false;
            if (table.Rows.Count > 0)
            {
                table.Write();
            }
            else
            {
                Console.WriteLine("\n***No Driver Has Been Found***");
            }
            con.Close();
        }

        public List<Driver> ListOfDrivers()
        {
            return listOfDrivers;
        }
    }
}