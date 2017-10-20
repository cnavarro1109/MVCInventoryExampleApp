using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }

        //[DataType(DataType.Time)]
        //public TimeSpan TimeOpen { get; set; }

        public int EmployeeID { get; set; }

        public int Rating { get; set; }

        //Set the ForeignKey
        [ForeignKey("EmployeeID")]
        public virtual Employee employee { get; set; }
    }
}