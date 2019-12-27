using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Travels.Models
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
            EmployeeContext db =  context.Get<EmployeeContext>();
            ApplicationEmployeeManager manager = new ApplicationEmployeeManager(new UserStore<Employee>(db));
            return manager;
        }
    }
}