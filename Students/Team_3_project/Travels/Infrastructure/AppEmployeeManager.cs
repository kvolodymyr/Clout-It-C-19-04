using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Travels.Models;

namespace Travels.Infrastructure
{
    public class ApplicationEmployeeManager : UserManager<Employee>
    {
            public ApplicationEmployeeManager(IUserStore<Employee> store)
                    : base(store)
            {
            }
            public static ApplicationEmployeeManager Create(IdentityFactoryOptions<ApplicationEmployeeManager> options,
                                                    IOwinContext context)
            {
                AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
                ApplicationEmployeeManager manager = new ApplicationEmployeeManager(new UserStore<Employee>(db));
                return manager;
            }

    }
}