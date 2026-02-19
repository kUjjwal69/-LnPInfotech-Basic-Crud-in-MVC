using LnP_Infotech_ujjwal_Kumar.Models;
using Microsoft.EntityFrameworkCore;

namespace LnP_Infotech_ujjwal_Kumar.DATA
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
