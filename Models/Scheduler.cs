using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Scheduler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}