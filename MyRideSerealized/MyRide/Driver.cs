using LocationLib;
using MyRide;
using System.Text.Json;
using VehicleLib;

namespace DriverLib
{
    public class Driver:Serealization
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




        public void DriverMenu(List<Driver> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No Driver In List");
                return;
            }

            Console.WriteLine("Enter Your Id: ");
            Console.ForegroundColor = ConsoleColor.Green;
            var id = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Enter your Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            var name = Console.ReadLine();
            Console.ResetColor();

            var driverFound = false;
            foreach (var driver in list)
            {
                if (driver.Name == name || driver.Id.ToString() == id)
                {
                    driverFound = true;
                    Console.WriteLine($"Hello {driver.Name}");
                    Console.WriteLine("Enter Your Current Location: ");
                    bool whilebreak = true;
                    while (whilebreak)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        try
                        {
                            var location = Console.ReadLine();
                            Console.ResetColor();
                            var locationArray = location.Split(',');
                            driver.CurrentLocation = new Location { Latitude = float.Parse(locationArray[0]), Longitude = float.Parse(locationArray[1]) };
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
                                        updateAvailability(driver);
                                        SerializeObjects(list);
                                        return;
                                    case 2:
                                        updateLocation(driver);
                                        SerializeObjects(list);
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
                    break;
                }
            }
            if (!driverFound)
            {
                Console.WriteLine("***Driver Not Found***");
                return;
            }

        }
        public void updateAvailability(Driver driver)
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
                            driver.Availability = true;
                            return;
                        case 2:
                            driver.Availability = false;
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

        public void updateLocation(Driver driver)
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
                                Console.ForegroundColor = ConsoleColor.Green;
                                try
                                {
                                    var location = Console.ReadLine();
                                    Console.ResetColor();
                                    var locationArray = location.Split(',');
                                    driver.CurrentLocation = new Location { Latitude = double.Parse(locationArray[0]), Longitude = double.Parse(locationArray[1]) };
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

        public void SerializeObjects(List<Driver> ObjectsList)
        {
            List<string> newList = new List<string>();
            foreach (Driver x in ObjectsList)
            {
                string serializedObject = JsonSerializer.Serialize(x);
                newList.Add(serializedObject);
            }
            WrtiteToFile("Admin_List.txt", newList);

        }
        public List<Driver> DeSerializedObjects()
        {
            List<string> newList = ReadFromFile("Admin_List.txt");
            List<Driver> newList2 = new List<Driver>();
            foreach (string x in newList)
            {
                Driver dto = JsonSerializer.Deserialize<Driver>(x);
                newList2.Add(dto);
            }
            return newList2;
        }
    }
}