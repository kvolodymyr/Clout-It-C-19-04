using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplicationIndetity.Models;

namespace WebApplicationIndetity.Controllers
{
    public abstract class BaseController : Controller
    {
        public AppUser CurrentUser
        {
            get
            {
                // return new AppUser(this.User as ClaimsPrincipal);
                return new AppUser();
            }
        }
    }
}