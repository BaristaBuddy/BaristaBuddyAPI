﻿// <auto-generated />
using BaristaBuddyApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaristaBuddyApi.Migrations
{
    [DbContext(typeof(BaristaBuddyDbContext))]
    [Migration("20200602002202_SeededTwoMoreStores")]
    partial class SeededTwoMoreStores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaristaBuddyApi.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Store");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Iowa City",
                            Name = "Matt's Place",
                            State = "Iowa",
                            StreetAddress = "1918 H St.",
                            Zip = "52240"
                        },
                        new
                        {
                            Id = 2,
                            City = "Cedar Rapids",
                            Name = "Roastopia",
                            State = "Iowa",
                            StreetAddress = "1313 1st Ave.",
                            Zip = "52240"
                        },
                        new
                        {
                            Id = 3,
                            City = "Des Moines",
                            Name = "King Keith's Cafe",
                            State = "Iowa",
                            StreetAddress = "121 Dodge St.",
                            Zip = "52240"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}