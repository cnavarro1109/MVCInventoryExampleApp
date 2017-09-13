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

        public DbSet<Inventory> Inventories { get; set; }
    }
}