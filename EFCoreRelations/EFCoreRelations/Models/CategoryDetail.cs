using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelations.Models
{
    public class CategoryDetail
    {
        //yay column ab primary key or foreign key category table k liay bhi act kray ga
        [Key, ForeignKey("Category")]
        public Guid CategoryDetailId { get; set; }
        public string CategoryDetailInfo { get; set; }

        //navigation property hai
        public virtual Category Category { get; set; }
    }
}
