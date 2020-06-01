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
                new Store { Id = 1, City = "iowa city", State = "iowa", Name = "matt's Place", StreetAddress = "1918 H st", Zip = "52240" }
                
                );

        }

        public DbSet<Store> Store { get; set; }
    }
}
