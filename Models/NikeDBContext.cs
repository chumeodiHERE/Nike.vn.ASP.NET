using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nike_vn.Models
{
    public class NikeDBContext : DbContext
    {
        public NikeDBContext() : base("NikeConnectionString") { }
        public DbSet<Apparel> Apparels { get; set; }
        public DbSet<ProductGender> ProductGenders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}