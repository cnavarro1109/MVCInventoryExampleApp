using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.ViewModels
{
    public class EmployeesDetailsViewModel
    {
        //This will hold one store
        public Store Store { get; set; }

        //This will hold many inventory items
        public List<Inventory> Inventories { get; set; }
        

    }
}