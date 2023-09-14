using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemDTO
    {
        //Data Transfer Objects For Items
        public int? ItemId { get; set; }
        public string ItemDescription { get; set; }
        public string ItemPrice { get; set; }
        public string ItemQuantity { get; set; }
        public string ItemCreationDate { get; set; }
        public string ItemUpdateDate { get; set; }
    }
}
