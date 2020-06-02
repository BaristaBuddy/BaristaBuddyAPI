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

        }

        public DbSet<Store> Store { get; set; }
    }
}
