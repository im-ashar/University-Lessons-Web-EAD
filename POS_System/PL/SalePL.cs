using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class SalePL
    {
        List<SaleDTO> CurrentSaleItemsIds = new List<SaleDTO>();
        SaleBLL objSaleBLL = new SaleBLL();

        //Creating New Sale
        public void MakeNewSalePL()
        {
            SaleDTO objSaleDTO = new SaleDTO();
            objSaleDTO.SaleId = objSaleBLL.SaleIdGenerationBLL() + 1;
            objSaleDTO.SaleDate = DateTime.Today.ToString("dd-MM-yyyy");
            Console.WriteLine($"\nSale Id: {objSaleDTO.SaleId}");
            Console.WriteLine($"Sale Date: {objSaleDTO.SaleDate}");
            Console.Write($"Enter Customer Id: ");
            int check = 0;
            while (check != -1)
            {
                try
                {
                    objSaleDTO.CustomerId = int.Parse(Console.ReadLine());
                    if (objSaleDTO.CustomerId <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Customer Id Should Be A Number Greater Than 0***\n");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                        continue;
                    }
                    check = -1;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Customer Id Should Be A Number Greater Than 0***\n");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                }
            }
            objSaleDTO.Total = 0;
            Console.WriteLine("\nEnter Items For This Sale\n");
            EnterItemsToCurrentSalePL(objSaleDTO);
            while (check != 4)
            {
                Console.Write("\n");
                check = GetInputAboutSalePL();
                if (check == 1)
                {
                    EnterItemsToCurrentSalePL(objSaleDTO);
                }
                else if (check == 2)
                {
                    EndSalePL(objSaleDTO);
                    break;
                }
                else if (check == 3)
                {
                    DeleteItemFromCurrentSalePL();
                }
                else if (check == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Sale Cancelled***");
                    Console.ResetColor();
                    check = 4;
                }
            }
        }
        //Ending Sale
        public void EndSalePL(SaleDTO objSaleDTO)
        {
            bool b = objSaleBLL.CreateNewSaleInDbBLL(objSaleDTO);
            if (b)
            {
                objSaleBLL.EndSaleBLL(CurrentSaleItemsIds);
            }

        }
        //Deleting Items From On Going Sale
        public void DeleteItemFromCurrentSalePL()
        {
            try
            {
                int id = 0;
                int result = 0;
                bool found = false;
                Console.Write("Enter Item Id To Delete: ");
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
                            id = result;
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

                found = false;
                result = 0;
                string quantity = "";
                Console.Write("Enter Quantity To Remove: ");
                while (!found)
                {
                    if (int.TryParse(Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("***Item Quantity Should Be A Number Greater Than 0***");
                            Console.ResetColor();
                            Console.Write("Enter Again: ");
                            found = false;
                        }
                        else
                        {
                            quantity = result.ToString();
                            found = true;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("***Item Quantity Should Be A Number Greater Than 0***");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                    }
                }

                if (CurrentSaleItemsIds.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Sale Is Empty***\n");
                    Console.ResetColor();
                }
                else
                {
                    found = false;
                    foreach (SaleDTO x in CurrentSaleItemsIds)
                    {
                        if (x.ItemId == id)
                        {
                            int y = int.Parse(x.ItemQuantity) - int.Parse(quantity);
                            if (y < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n***Your Deleting Quantity Is More Than Present Quantity In Sale***\n");
                                Console.ResetColor();
                                found = true;
                                break;
                            }
                            x.ItemQuantity = y.ToString();
                            ItemDTO objItemDTO = objSaleBLL.GetItemForSaleFromDbBLL(x.ItemId);
                            x.Total = int.Parse(x.ItemQuantity) * int.Parse(objItemDTO.ItemPrice);
                            if (int.Parse(x.ItemQuantity) == 0)
                            {
                                CurrentSaleItemsIds.Remove(x);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n***Item Has Been Deleted From The Sale***");
                                found = true;
                                Console.ResetColor();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n***Item Quantity Has Been Updated***");
                                Console.ResetColor();
                            }
                            found = true;

                        }
                    }
                    if (found == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***This Item Is Not Available In This Sale***\n");
                        Console.ResetColor();
                    }
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nException Found In DeleteItemFromCurrentSalePL\n");
                Console.ResetColor();
            }

        }
        //Adding Items To On Going Sale
        public void EnterItemsToCurrentSalePL(SaleDTO objSaleDTO)
        {
            try
            {
                int result = 0;
                bool found = false;
                Console.Write("Enter Item Id: ");
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result <= 0)
                    {
                        found = false;
                    }
                    else
                    {
                        objSaleDTO.ItemId = result;
                        found = true;
                    }
                }
                while (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Item Id Should Be A Number Greater Than 0***");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                    if (int.TryParse(Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            found = false;
                        }
                        else
                        {
                            objSaleDTO.ItemId = result;
                            found = true;
                        }
                    }
                }

                ItemDTO objItemDTO = objSaleBLL.GetItemForSaleFromDbBLL(objSaleDTO.ItemId);
                if (objItemDTO.ItemId == -1)
                {
                    return;
                }
                else
                {
                    Console.WriteLine($"Description: {objItemDTO.ItemDescription}");
                    Console.WriteLine($"Price: {objItemDTO.ItemPrice}");
                }

                result = 0;
                found = false;
                Console.Write("Quantity: ");
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result <= 0)
                    {
                        found = false;
                    }
                    else
                    {
                        objSaleDTO.ItemQuantity = result.ToString();
                        found = true;
                    }
                }
                while (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Item Quantity Should Be A Number Greater Than 0***");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                    if (int.TryParse(Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            found = false;
                        }
                        else
                        {
                            objSaleDTO.ItemQuantity = result.ToString();
                            found = true;
                        }
                    }
                }

                int subTotal = int.Parse(objSaleDTO.ItemQuantity) * int.Parse(objItemDTO.ItemPrice);
                objSaleDTO.Total = objSaleDTO.Total + subTotal;
                Console.WriteLine($"Sub-Total: {objSaleDTO.Total:C}");
                if (CurrentSaleItemsIds.Count == 0)
                {
                    SaleDTO objSaleDTO2 = new SaleDTO();
                    objSaleDTO2.ItemId = objSaleDTO.ItemId;
                    objSaleDTO2.SaleId = objSaleDTO.SaleId;
                    objSaleDTO2.CustomerId = objSaleDTO.CustomerId;
                    objSaleDTO2.SaleDate = objSaleDTO.SaleDate;
                    objSaleDTO2.SaleStatus = objSaleDTO.SaleStatus;
                    objSaleDTO2.ItemQuantity = objSaleDTO.ItemQuantity;
                    objSaleDTO2.Total = objSaleDTO.Total;
                    CurrentSaleItemsIds.Add(objSaleDTO2);
                }
                else
                {
                    bool found2 = false;
                    foreach (SaleDTO x in CurrentSaleItemsIds)
                    {
                        if (x.ItemId == objSaleDTO.ItemId)
                        {
                            int y = int.Parse(x.ItemQuantity) + int.Parse(objSaleDTO.ItemQuantity);
                            x.ItemQuantity = y.ToString();
                            x.Total = int.Parse(x.ItemQuantity) * int.Parse(objItemDTO.ItemPrice);
                            found2 = true;
                            break;
                        }
                    }
                    if (!found2)
                    {

                        SaleDTO objSaleDTO2 = new SaleDTO();
                        objSaleDTO2.ItemId = objSaleDTO.ItemId;
                        objSaleDTO2.SaleId = objSaleDTO.SaleId;
                        objSaleDTO2.CustomerId = objSaleDTO.CustomerId;
                        objSaleDTO2.SaleDate = objSaleDTO.SaleDate;
                        objSaleDTO2.SaleStatus = objSaleDTO.SaleStatus;
                        objSaleDTO2.ItemQuantity = objSaleDTO.ItemQuantity;
                        objSaleDTO2.Total = int.Parse(objSaleDTO.ItemQuantity) * int.Parse(objItemDTO.ItemPrice);
                        CurrentSaleItemsIds.Add(objSaleDTO2);
                    }
                }

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Exception Found In EnterItemsToCurrentSalePL***\n");
                Console.ResetColor();
            }
        }
        //Getting Input About On Going Sale
        public int GetInputAboutSalePL()
        {
            int result = 0;
            bool found = false;
            Console.WriteLine("Press 1 to Enter New Item");
            Console.WriteLine("Press 2 to End Sale");
            Console.WriteLine("Press 3 to Remove An Existing Item From The Current Sale");
            Console.WriteLine("Press 4 to Cancel Sale");
            Console.Write("\nYour Option: ");
            while (!found)
            {
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result <= 0 || result >= 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Input Should Be A Number From 1 To 4***\n");
                        Console.ResetColor();
                        Console.Write("Enter Again: ");
                        found = false;
                    }
                    else
                    {
                        found = true;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Input Should Be A Number From 1 To 4***\n");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                }
            }
            return result;

        }
        //Make Payment
        public void MakePaymentPL()
        {

            try
            {
                int saleId = 0;
                int result = 0;
                bool found = false;
                Console.Write("\nEnter Sale Id: ");
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result <= 0)
                    {
                        found = false;
                    }
                    else
                    {
                        saleId = result;
                        found = true;
                    }
                }
                while (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Sale Id Should Be A Number Greater Than 0***\n");
                    Console.ResetColor();
                    Console.Write("Enter Again: ");
                    if (int.TryParse(Console.ReadLine(), out result))
                    {
                        if (result <= 0)
                        {
                            found = false;
                        }
                        else
                        {
                            saleId = result;
                            found = true;
                        }
                    }
                }
                SaleBLL objSaleBLL = new SaleBLL();
                objSaleBLL.MakePaymentBLL(saleId);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Exception Found In MakePaymentPL***\n");
                Console.ResetColor();
            }

        }
    }
}
