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
            var DataSourceStores = db.Stores.ToList();

            var DataSourceInventory = from Inventory in db.Inventories
                                      select new
                                      {
                                          Store_Id = Inventory.Stores.Id,
                                          Name = Inventory.Name,
                                          Description = Inventory.Description
                                      };

            ViewBag.datasourceStores = DataSourceStores;
            ViewBag.datasourceInventory = DataSourceInventory.ToList();

            return View();

        }
    }
}