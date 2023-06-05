﻿// <auto-generated />
using H5_Webshop.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace H5_Webshop.Migrations
{
    [DbContext(typeof(WebshopApiContext))]
    [Migration("20230605073337_webshop")]
    partial class webshop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("H5_Webshop.DTOs.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Kids"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Men"
                        });
                });

            modelBuilder.Entity("H5_Webshop.DTOs.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<short>("Stock")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "kids dress",
                            Image = "dress1.jpg",
                            Price = 299.99m,
                            Stock = (short)10,
                            Title = " Fency dress"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "T-Shirt for nen",
                            Image = "BlueTShirt.jpg",
                            Price = 199.99m,
                            Stock = (short)10,
                            Title = "Blue T-Shirt"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Girls skirt",
                            Image = "skirt1.jpg",
                            Price = 159.99m,
                            Stock = (short)10,
                            Title = " Skirt"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "kids jumpersuit",
                            Image = "jumpersuit1.jpg",
                            Price = 279.99m,
                            Stock = (short)10,
                            Title = " Jumpersuit"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "T-Shirt for men",
                            Image = "RedT-Shirt.jpg",
                            Price = 199.99m,
                            Stock = (short)10,
                            Title = "Red T-Shirt"
                        });
                });

            modelBuilder.Entity("H5_Webshop.DTOs.Entities.Product", b =>
                {
                    b.HasOne("H5_Webshop.DTOs.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("H5_Webshop.DTOs.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}