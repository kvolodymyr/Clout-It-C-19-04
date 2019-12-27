using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travels.Mocks;

namespace Travels.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string requsest)
        {
            EmployeeMock mock = new EmployeeMock();
            if (String.IsNullOrEmpty(requsest))

            {
             //   var searchRequest = mock.Employees.
                 //                      Where(x => x.TravelRoute == requsest || x.TravelPoint2 == requsest || x.TravelPoint3 == requsest || x.TravelPoint4 == requsest);
                //Default Search
                //GET user's default points
                // Put them in search model
                //Return all results

                //Custom search
                //User put request - some point 
                // Get results

                //Custom search2 
                // User can select existed points and get all drivers which correspond to these points    
            }
            return View();
        }

        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
