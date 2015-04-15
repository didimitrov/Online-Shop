using System.Collections.Generic;
using MyOnlineShop.Models;

namespace MyOnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyOnlineShop.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MyOnlineShop.Data.ApplicationDbContext";
        }

        protected override void Seed(MyOnlineShop.Data.ApplicationDbContext context)
        {
             var categories = new List<Category>
            {
                new Category { Name = "Games" },
                new Category { Name = "Movies" },
                new Category { Name = "IT" },
             
            };



            new List<Product>
            {
                new Product
                {
                    Title = "A Copland Celebration, Vol. I",
                    Category = categories.Single(g => g.Name == "Games"),
                    Price = 8.99M
                },
                new Product {Title = "Worlds", Category = categories.Single(g => g.Name == "Games"), Price = 8.99M},
                // AlbumArtUrl = "/Content/Images/placeholder.gif"
                new Product
                {
                    Title = "For Those About To Rock We Salute You",
                    Category = categories.Single(g => g.Name == "Rock"),
                    Price = 8.99M
                },
                new Product
                {
                    Title = "Let There Be Rock",
                    Category = categories.Single(g => g.Name == "Games"),
                    Price = 8.99M
                },
                new Product
                {
                    Title = "Balls to the Wall",
                    Category = categories.Single(g => g.Name == "Games"),
                    Price = 8.99M
                },
                new Product
                {
                    Title = "Restless and Wild",
                    Category = categories.Single(g => g.Name == "Movies"),
                    Price = 8.99M
                },
                new Product
                {
                    Title = "Górecki: Symphony No. 3",
                    Category = categories.Single(g => g.Name == "Games"),
                    Price = 8.99M
                },
                new Product {Title = "Big Ones", Category = categories.Single(g => g.Name == "IT"), Price = 8.99M},
                new Product {Title = "Quiet Songs", Category = categories.Single(g => g.Name == "IT"), Price = 8.99M},
                new Product
                {
                    Title = "Jagged Little Pill",
                    Category = categories.Single(g => g.Name == "IT"),
                    Price = 8.99M
                },
                new Product {Title = "Facelift", Category = categories.Single(g => g.Name == "Movies"), Price = 8.99M},
                new Product {Title = "Frank", Category = categories.Single(g => g.Name == "Movies"), Price = 8.99M},
                new Product
                {
                    Title = "Ring My Bell",
                    Category = categories.Single(g => g.Name == "Movies"),
                    Price = 8.99M
                },
                new Product
                {
                    Title = "Chill: Brazil ",
                    Category = categories.Single(g => g.Name == "Games"),
                    Price = 8.99M
                },
                new Product
                {
                    Title = "Warner 25 Anos",
                    Category = categories.Single(g => g.Name == "Games"),
                    Price = 8.99M
                },

            }.ForEach(a => context.Products.Add(a));
        }
    }
}
