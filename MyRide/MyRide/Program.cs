using AdminLib;
using DriverLib;
using PassengerLib;

void MainMenu()
{
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("                 Welcome To MyRide                  ");
    Console.WriteLine("----------------------------------------------------");

    Console.WriteLine("1. Book a Ride\n2. Enter as Driver\n3. Enter as Admin\n");
    Console.WriteLine("Press 1 to 3 to select an option:");
}
MainMenu();
bool found = true;
while (found)
{
    Console.ForegroundColor = ConsoleColor.Green;
    if (int.TryParse(Console.ReadLine(), out int result))
    {
        Console.ResetColor();
        if (result < 1 || result > 3)
        {
            Console.ResetColor();
            Console.WriteLine("***Wrong Input***");
            Console.WriteLine("***Select Again: ");
            continue;
        }
        else
        {

            Admin objAdmin = new Admin();
            Driver objDriver = new Driver();
            Passenger objPassenger = new Passenger();
            switch (result)
            {
                case 1:
                    objPassenger.BookRide();
                    break;
                case 2:
                    var list = objAdmin.ListOfDrivers();
                    objDriver.DriverMenu(list);
                    MainMenu();
                    continue;
                case 3:
                    objAdmin.AdminMenu();
                    MainMenu();
                    continue;
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

