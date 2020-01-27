using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloAsp.Controllers
{
    //This controller used for demonstration ActionResult types
    public class ActionController : Controller
    {
        /*
          ActionResult is abstract class for response result.  
          It has ExecuteResult() method, that is invoked when 
          infrastructure MVS get ActionResult type
         */
        public ActionResult Index()
        {
            ViewBag.Message = "Hello from Index!";
            return View();
        }

        /*
           ViewResult inherited from ActionResult and 
           used for return View. 
           There are some set of parameters View() method
         */
         [ActionName("View")]
        public ViewResult ViewResultAction()
        {
            ViewBag.Message = "Hello from ViewResultAction";
            return View("Index");
            //return View(); //for displaying view that has same name with action method
        }

        /*
          RedirectResult inherited from ActionResult.
          Used for redirect request to other particular URL
         */
         [ActionName("Redirect")]
        public RedirectResult RedirectResultAction()
        {
            return Redirect("Action/Index"); //temporary redirection. Return 301 HTTP code
            //return RedirectPermanent() //permanent redirection. Return 302 HTTP code
        }

        /*
         RedirectToRouteResult inherited from ActionResult.
         Used for redirect request to new route via routing system
         */
         [ActionName("RedirectToRoute")]
        public RedirectToRouteResult RedirectToRouteResultAction()
        {
            ////Method get anonimous type that describe route
            //return RedirectToRoute(new
            //{
            //    controller = "Action",
            //    action = "Index"
            //});

            /*return RedirectToRoutePermanent(new
            {
                controller = "Action",
                action = "Index"
            });*/

            return RedirectToAction("Index"); //redirect request to Action method. Returns RedirectToRouteResult
        }

        public HttpStatusCodeResult Status()
        {
            return new HttpStatusCodeResult(404, "This page is not found!");
            
        }

        
    }
}