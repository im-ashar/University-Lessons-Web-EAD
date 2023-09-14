using ConsoleTables;
using DriverLib;
using LocationLib;
using VehicleLib;

namespace AdminLib
{
    public class Admin
    {
        private static List<Driver> listOfDrivers = new List<Driver>();

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
            var id = Guid.NewGuid();
            Console.WriteLine($"Id: {id}");

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

            var driver = new Driver { Id = id, Name = name, Age = Convert.ToInt32(age), Gender = gender, Address = address, Availability = true, CurrentLocation = new Location { Latitude = 0.0F, Longitude = 0.0F }, PhoneNumber = "03001234567", Rating = new List<float>(), Vehicle = new Vehicle { Type = vehicleType, Model = vehicleModel, LicensePlate = vehicleLicensePlate } };
            listOfDrivers.Add(driver);
        }
        public void RemoveDriver()
        {
            Console.WriteLine("Enter Id of the Driver to Remove: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string id = Console.ReadLine();
            Console.ResetColor();

            foreach (Driver driver in listOfDrivers.ToList())
            {
                if (id == driver.Id.ToString())
                {
                    if (listOfDrivers.Remove(driver))
                    {
                        Console.WriteLine($"Driver Removed with Id ***{id}***");
                        return;
                    }
                }
            }
            Console.WriteLine("***Driver Not Found***");
        }
        public void UpdateDriver()
        {
            Console.WriteLine("Enter Id of the Driver to Update: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string id = Console.ReadLine();
            Console.ResetColor();

            foreach (Driver driver in listOfDrivers)
            {
                if (id == driver.Id.ToString())
                {
                    Console.WriteLine($"Driver Exist With Id ***{id}***");


                    bool found = true;
                    Console.WriteLine("Enter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();

                    if (!string.IsNullOrEmpty(name))
                    {
                        driver.Name = name;
                    }

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
                                driver.Age = result;
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
                    if (!string.IsNullOrEmpty(gender))
                    {
                        driver.Gender = gender;
                    }

                    Console.WriteLine("Enter Address: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string address = Console.ReadLine();
                    Console.ResetColor();
                    if (!string.IsNullOrEmpty(address))
                    {
                        driver.Address = address;
                    }

                    Console.WriteLine("Enter Vehicle Type: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicleType = Console.ReadLine();
                    Console.ResetColor();
                    if (!string.IsNullOrEmpty(vehicleType))
                    {
                        driver.Vehicle.Type = vehicleType;
                    }

                    Console.WriteLine("Enter Vehicle Model: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicleModel = Console.ReadLine();
                    Console.ResetColor();
                    if (string.IsNullOrEmpty(vehicleModel))
                    {
                        driver.Vehicle.Model = vehicleModel;
                    }

                    Console.WriteLine("Enter License Plate: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicleLicensePlate = Console.ReadLine();
                    Console.ResetColor();
                    if (!string.IsNullOrEmpty(vehicleLicensePlate))
                    {
                        driver.Vehicle.LicensePlate = vehicleLicensePlate;
                    }

                    break;
                }
            }
            Console.WriteLine("***Driver Not Found***");
        }
        public void SearchDriver()
        {
            bool found = true;
            int age = 0;

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
            string age2 = Console.ReadLine();
            Console.ResetColor();
            while (found)
            {
                if (string.IsNullOrEmpty(age2))
                {
                    break;
                }
                if (int.TryParse(age2, out int result))
                {
                    age = result;
                    found = false;
                }
                else
                {
                    Console.WriteLine("***Wrong Input***");
                    Console.WriteLine("***Select Again: ");
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

            var searchedDrivers = new List<Driver>();
            if (listOfDrivers.Count == 0)
            {
                Console.WriteLine("***No Driver In List***");
            }
            else
            {
                foreach (Driver driver in listOfDrivers)
                {
                    if (id == driver.Id.ToString() || name == driver.Name || age == driver.Age || driver.Gender == gender || driver.Address == address || driver.Vehicle.Type == vehicleType || driver.Vehicle.LicensePlate == vehicleLicensePlate || driver.Vehicle.Model == vehicleModel)
                    {
                        searchedDrivers.Add(driver);
                    }
                }
                if (searchedDrivers.Count == 0)
                {
                    Console.WriteLine("***No Driver Found***");
                }
                else
                {
                    var table = new ConsoleTable("Id", "Name", "Age", "Gender", "Address", "Phone", "Location", "Availability", "V.Type", "V.Model", "V.License");
                    table.Options.EnableCount = false;
                    foreach (Driver driver in searchedDrivers)
                    {
                        table.AddRow(driver.Id, driver.Name, driver.Age, driver.Gender, driver.Address, driver.PhoneNumber, driver.CurrentLocation.Latitude + "," + driver.CurrentLocation.Longitude, driver.Availability, driver.Vehicle.Type, driver.Vehicle.Model, driver.Vehicle.LicensePlate);
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    table.Write();
                    Console.ResetColor();
                }
            }



        }

        public List<Driver> ListOfDrivers()
        {
            return listOfDrivers;
        }
    }
}