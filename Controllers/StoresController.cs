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
using InventoryApp.ViewModels;
using System.Threading.Tasks;

namespace InventoryApp.Controllers
{
    public class StoresController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Stores
        public ActionResult Index()
        {
            return View(db.Stores.ToList());
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            //Create an instance of the EmployeesDetaislViewModel
            EmployeesDetailsViewModel model = new EmployeesDetailsViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Store store = db.Stores.Find(id);
            model.Store = db.Stores.Find(id); //Find stores
            model.Inventories = db.Inventories.Where(x => x.Stores.Id == id).ToList(); //Find all inventories for a store

            if (model.Store == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //Adding a new actionresult to return a list of categories
        public ActionResult SearchCategory(string term)
        {


            var result = db.Categories
                .Where(x => x.Name.StartsWith(term))
                .Select(x => new { label = x.Name, value = x.Id })
                .ToList();

            //We must return a JSON String type value to 
            //our JQUERYUI Request
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public async Task<ActionResult> GetPartialView(int Id)
        {
            var model = db.Inventories.Where(x => x.Stores.Id == Id).ToList(); //Find all inventories for a store
            return PartialView("_InventoryList", model);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            //Create DropdownList
            ViewBag.EmployeeDropDownList = db.Employees.ToList();

            return View();
        }

#region oldArea
        //// POST: Stores/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Description,IsActive,OpenDate,EmployeeID")] Store store)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Stores.Add(store);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(store);
        //}
#endregion

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAjax([Bind(Include = "Id,Name,Description,IsActive,OpenDate,EmployeeID, Rating, CategoryID")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();

                return this.Json(new
                {
                    EnableSuccess = true,
                    SuccessTitle = "Success",
                    SuccessMsg = "Success"
                });
            }
            else
            {
                return this.Json(new
                {
                    EnableError = true,
                    ErrorTitle = "Error",
                    ErrorMsg = "Something goes wrong, please try again later"
                });
            }

        }



        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            //Create DropdownList
            ViewBag.EmployeeDropDownList = db.Employees.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IsActive,OpenDate,EmployeeID")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
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

        //Adding ActionResult to redirect to the Inventory Controller
        public ActionResult AddInventory(int id)
        {

            //Index is the ActionResult, Inventories is the Controller, StoreId is the URL Parameter
            return RedirectToAction("Index", "Inventories", new { storeId = id });
        }


    }
}
