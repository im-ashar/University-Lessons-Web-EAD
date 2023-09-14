using DAL;
using DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerBLL
    {
        //Customer ID Generation
        public int CustomerIdGenerationBLL()
        {
            CustomerDAL objCustomerDAL = new CustomerDAL();
            return objCustomerDAL.CustomerIdGenerationDAL();
        }
        //Setting Customer Registration Date
        public void SetCustomerRegistrationDateBLL(CustomerDTO objCustomerDTO)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nDo You Want To Save Customer? ");
            Console.WriteLine("1- Yes\n2- No ");
            Console.ResetColor();
            Console.Write("\nYour Input: ");
            try
            {
                int check = int.Parse(Console.ReadLine());
                if (check == 1)
                {
                    objCustomerDTO.CustomerRegistrationDate = DateTime.Today.ToString("dd-MM-yyyy");
                    CustomerDAL objCustomerDAL = new CustomerDAL();
                    objCustomerDAL.CustomerStoreToDbDAL(objCustomerDTO);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Customer Has Not Been Stored***\n");
                    Console.ResetColor();
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInput Should Be A Number\n");
                Console.ResetColor();
                Console.Write("Enter Again: ");
            }
        }
        //Modifying Customer
        public void ModifyCustomerBLL(int customerId)
        {
            int result = 0;
            bool found=false;
            CustomerDAL objCustomerDAL = new CustomerDAL();
            int check = objCustomerDAL.ModifyCustomerDAL(customerId);
            if (check == 1)
            {
                CustomerDTO objCustomerDTO = new CustomerDTO();
                Console.Write("\n");
                Console.Write("Enter Updated Name: ");
                objCustomerDTO.CustomerName = Console.ReadLine();
                Console.Write("Enter Updated Address: ");
                objCustomerDTO.CustomerAddress = Console.ReadLine();
                Console.Write("Enter Updated Phone: ");
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
                        objCustomerDTO.CustomerPhone = "";
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

                Console.Write("Enter Updated Email: ");
                objCustomerDTO.CustomerEmail = Console.ReadLine();
                var email = new EmailAddressAttribute();
                while (!(email.IsValid(objCustomerDTO.CustomerEmail)))
                {
                    if (objCustomerDTO.CustomerEmail.IsNullOrEmpty())
                    {
                        objCustomerDTO.CustomerEmail = "";
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Email Is InValid***");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                    objCustomerDTO.CustomerEmail = Console.ReadLine();
                }

                found= false;
                result=0;
                Console.Write("Enter Updated Amount Payable: ");
                while (!found)
                {
                    if (int.TryParse(objCustomerDTO.CustomerAmountPayable = Console.ReadLine(), out result))
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
                    else if (objCustomerDTO.CustomerAmountPayable.IsNullOrEmpty())
                    {
                        objCustomerDTO.CustomerAmountPayable = "";
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
                found = false;
                result = 0;
                Console.Write("Enter Updated Sales Limit: ");
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
                        objCustomerDTO.CustomerSalesLimit = "";
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

                objCustomerDTO.CustomerId = customerId;
                objCustomerDAL.ModifyCustomerToDbDAL(objCustomerDTO);
            }
            else
            {
                return;
            }
        }
        //Finding Customer
        public void FindCustomerBLL(CustomerDTO objCustomerDTO)
        {
            CustomerDAL objCustomerDAL = new CustomerDAL();
            objCustomerDAL.FindCustomerDAL(objCustomerDTO);
        }
        //Removing Customer
        public void RemoveCustomerBLL(int customerId)
        {
            CustomerDAL objCustomerDAL = new CustomerDAL();
            int check = objCustomerDAL.RemoveCustomerDAL(customerId);
            int whileBreaker = 0;
            if (check == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDo You Want To Delete This Customer? ");
                Console.WriteLine("1- Yes\n2- No ");
                Console.Write("\nYour Input: ");
                Console.ResetColor();
                while (whileBreaker != -1)
                {
                    try
                    {
                        int check2 = int.Parse(Console.ReadLine());
                        if (check2 == 1)
                        {
                            objCustomerDAL.RemoveCustomerFromDbDAL(customerId);
                            whileBreaker = -1;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n***Customer Has Not Been Deleted***\n");
                            Console.ResetColor();
                            return;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Input Should Be A Number\n");
                        Console.ResetColor();
                        Console.Write("Select Again: \n");
                    }
                }
            }
            else if (check == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Cannot Delete This Customer Because It Is Associated With A Sale***\n");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Customer Has Not Been Found***\n");
                Console.ResetColor();
            }
        }
    }
}
