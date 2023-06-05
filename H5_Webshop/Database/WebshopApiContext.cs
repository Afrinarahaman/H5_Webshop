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
                   CategoryName = "Kids"


               },
               new()
               {
                   Id = 2,
                   CategoryName = "Men"
               }
               );
            modelBuilder.Entity<Product>().HasData(
                new()
                {
                    Id = 1,
                    Title = " Fency dress",
                    Price = 299.99M,
                    Description = "kids dress",
                    Image = "dress1.jpg",
                    Stock = 10,
                    CategoryId = 1

                },

                new()
                {
                    Id = 2,
                    Title = "Blue T-Shirt",
                    Price = 199.99M,
                    Description = "T-Shirt for nen",
                    Image = "BlueTShirt.jpg",
                    Stock = 10,
                    CategoryId = 2

                },

                new()
                {
                    Id = 3,
                    Title = " Skirt",
                    Price = 159.99M,
                    Description = "Girls skirt",
                    Image = "skirt1.jpg",
                    Stock = 10,
                    CategoryId = 1

                },
                new()
                {
                    Id = 4,
                    Title = " Jumpersuit",
                    Price = 279.99M,
                    Description = "kids jumpersuit",
                    Image = "jumpersuit1.jpg",
                    Stock = 10,
                    CategoryId = 1

                },
                new()
                {
                    Id = 5,
                    Title = "Red T-Shirt",
                    Price = 199.99M,
                    Description = "T-Shirt for men",
                    Image = "RedT-Shirt.jpg",
                    Stock = 10,
                    CategoryId = 2

                }
              );







        }
    }
}
