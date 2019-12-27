using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace MvcInternetApplication.Controllers
{
    /*
     In the code above both the Register and Login action methods are intended for the GET requests with no 
     parameter and invoke the InitializeDatabaseConnection() method of the WebSecurity class. This method 
     initializes the database connection and ensures that the tables needed by the SimpleMembership is 
     available. The methods that are intended to POST requestes accepts the FormCollection parameter. 
     The Register() (POST) method creates the user account using the CreateUserAndAccount() method and 
     store the data into table. The Login() (Post) method called when the login page is submitted by 
     the user.
     */
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                WebSecurity.CreateUserAndAccount("Admin", "Admin");
                Roles.CreateRole("Administrator");
                Roles.AddUserToRole("Admin", "Administrator");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection Form)
        {
            bool Authenticated = WebSecurity.Login(Form["UserName"], Form["Password"], false);
            if (Authenticated)
            {
                string Return_Url = Request.QueryString["ReturnUrl"];
                if (Return_Url == null)
                {
                    Response.Redirect("/Home/Index");
                }
                else
                {
                    Response.Redirect(Return_Url);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("MembershipDbContext", "Users", "ID", "Name", autoCreateTables: true);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection Form)
        {
            WebSecurity.CreateUserAndAccount(Form["Name"], Form["Password"], new { UserName = Form["UserName"], City = Form["City"] });
            Response.Redirect("~/Account/Login");
            return View();
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            Response.Redirect("~/Account/Login");
            return View();
        }
    }
}

