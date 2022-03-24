using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CAIBT.Models;

namespace CAIBT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CAIBT.Models.Order> Orders { get; set; }

        public DbSet<CAIBT.Models.OrderDetails> OrderDetails { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
