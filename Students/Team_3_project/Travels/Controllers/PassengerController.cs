using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travels.Infrastructure;
using Travels.Mocks;
using Travels.Models;

namespace Travels.Controllers
{
    public class PassengerController : Controller
    {
       
        public ActionResult Search()
        {
            ApplicationEmployeeManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationEmployeeManager>();
            List<Employee> drivers = userManager.Users.ToList().Where(x => userManager.IsInRoleAsync(x.Id, "Driver").ConfigureAwait(false).GetAwaiter().GetResult()).ToList();
            if(drivers.Count==0)
            {
                ViewBag.Message = "There are no drivers for your request";
                ViewBag.Result = 0;
                return View();
            }
            ViewBag.Result = drivers;
            return View();
        }
 
        // Post: Search request
        [HttpPost]
        public ActionResult Search(string searchRequset)
        {
            ApplicationEmployeeManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationEmployeeManager>();
            List<Employee> drivers = userManager.Users.ToList().Where(x => x.TravelRoute.Contains(searchRequset.ToLower()) && userManager.IsInRoleAsync(x.Id, "Driver").ConfigureAwait(false).GetAwaiter().GetResult()).ToList();
            
            if(drivers.Count==0)
            {
                ViewBag.Message = "There are no drivers for your request";
                ViewBag.Result = drivers;
                return View();
            }
            ViewBag.Result = drivers;
            return View("SearchResult");
        }

        // Get passenger????

        // POST: Request for driver
        public ActionResult RequestForDriver (Employee passenger, string id)
        {
            DriverMock drivers = new DriverMock();
            //List<Employee> result = drivers.Driver.Where(x => x.Id==id).ToList();

             //   ViewBag.Result = result;
 /*               ViewBag.Success = $"Success\t Request to Driver {result[0].FirstName} has been sent";*/
            return View("SearchResult");
        }

        
    }
}
