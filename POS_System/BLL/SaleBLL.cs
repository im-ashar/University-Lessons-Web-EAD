using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SaleBLL
    {
        //Generating Id For Sale
        public int SaleIdGenerationBLL()
        {
            SaleDAL objSaleDAL = new SaleDAL();
            return objSaleDAL.SaleIdGenerationDAL();
        }
        //Getting Item Details For On Going Sale
        public ItemDTO GetItemForSaleFromDbBLL(int itemId)
        {
            SaleDAL objSaleDAL = new SaleDAL();
            return objSaleDAL.GetItemForSaleFromDbDAL(itemId);
        }
        //Creating New Sale
        public bool CreateNewSaleInDbBLL(SaleDTO objSaleDTO)
        {
            SaleDAL objSaleDAL = new SaleDAL();
            objSaleDTO.SaleStatus = "Active";
            return objSaleDAL.CreateNewSaleInDbDAL(objSaleDTO);
        }
        //Ending Sale
        public void EndSaleBLL(List<SaleDTO> CurrentSaleItemsIds)
        {
            SaleDAL objSaleDAL = new SaleDAL();
            objSaleDAL.EndSaleDAL(CurrentSaleItemsIds);
        }
        //Make Payment
        public void MakePaymentBLL(int saleId)
        {
            SaleDAL objSaleDAL = new SaleDAL();
            objSaleDAL.MakePaymentDAL(saleId);
        }   
    }
}
