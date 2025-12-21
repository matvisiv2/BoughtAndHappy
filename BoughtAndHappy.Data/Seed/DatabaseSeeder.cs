using BoughtAndHappy.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BoughtAndHappy.Data.Seed
{
    public static class DatabaseSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return; // already seeded
            }

            var products = new List<Product>
            {
                new() { Id = 1, Name = "Smartphone", Price = 699, Category = ProductCategories.Electronics, Stock = 20 },
                new() { Id = 2, Name = "Tablet", Price = 399, Category = ProductCategories.Electronics, Stock = 15 },
                new() { Id = 3, Name = "Smart TV", Price = 899, Category = ProductCategories.Electronics, Stock = 8 },
                new() { Id = 4, Name = "Bluetooth Speaker", Price = 59, Category = ProductCategories.Electronics, Stock = 40 },
                new() { Id = 5, Name = "Wireless Headphones", Price = 129, Category = ProductCategories.Electronics, Stock = 30 },
                new() { Id = 6, Name = "Power Bank", Price = 39, Category = ProductCategories.Electronics, Stock = 50 },
                new() { Id = 7, Name = "Smart Watch", Price = 199, Category = ProductCategories.Electronics, Stock = 25 },

                // Clothing
                new() { Id = 8, Name = "T-Shirt", Price = 15, Category = ProductCategories.Clothing, Stock = 100 },
                new() { Id = 9, Name = "Jeans", Price = 49, Category = ProductCategories.Clothing, Stock = 60 },
                new() { Id = 10, Name = "Hoodie", Price = 39, Category = ProductCategories.Clothing, Stock = 40 },
                new() { Id = 11, Name = "Jacket", Price = 89, Category = ProductCategories.Clothing, Stock = 25 },
                new() { Id = 12, Name = "Sneakers", Price = 79, Category = ProductCategories.Clothing, Stock = 30 },
                new() { Id = 13, Name = "Cap", Price = 12, Category = ProductCategories.Clothing, Stock = 70 },
                new() { Id = 14, Name = "Socks Pack", Price = 10, Category = ProductCategories.Clothing, Stock = 120 },

                // HomeGoods
                new() { Id = 15, Name = "Coffee Maker", Price = 99, Category = ProductCategories.HomeGoods, Stock = 20 },
                new() { Id = 16, Name = "Vacuum Cleaner", Price = 199, Category = ProductCategories.HomeGoods, Stock = 10 },
                new() { Id = 17, Name = "Desk Lamp", Price = 29, Category = ProductCategories.HomeGoods, Stock = 35 },
                new() { Id = 18, Name = "Electric Kettle", Price = 49, Category = ProductCategories.HomeGoods, Stock = 30 },
                new() { Id = 19, Name = "Toaster", Price = 39, Category = ProductCategories.HomeGoods, Stock = 25 },
                new() { Id = 20, Name = "Air Humidifier", Price = 59, Category = ProductCategories.HomeGoods, Stock = 18 },
                new() { Id = 21, Name = "Iron", Price = 45, Category = ProductCategories.HomeGoods, Stock = 22 },

                // Books
                new() { Id = 22, Name = "C# Programming Guide", Price = 35, Category = ProductCategories.Books, Stock = 40 },
                new() { Id = 23, Name = "ASP.NET Core in Action", Price = 45, Category = ProductCategories.Books, Stock = 25 },
                new() { Id = 24, Name = "Clean Code", Price = 39, Category = ProductCategories.Books, Stock = 30 },
                new() { Id = 25, Name = "Design Patterns", Price = 49, Category = ProductCategories.Books, Stock = 20 },
                new() { Id = 26, Name = "Refactoring", Price = 44, Category = ProductCategories.Books, Stock = 18 },
                new() { Id = 27, Name = "Domain-Driven Design", Price = 55, Category = ProductCategories.Books, Stock = 15 },
                new() { Id = 28, Name = "Algorithms Handbook", Price = 42, Category = ProductCategories.Books, Stock = 22 },

                // Toys
                new() { Id = 29, Name = "Lego Set", Price = 59, Category = ProductCategories.Toys, Stock = 30 },
                new() { Id = 30, Name = "Toy Car", Price = 14, Category = ProductCategories.Toys, Stock = 80 },
                new() { Id = 31, Name = "Doll", Price = 25, Category = ProductCategories.Toys, Stock = 40 },
                new() { Id = 32, Name = "Puzzle 1000 pcs", Price = 19, Category = ProductCategories.Toys, Stock = 35 },
                new() { Id = 33, Name = "Board Game", Price = 34, Category = ProductCategories.Toys, Stock = 28 },
                new() { Id = 34, Name = "RC Helicopter", Price = 89, Category = ProductCategories.Toys, Stock = 12 },
                new() { Id = 35, Name = "Action Figure", Price = 22, Category = ProductCategories.Toys, Stock = 45 },

                // Groceries
                new() { Id = 36, Name = "Milk 1L", Price = 2, Category = ProductCategories.Groceries, Stock = 200 },
                new() { Id = 37, Name = "Bread", Price = 1.5m, Category = ProductCategories.Groceries, Stock = 150 },
                new() { Id = 38, Name = "Eggs 10 pcs", Price = 3, Category = ProductCategories.Groceries, Stock = 120 },
                new() { Id = 39, Name = "Cheese", Price = 6, Category = ProductCategories.Groceries, Stock = 80 },
                new() { Id = 40, Name = "Chicken Breast", Price = 7, Category = ProductCategories.Groceries, Stock = 60 },
                new() { Id = 41, Name = "Rice 1kg", Price = 2.5m, Category = ProductCategories.Groceries, Stock = 140 },
                new() { Id = 42, Name = "Pasta", Price = 1.8m, Category = ProductCategories.Groceries, Stock = 160 },

                // HealthAndBeauty
                new() { Id = 43, Name = "Shampoo", Price = 8, Category = ProductCategories.HealthAndBeauty, Stock = 70 },
                new() { Id = 44, Name = "Conditioner", Price = 8, Category = ProductCategories.HealthAndBeauty, Stock = 65 },
                new() { Id = 45, Name = "Toothpaste", Price = 3, Category = ProductCategories.HealthAndBeauty, Stock = 120 },
                new() { Id = 46, Name = "Body Lotion", Price = 10, Category = ProductCategories.HealthAndBeauty, Stock = 50 },
                new() { Id = 47, Name = "Face Cream", Price = 15, Category = ProductCategories.HealthAndBeauty, Stock = 40 },
                new() { Id = 48, Name = "Hand Soap", Price = 2.5m, Category = ProductCategories.HealthAndBeauty, Stock = 150 },
                new() { Id = 49, Name = "Vitamin C", Price = 12, Category = ProductCategories.HealthAndBeauty, Stock = 55 },

                // SportsAndOutdoors
                new() { Id = 50, Name = "Football", Price = 25, Category = ProductCategories.SportsAndOutdoors, Stock = 30 },
                new() { Id = 51, Name = "Basketball", Price = 27, Category = ProductCategories.SportsAndOutdoors, Stock = 28 },
                new() { Id = 52, Name = "Yoga Mat", Price = 20, Category = ProductCategories.SportsAndOutdoors, Stock = 45 },
                new() { Id = 53, Name = "Dumbbells Set", Price = 60, Category = ProductCategories.SportsAndOutdoors, Stock = 18 },
                new() { Id = 54, Name = "Tennis Racket", Price = 75, Category = ProductCategories.SportsAndOutdoors, Stock = 15 },
                new() { Id = 55, Name = "Camping Tent", Price = 120, Category = ProductCategories.SportsAndOutdoors, Stock = 10 },
                new() { Id = 56, Name = "Sleeping Bag", Price = 45, Category = ProductCategories.SportsAndOutdoors, Stock = 22 },

                // Automotive
                new() { Id = 57, Name = "Car Battery", Price = 110, Category = ProductCategories.Automotive, Stock = 12 },
                new() { Id = 58, Name = "Engine Oil", Price = 35, Category = ProductCategories.Automotive, Stock = 40 },
                new() { Id = 59, Name = "Windshield Wipers", Price = 18, Category = ProductCategories.Automotive, Stock = 50 },
                new() { Id = 60, Name = "Car Vacuum Cleaner", Price = 45, Category = ProductCategories.Automotive, Stock = 25 },
                new() { Id = 61, Name = "Tire Pressure Gauge", Price = 12, Category = ProductCategories.Automotive, Stock = 60 },
                new() { Id = 62, Name = "Jump Starter", Price = 90, Category = ProductCategories.Automotive, Stock = 14 },
                new() { Id = 63, Name = "Car Phone Holder", Price = 15, Category = ProductCategories.Automotive, Stock = 70 },

                // ComputersAndLaptops
                new() { Id = 64, Name = "Laptop", Price = 900, Category = ProductCategories.ComputersAndLaptops, Stock = 10 },
                new() { Id = 65, Name = "Gaming PC", Price = 1500, Category = ProductCategories.ComputersAndLaptops, Stock = 6 },
                new() { Id = 66, Name = "Mechanical Keyboard", Price = 120, Category = ProductCategories.ComputersAndLaptops, Stock = 20 },
                new() { Id = 67, Name = "Wireless Mouse", Price = 40, Category = ProductCategories.ComputersAndLaptops, Stock = 35 },
                new() { Id = 68, Name = "27\" Monitor", Price = 300, Category = ProductCategories.ComputersAndLaptops, Stock = 14 },
                new() { Id = 69, Name = "USB-C Hub", Price = 45, Category = ProductCategories.ComputersAndLaptops, Stock = 50 },
                new() { Id = 70, Name = "External SSD 1TB", Price = 150, Category = ProductCategories.ComputersAndLaptops, Stock = 18 },

                // Others
                new() { Id = 71, Name = "Gift Card", Price = 50, Category = ProductCategories.Others, Stock = 100 },
                new() { Id = 72, Name = "Notebook", Price = 5, Category = ProductCategories.Others, Stock = 200 },
                new() { Id = 73, Name = "Pen Set", Price = 7, Category = ProductCategories.Others, Stock = 180 },
                new() { Id = 74, Name = "Backpack", Price = 45, Category = ProductCategories.Others, Stock = 35 },
                new() { Id = 75, Name = "Travel Mug", Price = 18, Category = ProductCategories.Others, Stock = 60 }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public static async Task SeedAdminAndUsersAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var admin = await userManager.FindByEmailAsync("admin@site.com");
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin@site.com",
                    Email = "admin@site.com"
                };

                await userManager.CreateAsync(admin, "Admin123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            var userSneekers = await userManager.FindByEmailAsync("Sneekers@gmail.com");
            if (userSneekers == null)
            {
                var users = new[]
                {
                    new {Email = "Sneekers@gmail.com", Password = "Sneekers@gmail.com"},
                    new {Email = "Mars@gmail.com", Password = "Mars@gmail.com"},
                    new {Email = "Bounty@gmail.com", Password = "Bounty@gmail.com"}
                };

                foreach (var u in users)
                {
                    var user = await userManager.FindByEmailAsync(u.Email);
                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = u.Email,
                            Email = u.Email,
                            EmailConfirmed = true
                        };

                        await userManager.CreateAsync(user, u.Password);
                    }
                }
            }
        }
    }
}
