using InventoryControl.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace InventoryControl.DAL
{
    public class InventoryContext: DbContext
    {

        public InventoryContext() : base("InventoryContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}