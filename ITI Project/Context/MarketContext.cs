using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Context
{
    public class MarketContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITIProject;Trusted_Connection=True;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new User { UserId = 1, FirstName = "Ahmed"  , LastName = "Salah"  , Email = "ahmedsalah@gmail.com"  , Password = "as1234" },
                new User { UserId = 2, FirstName = "Mohamed", LastName = "Reda"   , Email = "mohamedreda@gmail.com" , Password = "mr1234" },
                new User { UserId = 3, FirstName = "Ziad"   , LastName = "Tamer"  , Email = "ziadtamer@gmail.com"   , Password = "zt1234" },
                new User { UserId = 4, FirstName = "Mahmoud", LastName = "Reda"   , Email = "mahmoudreda@gmail.com" , Password = "mr1234" },
                new User { UserId = 5, FirstName = "Ayman"  , LastName = "Mohamed", Email = "aymanmohamed@gmail.com", Password = "am1234" }
            };

            var categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Clothes"    , Description = "Modern clothes for men, women and kids."                      },
                new Category { CategoryId = 2, Name = "Beauty"     , Description = "Still young with our amazing skin and hair care products."    },
                new Category { CategoryId = 3, Name = "Electronics", Description = "Don't miss AI features with our laptops, tablets and mobiles."}
            };

            var products = new List<Product>
            {
                new Product { ProductId = 1, Title = "T-Shirt" , Description = "Cotton T-Shirt for men"                          , Price = 150.40M  , Quantity = 10, CategoryId = 1 },
                new Product { ProductId = 2, Title = "Trousers", Description = "Jeans trousers for boys"                         , Price = 180.00M  , Quantity = 8 , CategoryId = 1 },
                new Product { ProductId = 3, Title = "Shampoo" , Description = "Argan oil shampoo for curly hair"                , Price = 50.70M   , Quantity = 7 , CategoryId = 2 },
                new Product { ProductId = 4, Title = "Cleanser", Description = "Cleanser with salicylic acid for acne prone skin", Price = 82.45M   , Quantity = 20, CategoryId = 2 },
                new Product { ProductId = 5, Title = "Mobile"  , Description = "Modern mobile with 5G network"                   , Price = 12500.00M, Quantity = 11, CategoryId = 3 },
                new Product { ProductId = 6, Title = "Laptop"  , Description = "Laptop with 16GB Ram, 512GB SSD, RTX 3060"       , Price = 33650.00M, Quantity = 6 , CategoryId = 3 }
            };

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product>  Products { get; set; }
    }
}
