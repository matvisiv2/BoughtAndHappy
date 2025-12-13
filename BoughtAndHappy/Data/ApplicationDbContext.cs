using BoughtAndHappy.Models;
using Microsoft.EntityFrameworkCore;

namespace BoughtAndHappy.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext() => Database.EnsureCreated();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Database=BoughtAndHappyDb;Username=postgresql;Password=postgresql");
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<Product> Products => Set<Product>();
        public DbSet<Product> Products { get; set; }
    }
}
