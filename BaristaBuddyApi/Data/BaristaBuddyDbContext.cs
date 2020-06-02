using BaristaBuddyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BaristaBuddyApi.Data
{
    public class BaristaBuddyDbContext : DbContext 
    {
        public BaristaBuddyDbContext (DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasData(
                new Store 
                {
                    Id = 1,
                    City = "Iowa City",
                    State = "Iowa",
                    Name = "Matt's Place",
                    StreetAddress = "1918 H St.",
                    Zip = "52240" 
                },
                new Store
                {
                    Id = 2,
                    City = "Cedar Rapids",
                    State = "Iowa",
                    Name = "Roastopia",
                    StreetAddress = "1313 1st Ave.",
                    Zip = "52240"
                },
                new Store
                {
                    Id = 3,
                    City = "Des Moines",
                    State = "Iowa",
                    Name = "King Keith's Cafe",
                    StreetAddress = "121 Dodge St.",
                    Zip = "52240"
                });
            modelBuilder.Entity<Item>()
                .HasKey(Item => new
                {
                    Item.ItemId,
                    Item.StoreId
                });
            modelBuilder.Entity<Item>()
                .HasData(
                new Item { ItemId = 1, StoreId = 1, Name = "Brennan's Hot Chocolate", Ingredients = "Almond Milk, Cocoa nibs, Honey, Cinnamon", Price = 3.13 },
                new Item { ItemId = 2, StoreId = 1, Name = "Matt's Espresso Macchiato", Price = 4.17 },
                new Item { ItemId = 3, StoreId = 2, Name = "Sihem's Caramel Latte", Price = 4.00 },
                new Item { ItemId = 4, StoreId = 3, Name = "James's Triple Death", Ingredients = "Enough caffiene to kill a small horse", Price = 6.66 }
                );

        }

        public DbSet<Store> Store { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
