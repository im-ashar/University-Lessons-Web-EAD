using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class MainMenuPL
    {
        //Main Menu Display Function
        public void MainMenuDisplay2PL()
        {
            Console.WriteLine("1- Manage Items\n2- Manage Customers\n3- Make New Sale\n4- Make Payment\n5- Exit");
            Console.Write("\n\nPress 1 To 5 To Select An Option: ");
        }
        public void MainMenuDisplayPL()
        {
            int check = 0;
            MainMenuDisplay2PL();
            while (check != 5)
            {
                try
                {
                    ItemPL objItemPL = new ItemPL();
                    CustomerPL objCustomerPL = new CustomerPL();
                    SalePL objSalePL = new SalePL();
                    check = int.Parse(Console.ReadLine());
                    if (check >= 6 || check <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Input Should Be A Number From 1 To 5***\n");
                        Console.ResetColor();
                        Console.Write("Select Again: ");
                        continue;
                    }
                    if (check == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Program Exits***\n");
                        Console.ResetColor();
                        break;
                    }
                    switch (check)
                    {
                        case 1:
                            Console.Write("\n");
                            objItemPL.ItemsMenuDisplayPL();
                            break;
                        case 2:
                            Console.Write("\n");
                            objCustomerPL.CustomersMenuDisplayPL();
                            break;
                        case 3:
                            objSalePL.MakeNewSalePL();
                            Console.Write("\n");
                            MainMenuDisplay2PL();
                            break;
                        case 4:
                            objSalePL.MakePaymentPL();
                            Console.Write("\n");
                            MainMenuDisplay2PL();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Input Should Be A Number From 1 To 5***\n");
                    Console.ResetColor();
                    Console.Write("Select Again: ");
                }
            }

        }
    }
}

