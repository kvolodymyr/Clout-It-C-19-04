using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HelloAsp.Controllers
{
    public class DataController : Controller
    {
        // GET: Data

        /*This method receive data with redirected request
         and via ViewBag object send data to View*/
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        /*This method read text from file and then redirect request from Index() method
          Data that have been read from file saved in TempData object and transmit into 
          Index() method
         */
        public ActionResult RedirectMethod()
        {
            FileStream fs = new FileStream("C:\\Users\\Arseniy\\Desktop\\HelloAsp\\input.txt", FileMode.Open);
            using(StreamReader sr = new StreamReader(fs))
            {
                TempData["Message"]  = sr.ReadToEnd();
            }
            return RedirectToAction("Index");
        }
    }
}