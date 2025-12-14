using Microsoft.EntityFrameworkCore;
using BoughtAndHappy.Models;

namespace BoughtAndHappy.DTO
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

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
                // Electronics
                new Product { Id = 1, Name = "Smartphone", Price = 699, Category = ProductCategories.Electronics, Stock = 20 },
                new Product { Id = 2, Name = "Tablet", Price = 399, Category = ProductCategories.Electronics, Stock = 15 },
                new Product { Id = 3, Name = "Smart TV", Price = 899, Category = ProductCategories.Electronics, Stock = 8 },
                new Product { Id = 4, Name = "Bluetooth Speaker", Price = 59, Category = ProductCategories.Electronics, Stock = 40 },
                new Product { Id = 5, Name = "Wireless Headphones", Price = 129, Category = ProductCategories.Electronics, Stock = 30 },
                new Product { Id = 6, Name = "Power Bank", Price = 39, Category = ProductCategories.Electronics, Stock = 50 },
                new Product { Id = 7, Name = "Smart Watch", Price = 199, Category = ProductCategories.Electronics, Stock = 25 },

                // Clothing
                new Product { Id = 8, Name = "T-Shirt", Price = 15, Category = ProductCategories.Clothing, Stock = 100 },
                new Product { Id = 9, Name = "Jeans", Price = 49, Category = ProductCategories.Clothing, Stock = 60 },
                new Product { Id = 10, Name = "Hoodie", Price = 39, Category = ProductCategories.Clothing, Stock = 40 },
                new Product { Id = 11, Name = "Jacket", Price = 89, Category = ProductCategories.Clothing, Stock = 25 },
                new Product { Id = 12, Name = "Sneakers", Price = 79, Category = ProductCategories.Clothing, Stock = 30 },
                new Product { Id = 13, Name = "Cap", Price = 12, Category = ProductCategories.Clothing, Stock = 70 },
                new Product { Id = 14, Name = "Socks Pack", Price = 10, Category = ProductCategories.Clothing, Stock = 120 },

                // HomeGoods
                new Product { Id = 15, Name = "Coffee Maker", Price = 99, Category = ProductCategories.HomeGoods, Stock = 20 },
                new Product { Id = 16, Name = "Vacuum Cleaner", Price = 199, Category = ProductCategories.HomeGoods, Stock = 10 },
                new Product { Id = 17, Name = "Desk Lamp", Price = 29, Category = ProductCategories.HomeGoods, Stock = 35 },
                new Product { Id = 18, Name = "Electric Kettle", Price = 49, Category = ProductCategories.HomeGoods, Stock = 30 },
                new Product { Id = 19, Name = "Toaster", Price = 39, Category = ProductCategories.HomeGoods, Stock = 25 },
                new Product { Id = 20, Name = "Air Humidifier", Price = 59, Category = ProductCategories.HomeGoods, Stock = 18 },
                new Product { Id = 21, Name = "Iron", Price = 45, Category = ProductCategories.HomeGoods, Stock = 22 },

                // Books
                new Product { Id = 22, Name = "C# Programming Guide", Price = 35, Category = ProductCategories.Books, Stock = 40 },
                new Product { Id = 23, Name = "ASP.NET Core in Action", Price = 45, Category = ProductCategories.Books, Stock = 25 },
                new Product { Id = 24, Name = "Clean Code", Price = 39, Category = ProductCategories.Books, Stock = 30 },
                new Product { Id = 25, Name = "Design Patterns", Price = 49, Category = ProductCategories.Books, Stock = 20 },
                new Product { Id = 26, Name = "Refactoring", Price = 44, Category = ProductCategories.Books, Stock = 18 },
                new Product { Id = 27, Name = "Domain-Driven Design", Price = 55, Category = ProductCategories.Books, Stock = 15 },
                new Product { Id = 28, Name = "Algorithms Handbook", Price = 42, Category = ProductCategories.Books, Stock = 22 },

                // Toys
                new Product { Id = 29, Name = "Lego Set", Price = 59, Category = ProductCategories.Toys, Stock = 30 },
                new Product { Id = 30, Name = "Toy Car", Price = 14, Category = ProductCategories.Toys, Stock = 80 },
                new Product { Id = 31, Name = "Doll", Price = 25, Category = ProductCategories.Toys, Stock = 40 },
                new Product { Id = 32, Name = "Puzzle 1000 pcs", Price = 19, Category = ProductCategories.Toys, Stock = 35 },
                new Product { Id = 33, Name = "Board Game", Price = 34, Category = ProductCategories.Toys, Stock = 28 },
                new Product { Id = 34, Name = "RC Helicopter", Price = 89, Category = ProductCategories.Toys, Stock = 12 },
                new Product { Id = 35, Name = "Action Figure", Price = 22, Category = ProductCategories.Toys, Stock = 45 },

                // Groceries
                new Product { Id = 36, Name = "Milk 1L", Price = 2, Category = ProductCategories.Groceries, Stock = 200 },
                new Product { Id = 37, Name = "Bread", Price = 1.5m, Category = ProductCategories.Groceries, Stock = 150 },
                new Product { Id = 38, Name = "Eggs 10 pcs", Price = 3, Category = ProductCategories.Groceries, Stock = 120 },
                new Product { Id = 39, Name = "Cheese", Price = 6, Category = ProductCategories.Groceries, Stock = 80 },
                new Product { Id = 40, Name = "Chicken Breast", Price = 7, Category = ProductCategories.Groceries, Stock = 60 },
                new Product { Id = 41, Name = "Rice 1kg", Price = 2.5m, Category = ProductCategories.Groceries, Stock = 140 },
                new Product { Id = 42, Name = "Pasta", Price = 1.8m, Category = ProductCategories.Groceries, Stock = 160 },

                // HealthAndBeauty
                new Product { Id = 43, Name = "Shampoo", Price = 8, Category = ProductCategories.HealthAndBeauty, Stock = 70 },
                new Product { Id = 44, Name = "Conditioner", Price = 8, Category = ProductCategories.HealthAndBeauty, Stock = 65 },
                new Product { Id = 45, Name = "Toothpaste", Price = 3, Category = ProductCategories.HealthAndBeauty, Stock = 120 },
                new Product { Id = 46, Name = "Body Lotion", Price = 10, Category = ProductCategories.HealthAndBeauty, Stock = 50 },
                new Product { Id = 47, Name = "Face Cream", Price = 15, Category = ProductCategories.HealthAndBeauty, Stock = 40 },
                new Product { Id = 48, Name = "Hand Soap", Price = 2.5m, Category = ProductCategories.HealthAndBeauty, Stock = 150 },
                new Product { Id = 49, Name = "Vitamin C", Price = 12, Category = ProductCategories.HealthAndBeauty, Stock = 55 },

                // SportsAndOutdoors
                new Product { Id = 50, Name = "Football", Price = 25, Category = ProductCategories.SportsAndOutdoors, Stock = 30 },
                new Product { Id = 51, Name = "Basketball", Price = 27, Category = ProductCategories.SportsAndOutdoors, Stock = 28 },
                new Product { Id = 52, Name = "Yoga Mat", Price = 20, Category = ProductCategories.SportsAndOutdoors, Stock = 45 },
                new Product { Id = 53, Name = "Dumbbells Set", Price = 60, Category = ProductCategories.SportsAndOutdoors, Stock = 18 },
                new Product { Id = 54, Name = "Tennis Racket", Price = 75, Category = ProductCategories.SportsAndOutdoors, Stock = 15 },
                new Product { Id = 55, Name = "Camping Tent", Price = 120, Category = ProductCategories.SportsAndOutdoors, Stock = 10 },
                new Product { Id = 56, Name = "Sleeping Bag", Price = 45, Category = ProductCategories.SportsAndOutdoors, Stock = 22 },

                // Automotive
                new Product { Id = 57, Name = "Car Battery", Price = 110, Category = ProductCategories.Automotive, Stock = 12 },
                new Product { Id = 58, Name = "Engine Oil", Price = 35, Category = ProductCategories.Automotive, Stock = 40 },
                new Product { Id = 59, Name = "Windshield Wipers", Price = 18, Category = ProductCategories.Automotive, Stock = 50 },
                new Product { Id = 60, Name = "Car Vacuum Cleaner", Price = 45, Category = ProductCategories.Automotive, Stock = 25 },
                new Product { Id = 61, Name = "Tire Pressure Gauge", Price = 12, Category = ProductCategories.Automotive, Stock = 60 },
                new Product { Id = 62, Name = "Jump Starter", Price = 90, Category = ProductCategories.Automotive, Stock = 14 },
                new Product { Id = 63, Name = "Car Phone Holder", Price = 15, Category = ProductCategories.Automotive, Stock = 70 },

                // ComputersAndLaptops
                new Product { Id = 64, Name = "Laptop", Price = 900, Category = ProductCategories.ComputersAndLaptops, Stock = 10 },
                new Product { Id = 65, Name = "Gaming PC", Price = 1500, Category = ProductCategories.ComputersAndLaptops, Stock = 6 },
                new Product { Id = 66, Name = "Mechanical Keyboard", Price = 120, Category = ProductCategories.ComputersAndLaptops, Stock = 20 },
                new Product { Id = 67, Name = "Wireless Mouse", Price = 40, Category = ProductCategories.ComputersAndLaptops, Stock = 35 },
                new Product { Id = 68, Name = "27\" Monitor", Price = 300, Category = ProductCategories.ComputersAndLaptops, Stock = 14 },
                new Product { Id = 69, Name = "USB-C Hub", Price = 45, Category = ProductCategories.ComputersAndLaptops, Stock = 50 },
                new Product { Id = 70, Name = "External SSD 1TB", Price = 150, Category = ProductCategories.ComputersAndLaptops, Stock = 18 },

                // Others
                new Product { Id = 71, Name = "Gift Card", Price = 50, Category = ProductCategories.Others, Stock = 100 },
                new Product { Id = 72, Name = "Notebook", Price = 5, Category = ProductCategories.Others, Stock = 200 },
                new Product { Id = 73, Name = "Pen Set", Price = 7, Category = ProductCategories.Others, Stock = 180 },
                new Product { Id = 74, Name = "Backpack", Price = 45, Category = ProductCategories.Others, Stock = 35 },
                new Product { Id = 75, Name = "Travel Mug", Price = 18, Category = ProductCategories.Others, Stock = 60 }
            );
        }
    }
}
