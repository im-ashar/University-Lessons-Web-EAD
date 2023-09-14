using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SaleDTO
    {
        //Data Transfer Objects For Sale
        public int ItemId { get; set; }
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public string SaleDate { get; set; }
        public string SaleStatus { get; set; }
        public string ItemQuantity { get; set; }
        public int Total { get; set; }
    }
}
