namespace EFCoreRelations.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set;}

        //Many to many relation with Product. Kue kay aik company bhut si products bana skti hai
        //For example Xaoimi woo mobile bhi banty hain, charger bhi, LEDs bhi.
        public virtual List<Product> Products { get; set; }
    }
}
