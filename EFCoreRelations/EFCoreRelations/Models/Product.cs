namespace EFCoreRelations.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        //Yay one to many kay case mai bnti hai. Yay ab Foreign Key act kray gi
        //ab neechay hum iski Navigation property bhi bnain gay
        public Guid CategoryId { get; set; }

        //Many to many relation with Company. Kue kay aik product bhut si companies bna skti hain
        //For example Mobile aik product hai jo bhut si companies bnati hain.
        public virtual List<Company> Companies { get; set; }

        //Yay navigation property hai. One to many k liay. Kue kay koi aik product kisi aik Category
        //mai e hoo gi. For example Koi charger hai tw woo Accessories mai hoo ga
        public virtual Category Category { get; set; }
    }
}
