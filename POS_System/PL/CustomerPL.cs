using BLL;
using DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace PL
{
    public class CustomerPL
    {
        //Customer Menu Display
        public void CustomersMenuDisplay2PL()
        {
            Console.WriteLine("1- Add new Customer \n2- Update Customer details \n3- Find Customer \n4- Remove Existing Customer \n5- Back to Main Menu");
            Console.Write("\n\nPress 1 To 5 To Select An Option: ");
        }
        public void CustomersMenuDisplayPL()
        {
            int check = 0;
            CustomersMenuDisplay2PL();
            while (check != 5)
            {
                try
                {
                    check = int.Parse(Console.ReadLine());
                    if (check >= 6 || check <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Input Should Be A Number From 1 To 5***\n");
                        Console.ResetColor();
                        Console.Write("Select Again: ");
                        continue;
                    }
                    else if (check == 5)
                    {
                        Console.WriteLine();
                        MainMenuPL objMainMenuPL = new MainMenuPL();
                        objMainMenuPL.MainMenuDisplay2PL();
                        break;
                    }
                    switch (check)
                    {
                        case 1:
                            AddNewCustomerPL();
                            CustomersMenuDisplay2PL();
                            break;
                        case 2:
                            ModifyCustomerPL();
                            CustomersMenuDisplay2PL();
                            break;
                        case 3:
                            FindCustomerPL();
                            Console.Write("\n");
                            CustomersMenuDisplay2PL();
                            break;
                        case 4:
                            RemoveCustomerPL();
                            CustomersMenuDisplay2PL();
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
        //Adding New Customer
        public void AddNewCustomerPL()
        {
            int result = 0;
            bool found = false;
            CustomerDTO objCustomerDTO = new CustomerDTO();
            CustomerBLL objCustomerBLL = new CustomerBLL();

            objCustomerDTO.CustomerId = (objCustomerBLL.CustomerIdGenerationBLL()) + 1;
            Console.WriteLine($"\nCustomer Id: {objCustomerDTO.CustomerId}");

            Console.Write("Enter Name: ");
            objCustomerDTO.CustomerName = Console.ReadLine();
            while (objCustomerDTO.CustomerName.IsNullOrEmpty())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("***Customer Name Is Required***");
                Console.ResetColor();
                Console.Write("Please Enter Again: ");
                objCustomerDTO.CustomerName = Console.ReadLine();
            }

            Console.Write("Enter Address: ");
            objCustomerDTO.CustomerAddress = Console.ReadLine();
            if (objCustomerDTO.CustomerAddress.IsNullOrEmpty())
            {
                objCustomerDTO.CustomerAddress = "None";
            }

            Console.Write("Enter Phone: ");
            while (!found)
            {
                if (int.TryParse(objCustomerDTO.CustomerPhone = Console.ReadLine(), out result))
                {
                    if (result <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Phone Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                        found = false;
                    }
                    else
                    {
                        found = true;
                    }
                }
                else if (objCustomerDTO.CustomerPhone.IsNullOrEmpty())
                {
                    objCustomerDTO.CustomerPhone = "None";
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Phone Should Be A Number Greater Than 0***");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                }
            }

            Console.Write("Enter Email: ");
            objCustomerDTO.CustomerEmail = Console.ReadLine();
            var email = new EmailAddressAttribute();
            while (!(email.IsValid(objCustomerDTO.CustomerEmail)))
            {
                if (objCustomerDTO.CustomerEmail.IsNullOrEmpty())
                {
                    objCustomerDTO.CustomerEmail = "None";
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("***Email Is InValid***");
                Console.ResetColor();
                Console.Write("Enter Again: ");
                objCustomerDTO.CustomerEmail = Console.ReadLine();
            }

            found = false;
            result = 0;
            Console.Write("Enter Sales Limit: ");
            while (!found)
            {
                if (int.TryParse(objCustomerDTO.CustomerSalesLimit = Console.ReadLine(), out result))
                {
                    if (result <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Sales Limit Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                        found = false;
                    }
                    else
                    {
                        found = true;
                    }
                }
                else if (objCustomerDTO.CustomerSalesLimit.IsNullOrEmpty())
                {
                    objCustomerDTO.CustomerSalesLimit = "50000";
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Sales Limit Should Be A Number Greater Than 0***");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                }
            }

            objCustomerDTO.CustomerAmountPayable = "0";

            objCustomerBLL.SetCustomerRegistrationDateBLL(objCustomerDTO);
        }
        //Updating Existing Customer
        public void ModifyCustomerPL()
        {
            int check = 0;
            Console.Write("\nEnter Customer Id To Update: ");
            while (check != -1)
            {
                try
                {
                    int CustomerId = int.Parse(Console.ReadLine());
                    if (CustomerId <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Customer Id Should Be A Number Greater Than 0***\n");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                        continue;
                    }
                    check = -1;
                    CustomerBLL objCustomerBLL = new CustomerBLL();
                    objCustomerBLL.ModifyCustomerBLL(CustomerId);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Customer Id Should Be A Number Greater Than 0***\n");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                }
            }
        }
        //Find Existing Customer
        public void FindCustomerPL()
        {
            try
            {
                int result = 0;
                bool found = false;
                string customerId = "", customerName = "", customerAddress = "", customerPhone = "", customerEmail = "", customerAmountPayable = "", customerSalesLimit = "", customerRegistrationDate = "";
                CustomerDTO objCustomerDTO = new CustomerDTO();
                Console.WriteLine("\nPlease Specify Atleast One Of The Following To Find The Customer.");
                Console.Write("Leave All Fields Blank To Return To Customers Menu: \n");
                Console.Write("\nCustomer ID: ");
                while (!found)
                {
                    if (int.TryParse(customerId = Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("***Customer Id Should Be A Number Greater Than 0***");
                            Console.ResetColor();
                            Console.Write("Enter Again: ");
                            found = false;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                    else if (customerId.IsNullOrEmpty())
                    {
                        customerId = "";
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Customer Id Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                    }
                }
                found= false;
                result=0;
                Console.Write("Name: ");
                customerName = Console.ReadLine();
                Console.Write("Address: ");
                customerAddress = Console.ReadLine();
                Console.Write("Phone: ");
                while (!found)
                {
                    if (int.TryParse(customerPhone = Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("***Phone Should Be A Number Greater Than 0***");
                            Console.ResetColor();
                            Console.Write("Enter Again: ");
                            found = false;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                    else if (customerPhone.IsNullOrEmpty())
                    {
                        customerPhone = "";
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Phone Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                    }
                }

                Console.Write("Email: ");
                customerEmail = Console.ReadLine();

                found=false;
                result = 0;
                Console.Write("Amount Payable: ");
                while (!found)
                {
                    if (int.TryParse(customerAmountPayable = Console.ReadLine(), out result))
                    {
                        if (result < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("***Amount Should Be A Number Greater Than 0***");
                            Console.ResetColor();
                            Console.Write("Enter Again: ");
                            found = false;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                    else if (customerAmountPayable.IsNullOrEmpty())
                    {
                        customerAmountPayable = "";
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Amount Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                    }
                }

                found =false;
                result = 0;
                Console.Write("Sales Limit: ");
                while (!found)
                {
                    if (int.TryParse(customerSalesLimit = Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("***Sales Limit Should Be A Number Greater Than 0***");
                            Console.ResetColor();
                            Console.Write("Enter Again: ");
                            found = false;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                    else if (customerSalesLimit.IsNullOrEmpty())
                    {
                        customerSalesLimit = "";
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Sales Limit Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                    }
                }

                Console.Write("Registration Date: ");
                customerRegistrationDate = Console.ReadLine();
                if (customerId == string.Empty && customerName == string.Empty && customerAddress == string.Empty && customerPhone == string.Empty && customerEmail == string.Empty && customerAmountPayable == string.Empty && customerSalesLimit == string.Empty && customerRegistrationDate == string.Empty)
                {
                    return;
                }
                else
                {
                    if (customerId.IsNullOrEmpty())
                    {
                        objCustomerDTO.CustomerId = null;
                    }
                    else
                    {
                        objCustomerDTO.CustomerId = int.Parse(customerId);
                    }
                    objCustomerDTO.CustomerName = customerName;
                    objCustomerDTO.CustomerAddress = customerAddress;
                    objCustomerDTO.CustomerPhone = customerPhone;
                    objCustomerDTO.CustomerEmail = customerEmail;
                    objCustomerDTO.CustomerAmountPayable = customerAmountPayable;
                    objCustomerDTO.CustomerSalesLimit = customerSalesLimit;
                    objCustomerDTO.CustomerRegistrationDate = customerRegistrationDate;
                    CustomerBLL objCustomerBLL = new CustomerBLL();
                    objCustomerBLL.FindCustomerBLL(objCustomerDTO);
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Exception Found In FindCustomerPL***\n");
                Console.ResetColor();
            }
        }
        //Remove Existing Customer
        public void RemoveCustomerPL()
        {
            Console.Write("\nEnter Customer Id You Want To Delete: ");
            int check = 0;
            while (check != -1)
            {
                try
                {
                    int customerId = int.Parse(Console.ReadLine());
                    if(customerId<=0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Customer Id Should Be A Number Greater Than 0***\n");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                        continue;
                    }
                    check = -1;
                    CustomerBLL objCustomerBLL = new CustomerBLL();
                    objCustomerBLL.RemoveCustomerBLL(customerId);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Customer Id Should Be A Number Greater Than 0***\n");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                }
            }
        }
    }
}

