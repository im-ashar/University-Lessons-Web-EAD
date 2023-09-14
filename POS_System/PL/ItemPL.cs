using BLL;
using DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class ItemPL
    {
        //Items Menu Display
        public void ItemMenuDisplay2PL()
        {
            Console.WriteLine("1- Add new Item\n2- Update Item details\n3- Find Items\n4- Remove Existing Item\n5- Back to Main Menu");
            Console.Write("\n\nPress 1 to 5 To Select An Option: ");
        }
        public void ItemsMenuDisplayPL()
        {
            int check = 0;
            ItemMenuDisplay2PL();
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
                            AddNewItemPL();
                            ItemMenuDisplay2PL();
                            break;
                        case 2:
                            ModifyItemPL();
                            ItemMenuDisplay2PL();
                            break;
                        case 3:
                            FindItemPL();
                            ItemMenuDisplay2PL();
                            break;
                        case 4:
                            RemoveItemPL();
                            ItemMenuDisplay2PL();
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
        //Adding New Item
        public void AddNewItemPL()
        {
            int result = 0;
            bool found = false;
            ItemDTO objItemDTO = new ItemDTO();
            ItemBLL objItemBLL = new ItemBLL();

            objItemDTO.ItemId = (objItemBLL.ItemIdGenerationBLL()) + 1;
            Console.WriteLine($"\nItem Id: {objItemDTO.ItemId}");
            Console.Write("Enter Description: ");
            objItemDTO.ItemDescription = Console.ReadLine();
            while (objItemDTO.ItemDescription.IsNullOrEmpty())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Item Description Cant Be Empty***\n");
                Console.ResetColor();
                Console.Write("Enter Again: ");
                objItemDTO.ItemDescription = Console.ReadLine();
            }

            Console.Write("Enter Price: ");
            while (!found)
            {
                if (int.TryParse(Console.ReadLine(), out result))
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
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Price Should Be A Number Greater Than 0***");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                }
            }
            result = 0;
            found = false;
            Console.Write("Enter Quantity: ");
            while (!found)
            {
                if (int.TryParse(Console.ReadLine(), out result))
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
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Quantity Should Be A Number Greater Than 0***");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                }
            }














            //while (!(int.TryParse(objItemDTO.ItemQuantity, out int result)))
            //{
            //    if (objItemDTO.ItemQuantity.IsNullOrEmpty())
            //    {
            //        objItemDTO.ItemQuantity = "500";
            //        break;
            //    }
            //    if (result <= 0)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("***Quantity Should Be A Number Greater Than 0***");
            //        Console.ResetColor();
            //        Console.Write("Enter Again: ");
            //        continue;
            //    }
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("***Quantity Should Be A Number***");
            //    Console.ResetColor();
            //    Console.Write("Enter Again: ");
            //    objItemDTO.ItemQuantity = Console.ReadLine();
            //}
            objItemBLL.SetProductCreationDateBLL(objItemDTO);
        }
        //Updating Existing Item
        public void ModifyItemPL()
        {
            bool found = false;
            int result = 0;
            int itemId = 0;
            Console.Write("\nEnter Item ID To Update: ");
            while (!found)
            {
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Item Id Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                        found = false;
                    }
                    else
                    {
                        itemId = result;
                        found = true;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Item Id Should Be A Number Greater Than 0***");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                }
            }
            ItemBLL objItemBLL = new ItemBLL();
            objItemBLL.ModifyItemBLL(itemId);
        }
        //Find Existing Item
        public void FindItemPL()
        {
            try
            {
                string itemId = "", itemPrice = "", itemQuantity="";
                bool found = false;
                int result = 0;
                ItemDTO objItemDTO = new ItemDTO();
                Console.WriteLine("\nPlease Specify Atleast One Of The Following To Find The Item.");
                Console.WriteLine("Leave All Fields Blank To Return To Items Menu: \n");
                Console.Write("Item ID: ");
                while (!found)
                {
                    if (int.TryParse(itemId=Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("***Item Id Should Be A Number Greater Than 0***");
                            Console.ResetColor();
                            Console.Write("Enter Again: ");
                            found = false;
                        }
                        else
                        {
                            itemId = result.ToString();
                            found = true;
                        }
                    }
                    else if (itemId.IsNullOrEmpty())
                    {
                        itemId = "";
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Item Id Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                    }
                }
                
                Console.Write("Description: ");
                string itemDescription = Console.ReadLine();

                found=false;
                result = 0;
                Console.Write("Price: ");
                while (!found)
                {
                    if (int.TryParse(itemPrice = Console.ReadLine(), out result))
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
                            itemPrice = result.ToString();
                            found = true;
                        }
                    }
                    else if (itemPrice.IsNullOrEmpty())
                    {
                        itemPrice = "";
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
                result = 0;
                Console.Write("Quantity: ");
                while (!found)
                {
                    if (int.TryParse(itemQuantity = Console.ReadLine(), out result))
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
                            itemQuantity = result.ToString();
                            found = true;
                        }
                    }
                    else if (itemQuantity.IsNullOrEmpty())
                    {
                        itemQuantity = "";
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

                Console.Write("Creation Date (DD-MM-YYYY): ");
                string itemCreationDate = Console.ReadLine();
                Console.Write("\n");
                if (itemId == string.Empty && itemDescription == string.Empty && itemPrice == string.Empty && itemQuantity == string.Empty && itemCreationDate == string.Empty)
                {
                    return;
                }
                else
                {
                    if (itemId.IsNullOrEmpty())
                    {
                        objItemDTO.ItemId = null;
                    }
                    else
                    {
                        objItemDTO.ItemId = int.Parse(itemId);
                    }
                    objItemDTO.ItemDescription = itemDescription;
                    objItemDTO.ItemPrice = itemPrice;
                    objItemDTO.ItemQuantity = itemQuantity;
                    objItemDTO.ItemCreationDate = itemCreationDate;
                    ItemBLL objItemBLL = new ItemBLL();
                    objItemBLL.FindItemBLL(objItemDTO);
                }

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Exception Found In FindItemPL***\n");
                Console.ResetColor();
            }

        }
        //Remove Existing Item
        public void RemoveItemPL()
        {
            Console.Write("\nEnter Item Id You Want To Delete: ");
            int check = 0;
            while (check != -1)
            {
                try
                {
                    int itemId = int.Parse(Console.ReadLine());
                    if (itemId <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Item Id Should Be A Number Greater Than 0***\n");
                        Console.ResetColor();
                        Console.Write("Select Again: ");
                        continue;
                    }
                    check = -1;
                    ItemBLL objItemBLL = new ItemBLL();
                    objItemBLL.RemoveItemBLL(itemId);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Item Id Should Be A Number Greater Than 0***\n");
                    Console.ResetColor();
                    Console.Write("Select Again: ");
                }
            }
        }
    }
}
