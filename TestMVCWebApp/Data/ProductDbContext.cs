using TestMVCWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TestMVCWebApp.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Product> Products { get; set; }
    }
}
