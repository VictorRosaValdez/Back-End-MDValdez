using MDValdez.Models;
using Microsoft.EntityFrameworkCore;

namespace MDValdez.Dal
{
    public class MDDbContext : DbContext
    {
        // Properties for creating the tables in the SSMS with the Entity Framework.

        // Table of Product
        public DbSet<Product> Product { get; set; }

        // Table of Order
        public DbSet<Order> Order { get; set; }

        // Table of Order
        public DbSet<Customer> Customer { get; set; }

        // Table of Order
        public DbSet<Account> Account { get; set; }

        // Table of ShoppingCart

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public MDDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            // Seeded data for Product
            modelBuilder.Entity<Product>().HasData(SeedHelper.GetProductsSeeds());

            // Seeded data for Account
            modelBuilder.Entity<Customer>().HasData(SeedHelper.GetAccoutsSeeds());

            // Seeded data for ShoppingCart
            modelBuilder.Entity<ShoppingCart>().HasData(SeedHelper.GetShoppingCartsSeeds());

            // Seeded data for Order
            modelBuilder.Entity<Order>().HasData(SeedHelper.GetOrdersSeeds());
        }
    }
}
