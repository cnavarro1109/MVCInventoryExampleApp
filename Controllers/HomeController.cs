using InventoryApp.Data;
using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace InventoryApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateInventory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateInventory(Inventory model)
        {
            using(InventoryContext context = new InventoryContext())
            {
                context.Inventories.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("ShowInventory");
        }

        public ActionResult DeleteInventory(int Id)
        {
            Inventory model = new Inventory();

            using (InventoryContext context = new InventoryContext())
            {
                model = context.Inventories.Where(x => x.Id == Id).FirstOrDefault();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteInventory(Inventory model)
        {

            using(InventoryContext context = new InventoryContext())
            {
                //Get the record from the table
                var removeRecordResult = context.Inventories.Where(x => x.Id == model.Id).FirstOrDefault();

                //Generate the remove command
                context.Inventories.Remove(removeRecordResult);

                //Execute the remove command
                context.SaveChanges();
            }

            return RedirectToAction("ShowInventory");
        }

        public ActionResult ShowInventory()
        {
            using(InventoryContext context = new InventoryContext())
            {
                var InventoryRecords = context.Inventories.ToList();
                return View(InventoryRecords);
            }
        }

        [HttpPost]
        public ActionResult EditInventory(Inventory model)
        {
            using(InventoryContext context = new InventoryContext())
            {
                var record = context.Entry(model);
                record.State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("ShowInventory");

            }

         
        }

        public ActionResult EditInventory(int id)
        { 
            using(InventoryContext context = new InventoryContext())
            {
                var result = context.Inventories.Where(x => x.Id == id).FirstOrDefault();
                return View(result);
            }
            
        }
    }
}