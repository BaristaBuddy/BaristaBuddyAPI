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
    [Migration("20200602195705_CleanSlate")]
    partial class CleanSlate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaristaBuddyApi.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("StoreId");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Ingredients = "Almond Milk, Cocoa nibs, Honey, Cinnamon",
                            Name = "Brennan's Hot Chocolate",
                            Price = 3.1299999999999999,
                            StoreId = 1
                        },
                        new
                        {
                            ItemId = 2,
                            Name = "Matt's Espresso Macchiato",
                            Price = 4.1699999999999999,
                            StoreId = 1
                        },
                        new
                        {
                            ItemId = 3,
                            Name = "Sihem's Caramel Latte",
                            Price = 4.0,
                            StoreId = 2
                        },
                        new
                        {
                            ItemId = 4,
                            Ingredients = "Enough caffiene to kill a small horse",
                            Name = "James's Triple Death",
                            Price = 6.6600000000000001,
                            StoreId = 3
                        });
                });

            modelBuilder.Entity("BaristaBuddyApi.Models.ItemModifier", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ModifierId")
                        .HasColumnType("int");

                    b.Property<double>("AdditionalCost")
                        .HasColumnType("float");

                    b.HasKey("ItemId", "ModifierId");

                    b.HasIndex("ModifierId");

                    b.ToTable("itemModifier");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            ModifierId = 1,
                            AdditionalCost = 0.75
                        },
                        new
                        {
                            ItemId = 4,
                            ModifierId = 2,
                            AdditionalCost = 1.5
                        },
                        new
                        {
                            ItemId = 3,
                            ModifierId = 3,
                            AdditionalCost = 0.75
                        });
                });

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

            modelBuilder.Entity("BaristaBuddyApi.Models.StoreModifier", b =>
                {
                    b.Property<int>("ModifierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("ModifierId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreModifier");

                    b.HasData(
                        new
                        {
                            ModifierId = 1,
                            Name = "Mint",
                            StoreId = 1
                        },
                        new
                        {
                            ModifierId = 2,
                            Name = "Espresso Shot",
                            StoreId = 1
                        },
                        new
                        {
                            ModifierId = 3,
                            Name = "Caramel",
                            StoreId = 2
                        });
                });

            modelBuilder.Entity("BaristaBuddyApi.Models.Item", b =>
                {
                    b.HasOne("BaristaBuddyApi.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BaristaBuddyApi.Models.ItemModifier", b =>
                {
                    b.HasOne("BaristaBuddyApi.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaristaBuddyApi.Models.StoreModifier", "Modifier")
                        .WithMany("Items")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BaristaBuddyApi.Models.StoreModifier", b =>
                {
                    b.HasOne("BaristaBuddyApi.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
