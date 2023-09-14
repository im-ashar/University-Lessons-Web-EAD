using AdminLib;
using DriverLib;
using LocationLib;
using RideLib;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PassengerLib
{
    public class Passenger
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public bool IsCorrectPhoneFormat(string phone)
        {
            if (phone.Length == 11)
            {
                return true;
            }
            return false;
        }
        public void BookRide()
        {
            Ride ride = new Ride();
            Console.WriteLine("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("Enter Phone Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string phone = Console.ReadLine();
            Console.ResetColor();
            while (!IsCorrectPhoneFormat(phone))
            {
                Console.WriteLine("***Wrong Input Try Again***");
                Console.ForegroundColor = ConsoleColor.Green;
                phone = Console.ReadLine();
                Console.ResetColor();

            }

            ride.Passenger = new Passenger { Name = name, PhoneNumber = phone };
            ride.AssignPassenger(new Passenger { Name = name, PhoneNumber = phone });

            Console.WriteLine("Enter Starting Location: ");
            var startLoc = new Location();
            var endLoc = new Location();
            bool whilebreak = true;
            while (whilebreak)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    var location = Console.ReadLine();
                    Console.ResetColor();
                    var locationArray = location.Split(',');
                    startLoc = new Location { Latitude = float.Parse(locationArray[0]), Longitude = float.Parse(locationArray[1]) };
                    whilebreak = false;
                }
                catch
                {
                    Console.WriteLine("***Wrong Input Try Again***");
                }
            }
            Console.WriteLine("Enter Ending Location: ");
            whilebreak = true;
            while (whilebreak)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    var location = Console.ReadLine();
                    Console.ResetColor();
                    var locationArray = location.Split(',');
                    endLoc = new Location { Latitude = float.Parse(locationArray[0]), Longitude = float.Parse(locationArray[1]) };
                    whilebreak = false;
                }
                catch
                {
                    Console.WriteLine("***Wrong Input Try Again***");
                }
            }
            ride.SetLocations(startLoc, endLoc);
            Console.WriteLine("Enter Ride Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string rideType = Console.ReadLine();
            Console.ResetColor();
            double price = ride.CalculatePrice(rideType, startLoc, endLoc);
            Console.WriteLine("--------Thank You--------");
            Console.WriteLine($"Price for this Ride is {price}");

            Console.WriteLine("Enter \'Y\' if you want to Book the ride, enter \'N\' if you want to cancel operation:");
            Console.ForegroundColor = ConsoleColor.Green;
            string answer = Console.ReadLine();
            Console.ResetColor();
            if (answer == "Y" || answer == "y")
            {
                var driver = ride.AssignDriver(startLoc);
                if (driver != null)
                {

                    Console.WriteLine("Happy Travel");
                    GiveRating(driver);
                }
            }
            else
            {
                Console.WriteLine("Ride Cancel");
            }
        }
        public void GiveRating(Driver driver)
        {
            Console.WriteLine("Give Rating Out of 5: ");
            bool found = true;
            int rating = 0;
            while (found)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    Console.ResetColor();
                    if (result < 0 || result > 5)
                    {
                        Console.WriteLine("***Wrong Input***");
                        Console.WriteLine("***Select Again: ");
                        continue;
                    }
                    else
                    {
                        rating = result;
                        found = false;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("***Wrong Input***");
                    Console.WriteLine("***Select Again: ");

                }
            }

            var listDriver = new Admin().ListOfDrivers();
            foreach (var d in listDriver)
            {
                if (d.Id == driver.Id)
                {
                    d.Rating.Add(rating);
                    break;
                }
            }

        }
    }
}