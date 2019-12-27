using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Travels.Models
{
  /* public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        
    }*/

    public class EmployeeContext : IdentityDbContext<Employee>
    {
        public EmployeeContext() : base("EmployeeContext") { }

        public static EmployeeContext Create()
        {
            return new EmployeeContext();
        }
    }
}

 
