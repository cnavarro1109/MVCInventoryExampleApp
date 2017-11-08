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
    }
}