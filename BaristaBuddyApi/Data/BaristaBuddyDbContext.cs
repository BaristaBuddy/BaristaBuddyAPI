using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BaristaBuddyApi.Data
{
    public class BaristaBuddyDbContext : IdentityDbContext<BaristaBuddyUser>
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
                .HasKey(Item => Item.ItemId);

            modelBuilder.Entity<Item>()
                .HasData(
                new Item { ItemId = 1, StoreId = 1, Name = "Brennan's Hot Chocolate", Ingredients = "Almond Milk, Cocoa nibs, Honey, Cinnamon", Price = 3.13M },
                new Item { ItemId = 2, StoreId = 1, Name = "Matt's Espresso Macchiato", Price = 4.17M },
                new Item { ItemId = 3, StoreId = 2, Name = "Sihem's Caramel Latte", Price = 4.00M },
                new Item { ItemId = 4, StoreId = 3, Name = "James's Triple Death", Ingredients = "Enough caffiene to kill a small horse", Price = 6.66M }
                );

            modelBuilder.Entity<StoreModifier>()
                .HasKey(StoreModifier => StoreModifier.ModifierId);

            modelBuilder.Entity<StoreModifier>()
                .HasData(
                new StoreModifier { ModifierId = 1, StoreId = 1, Name = "Mint" },
                new StoreModifier { ModifierId = 2, StoreId = 1, Name = "Espresso Shot" },
                new StoreModifier { ModifierId = 3, StoreId = 2, Name = "Caramel" }
                );

            modelBuilder.Entity<ItemModifier>()
                .HasKey(ItemModifier => new
                {
                    ItemModifier.ItemId,
                    ItemModifier.ModifierId
                });

            modelBuilder.Entity<ItemModifier>()
                .HasData(
                new ItemModifier { ModifierId = 1, ItemId = 1, AdditionalCost = 0.75M },
                new ItemModifier { ModifierId = 2, ItemId = 4, AdditionalCost = 1.50M },
                new ItemModifier { ModifierId = 3, ItemId = 3, AdditionalCost = 0.75M }
                );

            modelBuilder.Entity<ItemSize>()
                .HasKey(ItemSize => new
                {
                    ItemSize.ItemId,
                    ItemSize.Size
                });

            modelBuilder.Entity<ItemSize>()
                .HasData(
                new ItemSize { ItemId = 1, Size = "Dwarf", AdditionalCost = 0M },
                new ItemSize { ItemId = 1, Size = "Human", AdditionalCost = 0.50M },
                new ItemSize { ItemId = 1, Size = "Giant", AdditionalCost = 1.00M },
                 new ItemSize { ItemId = 2, Size = "Dwarf", AdditionalCost = 0M },
                new ItemSize { ItemId = 2, Size = "Human", AdditionalCost = 0.50M },
                new ItemSize { ItemId = 2, Size = "Giant", AdditionalCost = 1.00M },
                 new ItemSize { ItemId = 3, Size = "Dwarf", AdditionalCost = 0M },
                new ItemSize { ItemId = 3, Size = "Human", AdditionalCost = 0.50M },
                new ItemSize { ItemId = 3, Size = "Giant", AdditionalCost = 1.00M },
                 new ItemSize { ItemId = 4, Size = "Dwarf", AdditionalCost = 0M },
                new ItemSize { ItemId = 4, Size = "Human", AdditionalCost = 0.50M },
                new ItemSize { ItemId = 4, Size = "Giant", AdditionalCost = 1.00M }
                );

         


        }

        public DbSet<Store> Store { get; set; }
        public DbSet<Item> Item { get; set; }

        public DbSet<StoreModifier> StoreModifier { get; set; }

        public DbSet<ItemModifier> itemModifier { get; set; }
        public DbSet<ItemSize> ItemSize { get; set; }
        public DbSet<BaristaBuddyUser> BaristaBuddyUser { get; set; }
    }
}
