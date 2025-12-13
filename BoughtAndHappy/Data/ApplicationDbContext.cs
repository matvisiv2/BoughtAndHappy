using Microsoft.EntityFrameworkCore;
using BoughtAndHappy.Models;

namespace BoughtAndHappy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        //public DbSet<Product> Products { get; set; }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasPostgresEnum<ProductCategories>();

            modelBuilder.Entity<Product>()
                .Property(p => p.Category)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 500,
                    Category = ProductCategories.ComputersAndLaptops,
                    Stock = 5
                },
                new Product
                {
                    Id = 2,
                    Name = "T-shirt",
                    Price = 10,
                    Category = ProductCategories.Clothing,
                    Stock = 50
                }
            );
        }
    }
}
