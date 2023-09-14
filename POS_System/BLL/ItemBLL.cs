using DAL;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemBLL
    {
        //Generating Item Id
        public int ItemIdGenerationBLL()
        {
            ItemDAL objItemDAL = new ItemDAL();
            return objItemDAL.ItemIdGenerationDAL();
        }
        //Setting Creation Date Of Product
        public void SetProductCreationDateBLL(ItemDTO objItemDTO)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nDo You Want To Save Item? ");
            Console.WriteLine("1- Yes\n2- No ");
            Console.ResetColor();
            Console.Write("\nYour Input: ");
            int check2 = 0;
            while (check2 != -1)
            {
                try
                {
                    int check = int.Parse(Console.ReadLine());
                    if (check == 1)
                    {
                        objItemDTO.ItemCreationDate = DateTime.Today.ToString("dd-MM-yyyy");
                        ItemDAL objItemDAL = new ItemDAL();
                        objItemDAL.ItemStoreToDbDAL(objItemDTO);
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Item Has Not Been Stored***\n");
                        Console.ResetColor();
                        break;
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
        }
        //Modifying Items
        public void ModifyItemBLL(int itemId)
        {
            int result = 0;
            bool found = false;
            ItemDAL objItemDAL = new ItemDAL();
            int check = objItemDAL.ModifyItemDAL(itemId);
            if (check == 1)
            {
                string s = "";
                ItemDTO objItemDTO = new ItemDTO();
                Console.Write("\nEnter Updated Description: ");
                objItemDTO.ItemDescription = Console.ReadLine();
                if (objItemDTO.ItemDescription.IsNullOrEmpty())
                {
                    objItemDTO.ItemDescription = "";
                }
                Console.Write("Enter Updated Price: ");
                while (!found)
                {
                    if (int.TryParse(s = Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("***Price Should Be A Number Greater Than 0***");
                            Console.ResetColor();
                            Console.Write("Enter Again: ");
                            found = false;
                        }
                        else
                        {
                            objItemDTO.ItemPrice = result.ToString();
                            found = true;
                        }
                    }
                    else if (s.IsNullOrEmpty())
                    {
                        objItemDTO.ItemPrice = "";
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Price Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                    }
                }

                found= false;
                result= 0;
                Console.Write("Enter Updated Quantity: ");
                while (!found)
                {
                    if (int.TryParse(s = Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("***Quantity Should Be A Number Greater Than 0***");
                            Console.ResetColor();
                            Console.Write("Enter Again: ");
                            found = false;
                        }
                        else
                        {
                            objItemDTO.ItemQuantity = result.ToString();
                            found = true;
                        }
                    }
                    else if (s.IsNullOrEmpty())
                    {
                        objItemDTO.ItemQuantity = "";
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Quantity Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                    }
                }

                objItemDTO.ItemId = itemId;
                objItemDTO.ItemUpdateDate = DateTime.Today.ToString("dd-MM-yyyy");
                objItemDAL.ModifyItemToDbDAL(objItemDTO);
            }
            else
            {
                return;
            }
        }
        //Searching items
        public void FindItemBLL(ItemDTO objItemDTO)
        {
            ItemDAL objItemDAL = new ItemDAL();
            objItemDAL.FindItemDAL(objItemDTO);
        }
        //Removing Items
        public void RemoveItemBLL(int itemId)
        {
            ItemDAL objItemDAL = new ItemDAL();
            int check = objItemDAL.RemoveItemDAL(itemId);
            int whileBreaker = 0;
            if (check == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDo You Want To Delete This Item? ");
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
                            objItemDAL.RemoveItemFromDbDAL(itemId);
                            whileBreaker = -1;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n***Item Has Not Been Deleted***\n");
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
                Console.WriteLine("\n***Cannot Delete This Item Because It Has A Recorded Sale***\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Item Has Not Been Found***\n");
                Console.ResetColor();
            }
        }
    }
}
