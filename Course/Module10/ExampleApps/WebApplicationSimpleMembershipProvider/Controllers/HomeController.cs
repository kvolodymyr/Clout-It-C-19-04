﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace WebApplicationSimpleMembershipProvider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }

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