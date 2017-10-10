using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2), Required]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 2), Required]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        [Range(0,999)]
        [DataType(DataType.Currency), Required]
        public decimal Price { get; set; }

        [StringLength(60, MinimumLength = 2)]
        public string Color { get; set; }



        public virtual Store Stores {get;set;}
    }
}