using Microsoft.EntityFrameworkCore;

namespace EFCoreRelations.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetail> CategoriesDetail { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
