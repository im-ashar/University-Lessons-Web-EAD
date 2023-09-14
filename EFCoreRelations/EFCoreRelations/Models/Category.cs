using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelations.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        //One to many relation with Product. Kue kay aik category mai bhut si products aa skti hain
        //For example Accessories mai charger, handfree wagairah ajain gay, Home Appliances mai
        //washing machine,Oven wagairah ajain gay, Gadgets mai laptop, mobile ajain gay.
        public virtual List<Product> Products { get; set; }
        //one to one with category detail 
        public virtual CategoryDetail CategoryDetail { get; set; }
    }
}
