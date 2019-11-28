using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BindingLesson
{
    public class Context : DbContext
    {
        public Context() { Database.EnsureCreated(); }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=A-104-09;Database=ShopDb;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product 
            {
                Name = "Helb", Price = 100, Count = 10,
            },
            new Product
            {
                Name = "Mylo", Price = 100, Count = 12
            },
            new Product
            {
                Name = "Verevka", Price = 100, Count = 13
            }
            );
        }
    }
}
