using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        //Data Transfer Objects For Customers

        public int? CustomerId{ get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerSalesLimit { get; set; }
        public string CustomerRegistrationDate { get; set; }
        public string CustomerAmountPayable { get; set; }
    }
}
