using InventoryApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class DetailReportController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: DetailReport
        public ActionResult Index()
        {
            //Get a list of stores
            ViewBag.Stores = db.Stores.ToList();

            return View();
        }

        public ActionResult EmployeeReport()
        {
            var DataSource = db.Employees.ToList();
            ViewBag.datasource = DataSource;
            return View();
        }

        public ActionResult InventoryPerStore()
        {
            //This is the initial Grid
            var DataSourceStores = db.Stores.ToList();

            //This is the details view - Hold the inventory per store
            var DataSourceInventory = (from Inventory in db.Inventories
                                      select new
                                      {
                                          Store_Id = Inventory.Stores.Id,
                                          Name = Inventory.Name,
                                          Description = Inventory.Description,
                                          Price = Inventory.Price
                                      }).ToList();

            //Used to populate any controller when called from the view

            ViewBag.datasourceStores = DataSourceStores; //For the parent Grid

            ViewBag.datasourceInventory = DataSourceInventory; //For the Details/Child Grid

            return View();

        }
    }
}