﻿// <auto-generated />
using System;
using BaristaBuddyApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaristaBuddyApi.Migrations
{
    [DbContext(typeof(BaristaBuddyDbContext))]
    [Migration("20200602162738_AddStoreModifierSeedData")]
    partial class AddStoreModifierSeedData
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
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("StoreModifierModifierId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreModifierStoreId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "StoreId");

                    b.HasIndex("StoreModifierModifierId", "StoreModifierStoreId");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            StoreId = 1,
                            Ingredients = "Almond Milk, Cocoa nibs, Honey, Cinnamon",
                            Name = "Brennan's Hot Chocolate",
                            Price = 3.1299999999999999
                        },
                        new
                        {
                            ItemId = 2,
                            StoreId = 1,
                            Name = "Matt's Espresso Macchiato",
                            Price = 4.1699999999999999
                        },
                        new
                        {
                            ItemId = 3,
                            StoreId = 2,
                            Name = "Sihem's Caramel Latte",
                            Price = 4.0
                        },
                        new
                        {
                            ItemId = 4,
                            StoreId = 3,
                            Ingredients = "Enough caffiene to kill a small horse",
                            Name = "James's Triple Death",
                            Price = 6.6600000000000001
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

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemStoreId")
                        .HasColumnType("int");

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

                    b.Property<int?>("StoreModifierModifierId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreModifierStoreId")
                        .HasColumnType("int");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId", "ItemStoreId");

                    b.HasIndex("StoreModifierModifierId", "StoreModifierStoreId");

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
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModifierId", "StoreId");

                    b.ToTable("StoreModifier");

                    b.HasData(
                        new
                        {
                            ModifierId = 1,
                            StoreId = 1,
                            Name = "Mint"
                        },
                        new
                        {
                            ModifierId = 2,
                            StoreId = 1,
                            Name = "Espresso Shot"
                        },
                        new
                        {
                            ModifierId = 3,
                            StoreId = 2,
                            Name = "Caramel"
                        });
                });

            modelBuilder.Entity("BaristaBuddyApi.Models.Item", b =>
                {
                    b.HasOne("BaristaBuddyApi.Models.StoreModifier", null)
                        .WithMany("Items")
                        .HasForeignKey("StoreModifierModifierId", "StoreModifierStoreId");
                });

            modelBuilder.Entity("BaristaBuddyApi.Models.Store", b =>
                {
                    b.HasOne("BaristaBuddyApi.Models.Item", null)
                        .WithMany("Stores")
                        .HasForeignKey("ItemId", "ItemStoreId");

                    b.HasOne("BaristaBuddyApi.Models.StoreModifier", null)
                        .WithMany("Stores")
                        .HasForeignKey("StoreModifierModifierId", "StoreModifierStoreId");
                });
#pragma warning restore 612, 618
        }
    }
}