using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using Travels.Infrastructure;

namespace Travels.Controllers
{   
   
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ApplicationEmployeeManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationEmployeeManager>();
            return View(userManager.Users);
        }
    }
}