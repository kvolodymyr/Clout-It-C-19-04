using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        public ViewResult CustomVariable(int? id)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            ViewBag.Id = id;
            return View();
        }
    }
}