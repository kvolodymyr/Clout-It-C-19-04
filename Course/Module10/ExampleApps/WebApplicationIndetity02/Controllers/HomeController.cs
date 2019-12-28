using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationIndetity.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //var claimsIdentity = User.Identity as ClaimsIdentity;
            //ViewBag.Country = claimsIdentity.FindFirst(ClaimTypes.Country).Value;
            ViewBag.Country = CurrentUser.Country;

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
    }
}