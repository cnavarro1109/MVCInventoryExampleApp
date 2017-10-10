using InventoryApp.Data;
using InventoryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using InventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class StoreManagementController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: StoreManagement
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            //We are storing the sortOrder so the view can store temporarely  (The most current)
            ViewBag.CurrentSort = sortOrder;


            /*
             * Checking to see if the searchString is null. 
             * If not, then we have to reset the page back to 1. 
             */
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                //If the searchString is null, then we reasign the previous value to searchString.
                searchString = currentFilter;
            }

            //We assign the value of searchString to a viewBag to store in the View
            ViewBag.CurrentFilter = searchString;


            //Filtering our values
            //IQueryable<Store> Results = db.Stores;

            //We need to cast it as IQueryable to be able to filter the values
            //var Results = (IQueryable<Store>)db.Stores;

            var Results = (from A in db.Stores
                           join B in db.Employees
                           on A.EmployeeID equals B.Id
                           select new StoreManagementViewModel
                           {
                               StoreId = A.Id,
                               Name = A.Name,
                               Description = A.Description,
                               FirstName = B.FirstName,
                               LastName = B.LastName
                           });


            //Checking to see what sort category we are going to choose from
            switch (sortOrder)
            {
                case "FirstName":
                    Results = Results.OrderByDescending(x => x.FirstName);
                    break;
                case "LastName":
                    Results = Results.OrderByDescending(x => x.LastName);
                    break;
                default:
                    Results = Results.OrderBy(x => x.StoreId);
                    break;
            }

           
            //Defining the initial values of our pagedList
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //Passing the filters and Model back to the view
            return View(Results.ToPagedList(pageNumber, pageSize));

            //return View(Results);
        }
    }
}