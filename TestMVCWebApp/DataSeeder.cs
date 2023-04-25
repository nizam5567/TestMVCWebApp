using TestMVCWebApp.Data;
using TestMVCWebApp.Models;

namespace TestMVCWebApp
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
            context.Database.EnsureCreated();
            AddProducts(context);
        }

        private static void AddProducts(ProductDbContext context)
        {
            var product = context.Products.FirstOrDefault();
            if (product != null) return;

            context.Products.Add(new Product
            {
                Name = "Product Name 1",
                Description = "Product Description 1",
                Price = 20                
            });
            

            context.SaveChanges();
        }
    }
}
