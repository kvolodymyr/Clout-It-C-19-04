using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travels.Mocks;
using Travels.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Travels.Infrastructure;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace Travels.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        //AppIdentityDbContext db = new AppIdentityDbContext();
        private ApplicationEmployeeManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationEmployeeManager>();
            }
        }

        // GET: Employee
        public ActionResult Customer()
        {
            return View();
        }
        
        [AllowAnonymous]
        // GET: Employee/Details/5
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login (LoginViewModel details, string returnUrl)
        {
            //EmployeeMock customers = new EmployeeMock();
            //  var user = customers.Employees.Where(x => x.FirstName == nickName.ToLower() && Verification.VerifyHashedPassword(x.HashedPassword,password)==true).Count();
            /*   var user = UserManager.Users.ToList().Where(x => x.FirstName == nickName.ToLower() && Verification.VerifyHashedPassword(x.HashedPassword, password) == true);
               if (user.Count() == 1)
               {
                   if (user.Where(x => x.IsDriver == true).Count() == 1)
                   { return RedirectToAction("Driver", "Index"); }
                   else { return RedirectToAction("Passenger", "Index"); }
               }
               ViewBag.Message = "Incorrect Login";*/
            Employee user = await UserManager.FindAsync(details.Name, details.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);
                return Redirect(returnUrl);
            }

            return View(details);
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}
