using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryApp.Data;
using InventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class InventoriesController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Inventories
        public ActionResult Index(int? storeId)
        {
            #region oldcode
            //if (storeId > 0)
            //{
            //    ViewBag.StoreId = storeId; //We need to hold the storeId

            //    return View(db.Inventories.Where(x => x.Stores.Id == storeId).ToList());
            //}
            //else
            //{
            //    return View(db.Inventories.ToList());
            //}
            #endregion

            ViewBag.StoreId = storeId; //We need to hold the storeId
            //return View(db.Inventories.Where(x => x.IsActive == true).ToList());
            return View(db.Inventories.Where(x => x.Stores.Id == storeId).ToList());

        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.StoreId = db.Inventories.Where(x => x.Id == id).FirstOrDefault().Stores.Id; //We need to hold the storeId

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create(int StoreId)
        {
            //We need to create new instance of the class Inventory
            Inventory model = new Inventory();

            //Assigned the store id to the new model
            model.Stores = new Store(); //Create an instance of the class Store
            model.Stores.Id = StoreId;

            return View(model);
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Stores,Price,Color")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {

                //Assign the store information to the inventory object
                inventory.Stores = db.Stores.Where(x => x.Id == inventory.Stores.Id).FirstOrDefault();

                db.Inventories.Add(inventory);
                db.SaveChanges();


                return RedirectToAction("Index", new { storeId = inventory.Stores.Id });
            }

            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Color")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            var store = db.Inventories.Where(x => x.Id == inventory.Id).FirstOrDefault().Stores.Id;
            return RedirectToAction("Index", new { storeId = store });
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Inventory inventory = db.Inventories.Find(id);
            //db.Inventories.Remove(inventory);

            /*
                Get the single row into the new object/variable called InventoryResults
             */
            var InventoryResults = db.Inventories.Where(x => x.Id == id).FirstOrDefault();
            InventoryResults.IsActive = false; //Update the property IsActive to false

            db.Entry(InventoryResults).State = EntityState.Modified; //Set the flag to update the record

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
