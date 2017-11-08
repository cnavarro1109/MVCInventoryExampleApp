using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryApp.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext() : base("DefaultConnection") { }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        //Inventory Table to assign to each store individually
        public DbSet<StoreCategory> Categories { get; set; }

    }
}