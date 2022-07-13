using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop.Models;

namespace WebShop.Data
{
    


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Product>().HasData
        //        (
        //            new Product
        //            {
        //                Id = 1,
        //                ProductName = "Test Product" //priprema
        //            }
        //        );
        //    base.OnModelCreating(builder);
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

    }
}