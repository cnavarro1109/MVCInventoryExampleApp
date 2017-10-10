using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.ViewModels
{
    public class StoreManagementViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}