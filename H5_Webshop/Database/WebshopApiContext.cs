using Castle.Core.Resource;
using H5_Webshop.DTOs.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5_Webshop.Database
{
    public class WebshopApiContext:DbContext
    {
        public WebshopApiContext() { }
        public WebshopApiContext(DbContextOptions<WebshopApiContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          
            modelBuilder.Entity<Category>().HasData(
               new()
               {
                   Id = 1,
                   CategoryName = "Toy"


               },
               new()
               {
                   Id = 2,
                   CategoryName = "T-Shirt"
               }
               );
            modelBuilder.Entity<Product>().HasData(
                new()
                {
                    Id = 1,
                    Title = " Kids Microwave",
                    Price = 299.99M,
                    Description = "Kids Toys",
                    Image = "microwave.jpg",
                    Stock = 10,
                    CategoryId = 1

                },

                new()
                {
                    Id = 2,
                    Title = "Blue T-Shirt",
                    Price = 199.99M,
                    Description = "T-Shirt for boys",
                    Image = "BlueTShirt.jpg",
                    Stock = 10,
                    CategoryId = 2

                },

                new()
                {
                    Id = 3,
                    Title = " Kids Motorcycle",
                    Price = 599.99M,
                    Description = "Kids Toys",
                    Image = "motorcycle.jpg",
                    Stock = 10,
                    CategoryId = 1

                },
                new()
                {
                    Id = 4,
                    Title = " BabySofa",
                    Price = 399.99M,
                    Description = "Soft Baby Sofa for Babies",
                    Image = "BabySofa.jpg",
                    Stock = 10,
                    CategoryId = 1

                },
                new()
                {
                    Id = 5,
                    Title = "Red T-Shirt",
                    Price = 199.99M,
                    Description = "T-Shirt for kids",
                    Image = "RedT-Shirt.jpg",
                    Stock = 10,
                    CategoryId = 2

                }
              );







        }
    }
}
