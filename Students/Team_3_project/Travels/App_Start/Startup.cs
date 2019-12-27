using Microsoft.Owin;
using Owin;
using Travels.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Travels.Infrastructure;

//[assembly: OwinStartup(typeof(AspNetIdentityApp.Startup))]

namespace AspNetIdentityApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // настраиваем контекст и менеджер
            app.CreatePerOwinContext<AppIdentityDbContext>(AppIdentityDbContext.Create);
            app.CreatePerOwinContext<ApplicationEmployeeManager>(ApplicationEmployeeManager.Create);
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
           
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Employee/Login"),
            });
        }
    }
}