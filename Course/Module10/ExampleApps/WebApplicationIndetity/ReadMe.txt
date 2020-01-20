READ:
https://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-1
https://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-2
https://professorweb.ru/my/ASP_NET/identity/level1/

Install NuGet packages
1. Microsoft.Owin.Host.SystemWeb - ASP.NET Identity is actually built on top of OWIN which means the same identity 
features can be used for any OWIN supporting framework such as Web API and SignalR. This package enables OWIN 
middleware to hook into the IIS request pipeline
Install-Package Microsoft.Owin.Host.SystemWeb

2. Microsoft.Owin.Security.Cookies - This is the package that actually enables cookie based authentication
Install-Package Microsoft.Owin.Security.Cookies

Bootstrapping OWIN
To initialize the OWIN identity components we need to add a Startup class to the project with a method Configuration 
that takes an OWIN IAppBuilder instance as a parameter. This class will be automatically located and initialized 
by the OWIN host
Startup\Configuration
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/account/login") <=== This is your Controller
            });
The UseCookieAuthentication extension tells the ASP.NET Identity framework to use cookie based authentication
AuthenticationType - This is a string value that identifies the the cookie. This is necessary since we may have several 
instances of the Cookie middleware. For example, when using external auth servers (OAuth/OpenID) the same cookie middleware 
is used to pass claims from the external provider. If we'd pulled in the Microsoft.AspNet.Identity NuGet package we could 
just use the constant DefaultAuthenticationTypes.ApplicationCookie which has the same value - "ApplicationCookie".
LoginPath - The path to which the user agent (browser) should be redirected to when your application returns an 
unauthorized (401) response. This should correspond to your "login" controller. In this case I have an AuthContoller 
with a LogIn action.

NOTE: Where is startup.cs? => Add Startup.cs
First, the version of Visual Studio has nothing to do with anything. However, in VS2017, you'll have three choices for a 
"web application" out of the box: MVC (where you later choose to include MVC, Web Api, or both), Core, and Core on the Full Framework.
The Core projects will have a Startup.cs class, but the MVC project will not, unless you indicate you want Individual Authentication. 
In that case, a Startup.cs file will be added for the purposes of Identity, but the MVC website, itself, will not be affected or controlled by that.
ERROR: No assembly found containing an OwinStartupAttribute, No assembly found containing a Startup or [AssemblyName].Startup class.
Add to AssemblyInfo.cs reference to Startup file

4. Secure by Default
Create Filter FilterConfig.cs
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
Add to Filters: filters.Add(new AuthorizeAttribute());

Update global.asax, Application_Start
protected void Application_Start()
{
    AreaRegistration.RegisterAllAreas();
    RouteConfig.RegisterRoutes(RouteTable.Routes);
    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
}

5. "protect" resource (by default Home)

6. Create Model
public class LogInModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [HiddenInput]
    public string ReturnUrl { get; set; }
}

7. Create the Auth controller
[AllowAnonymous]
public class AccountController : Controller
{
    public ActionResult LogIn()
    {
        return View();
    }
}
// check how it works
Update LogIn action
    public ActionResult LogIn()
    {
        var model = new LogInModel
        {
            ReturnUrl = returnUrl
        };
        return View(model);
    }
Add POST action
[HttpPost]
public ActionResult LogIn(LogInModel model)
{
    if (!ModelState.IsValid)
    {
        return View();
    }

    // Don't do this in production!
    if (model.Email == "admin@admin.com" && model.Password == "password")
    {
        var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, "Ben"),
                new Claim(ClaimTypes.Email, "a@b.com"),
                new Claim(ClaimTypes.Country, "England")
            },    
            "ApplicationCookie");

        var ctx = Request.GetOwinContext();
        var authManager = ctx.Authentication;

        authManager.SignIn(identity);

        return Redirect(GetRedirectUrl(model.ReturnUrl));
    }

    // user authN failed
    ModelState.AddModelError("", "Invalid email or password");
    return View();
}

private string GetRedirectUrl(string returnUrl)
{
    if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
    {
        return Url.Action("index", "home");
    }

    return returnUrl;
}


- First we create a ClaimsIdentity object that contains information (Claims) about the current user. 
What's particularly interesting about the new Claims based approach is that the Claims are persisted 
to the client inside the authentication cookie. This means that you can add claims for frequently 
accessed user information rather than having to load it from a database on every request. This is 
similar to what we had with Federated Identity's Session Authentication Module (SAM). Note that we 
also provide the authentication type. This should match the value you provided in the Startup class.
- Next we get obtain an IAuthenticationManager instance from the current OWIN context. This was 
automatically registered for you during startup.
- Then we call IAuthenticationManager.SignIn passing the claims identity. This sets the authentication 
cookie on the client.
- Finally we redirect the user agent to the resource they attempted to access. We also check to ensure 
the return URL is local to the application to prevent Open Redirection attacks.

8. Update LoginView
@model WebApplicationIndetity.Models.LogInModel

@Html.ValidationSummary(true)
@using (Html.BeginForm())
{
  @Html.EditorForModel()
  <p>
    <button type="submit">Log In</button>
  </p>
}


9. Update _layout Page
<p>
  Hello @User.Identity.Name
</p>

10. Create Logout (add to controller)
public ActionResult LogOut()
{
    var ctx = Request.GetOwinContext();
    var authManager = ctx.Authentication;

    authManager.SignOut("ApplicationCookie");
    return RedirectToAction("index", "home");
}

11. Update _layout Page
<li>@Html.ActionLink("logout", "Account", "Log out")</li>

12. Accessing custom claim data
Add to Home/Index
    var claimsIdentity = User.Identity as ClaimsIdentity;
    ViewBag.Country = claimsIdentity.FindFirst(ClaimTypes.Country).Value;
Update to Layout
<p>
  Hello @User.Identity.Name. How's the weather in @ViewBag.Country?
</p>


13. Improve
public class AppUser : ClaimsPrincipal
{
    public AppUser(ClaimsPrincipal principal)
        : base(principal)
    {
    }

    public string Name
    {
        get
        {
            return this.FindFirst(ClaimTypes.Name).Value;
        }
    }

    public string Country
    {
        get
        {
            return this.FindFirst(ClaimTypes.Country).Value;
        }
    }
}

create Base controller
public abstract class BaseController : Controller
{       
    public AppUser CurrentUser
    {
        get
        {
            return new AppUser(this.User as ClaimsPrincipal);
        }
    }
}

update Home/Index
ViewBag.Country = CurrentUser.Country;

extend razor
public abstract class AppViewPage<TModel> : WebViewPage<TModel>
{
    protected AppUser CurrentUser
    {
        get
        {
            return new AppUser(this.User as ClaimsPrincipal);
        }
    }
}

public abstract class AppViewPage : AppViewPage<dynamic>
{
}

Open up /views/web.config and the set the pageBaseType:
<system.web.webPages.razor>
  <pages pageBaseType="WebApplicationIndetity.App_Start.AppViewPage">

Update Layout, remove unnecessary code in Home/Index

14. Link with EF
Install-Package Microsoft.AspNet.Identity.EntityFramework
