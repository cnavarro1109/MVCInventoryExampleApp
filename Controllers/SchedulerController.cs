using InventoryApp.Data;
using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class SchedulerController : Controller
    {

        private InventoryContext db = new InventoryContext();

        // GET: Scheduler
        public ActionResult Index()
        {
            return View();
        }

        // To retrieve the appointments from database and bind it to Scheduler
        public JsonResult GetData()
        {
            var datasource = db.Schedules.ToList();
            return Json(datasource, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveData(Scheduler value)
        {
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}