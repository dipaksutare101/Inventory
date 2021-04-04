using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory.Entity;
namespace Inventory.DAL
{
    public class InventoryDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<Saledetail>().ToTable("Saledetail");
            modelBuilder.Entity<Registration>().ToTable("Registration");
            modelBuilder.Entity<City>().ToTable("city");
        }
        public DbSet<Sale> sales { get; set; }
        public DbSet<Saledetail> saledetails { get; set; }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<City> cities { get; set; }
    }
}