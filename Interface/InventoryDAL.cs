using Inventory.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL
{
    public class InventoryDAL : DbContext
    {
        public InventoryDAL() : base("name=InventoryDAL")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<Saledetail>().ToTable("Saledetail");
            modelBuilder.Entity<Registration>().ToTable("Registration");
            modelBuilder.Entity<City>().ToTable("city");
            modelBuilder.Entity<Image_Table>().ToTable("Image_Table");
        }
        public DbSet<Sale> sales { get; set; }
        public DbSet<Saledetail> saledetails { get; set; }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Image_Table> Image_Tables { get; set; }
    }
}
