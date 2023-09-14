using LocationLib;
using Microsoft.Data.SqlClient;
using VehicleLib;

namespace DriverLib
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Location CurrentLocation { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<float> Rating { get; set; }
        public bool Availability { get; set; }


        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyRide;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        public void DriverMenu()
        {

            Console.WriteLine("Enter Your Id: ");
            Console.ForegroundColor = ConsoleColor.Green;
            var id = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter your Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            var name = Console.ReadLine();
            Console.ResetColor();

            SqlConnection con = new SqlConnection(conString);
            string query = @$"SELECT * FROM Driver WHERE Id='{id}' AND Name='{name}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            var driver = cmd.ExecuteReader();

            var driverFound = false;

            if (driver.HasRows)
            {
                con.Close();
                driverFound = true;
                Console.WriteLine($"Hello {name}");
                Console.WriteLine("Enter Your Current Location: ");
                bool whilebreak = true;
                while (whilebreak)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    try
                    {
                        Console.ResetColor();
                        Console.WriteLine("Longitude: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        var longitude = Console.ReadLine();
                        Console.ResetColor();

                        Console.WriteLine("Latitude : ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        var latitude = Console.ReadLine();
                        Console.ResetColor();

                        query = "UPDATE Location SET Latitude=@latitude,Longitude=@longitude WHERE DriverId=@driverId";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@longitude", longitude);
                        cmd.Parameters.AddWithValue("@latitude", latitude);
                        cmd.Parameters.AddWithValue("@driverId", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        whilebreak = false;
                    }
                    catch
                    {
                        Console.WriteLine("***Wrong Input Try Again***");
                    }
                }
                Console.WriteLine("1. Change Availability\n2. Change Location\n3. Exit as Driver");
                bool found = true;
                while (found)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (int.TryParse(Console.ReadLine(), out int result))
                    {
                        Console.ResetColor();
                        if (result < 1 || result > 3)
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
                                    updateAvailability(id);
                                    return;
                                case 2:
                                    updateLocation(id);
                                    return;
                                case 3:
                                    return;
                            }

                            found = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("***Wrong Input***");
                        Console.WriteLine("***Select Again: ");
                    }
                }
            }

            if (!driverFound)
            {
                Console.WriteLine("***Driver Not Found***");
                con.Close();
                return;
            }

        }
        public void updateAvailability(string id)
        {
            bool option = true;
            int result = 0;
            Console.WriteLine("Do You Want To Update Your Availability?\n");
            Console.WriteLine("1 - On\n ");
            Console.WriteLine("2 - Off\n ");
            Console.WriteLine("3 - Back\n ");
            while (option)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    Console.ResetColor();
                    if (result < 1 || result > 3)
                    {
                        Console.WriteLine("***Wrong Input Try Again***");
                        continue;
                    }
                    switch (result)
                    {
                        case 1:
                            SqlConnection con = new SqlConnection(conString);
                            string query = "UPDATE Driver SET Availability=@availability WHERE Id=@id";
                            var cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@availability", "true");
                            cmd.Parameters.AddWithValue("@id", id);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Console.WriteLine("Availability Turned On");
                            return;
                        case 2:
                            SqlConnection con2 = new SqlConnection(conString);
                            string query2 = "UPDATE Driver SET Availability=@availability WHERE Id=@id";
                            var cmd2 = new SqlCommand(query2, con2);
                            cmd2.Parameters.AddWithValue("@availability", "false");
                            cmd2.Parameters.AddWithValue("@id", id);
                            con2.Open();
                            cmd2.ExecuteNonQuery();
                            con2.Close();
                            Console.WriteLine("Availability Turned Off");
                            return;
                        case 3:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("***Wrong Input Try Again***");
                    continue;
                }

            }

        }

        public void updateLocation(string id)
        {
            bool option = true;
            int result = 0;
            Console.WriteLine("1. Update Location?\n");
            Console.WriteLine("2. Back");

            while (option)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    Console.ResetColor();
                    if (result < 1 || result > 2)
                    {
                        Console.WriteLine("***Wrong Input Try Again***");
                        continue;
                    }
                    switch (result)
                    {
                        case 1:
                            Console.WriteLine("Enter Your Updated Location: ");
                            bool whilebreak = true;
                            while (whilebreak)
                            {
                                try
                                {
                                    Console.WriteLine("Longitude: ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    var longitude = Console.ReadLine();
                                    Console.ResetColor();

                                    Console.WriteLine("Latitude : ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    var latitude = Console.ReadLine();
                                    Console.ResetColor();

                                    SqlConnection con = new SqlConnection(conString);
                                    string query = "UPDATE Location SET Latitude=@latitude,Longitude=@longitude WHERE DriverId=@driverId";
                                    SqlCommand cmd = new SqlCommand(query, con);
                                    cmd.Parameters.AddWithValue("@longitude", longitude);
                                    cmd.Parameters.AddWithValue("@latitude", latitude);
                                    cmd.Parameters.AddWithValue("@driverId", id);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    Console.WriteLine("Location Updated");
                                    whilebreak = false;
                                }
                                catch
                                {
                                    Console.WriteLine("***Wrong Input Try Again***");
                                }
                            }
                            return;
                        case 2:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("***Wrong Input Try Again***");
                    continue;
                }

            }
        }

        public double GetRating()
        {
            if (Rating.Count == 0)
            {
                Console.WriteLine("No Order Yet");
                return 0.0;
            }
            double avg = 0.0;
            foreach (var rate in Rating)
            {
                avg = avg + rate;
            }
            return avg / Rating.Count;
        }
    }
}