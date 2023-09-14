using AdminLib;
using DriverLib;
using LocationLib;
using PassengerLib;

namespace RideLib
{
    public class Ride
    {
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public double Price { get; set; }
        public Driver Driver { get; set; }
        public Passenger Passenger { get; set; }

        public void AssignPassenger(Passenger passenger)
        {
            Passenger.Name = passenger.Name;
            Passenger.PhoneNumber = passenger.PhoneNumber;
        }
        public void SetLocations(Location startLoc, Location endLoc)
        {
            StartLocation= startLoc;
            EndLocation= endLoc;
        }
        public double CalculatePrice(string rideType, Location startLoc, Location endLoc)
        {
            int fuelPrice = 272;
            double distance = Math.Sqrt(Math.Pow((endLoc.Latitude - startLoc.Latitude), 2) + Math.Pow(endLoc.Longitude - startLoc.Longitude, 2));
            if (rideType.ToLower() == "bike")
            {
                int fuelAverage = 50;
                int commission = 5;
                Price = (distance * fuelPrice) / fuelAverage;
                Price = Price + (Price * commission / 100);
                return Price;
            }
            else if (rideType.ToLower() == "rickshaw")
            {
                int fuelAverage = 35;
                int commission = 10;
                Price = (distance * fuelPrice) / fuelAverage;
                Price = Price + (Price * commission / 100);
                return Price;
            }
            else if (rideType.ToLower() == "car")
            {
                int fuelAverage = 15;
                int commission = 20;
                Price = (distance * fuelPrice) / fuelAverage;
                Price = Price + (Price * commission / 100);
                return Price;
            }
            return 0;
        }
        public Driver AssignDriver(Location customerLoc)
        {
            Admin objAdmin = new Admin();
            var listDrivers = objAdmin.ListOfDrivers();
            if(listDrivers.Count==0)
            {
                Console.WriteLine("Driver List is Empty");
                return null;
            }
            double minimumDistance = 100000000000000000.0;
            foreach( var driver in listDrivers)
            {
                if (driver.Availability)
                {
                    var distance = Math.Sqrt(Math.Pow((driver.CurrentLocation.Latitude - customerLoc.Latitude), 2) + Math.Pow(driver.CurrentLocation.Longitude - customerLoc.Longitude, 2));

                    if( distance < minimumDistance)
                    {
                        minimumDistance = distance;
                        Driver= driver;
                    }
                }
            }
            return Driver;
            
        }

    }
}