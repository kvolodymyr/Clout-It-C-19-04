using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Travels.Models;
using System.Collections.Generic;
using Travels.Validators;

namespace Travels.Infrastructure
{
  /* public class AppIdentityDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        
    }*/

    public class AppIdentityDbContext : IdentityDbContext<Employee>
    {
        // public AppIdentityDbContext() : base("WorkRouts") { }
        public AppIdentityDbContext() : base("EmployeeContext") { }
        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            ApplicationEmployeeManager userMgr = new ApplicationEmployeeManager(new UserStore<Employee>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

           
            
            
            string[] roleNames = new string[] { "Driver", "Passenger" };
            List<Employee> employees = new List<Employee> {
                //Passengers
               new Employee { UserName = "passenger1",  Password = "121", PasswordHash = Verification.HashPassword("121"), TravelRoute = "Home1" },
               new Employee { UserName = "passenger2",  Password = "122", PasswordHash = Verification.HashPassword("122"), TravelRoute = "Home2,Shop2,bus stop1"},
               new Employee { UserName = "passenger3",  Password = "123", PasswordHash = Verification.HashPassword("123"), TravelRoute = "Home3,Shop2,Shop3"},
               new Employee { UserName = "passenger4",  Password = "124", PasswordHash = Verification.HashPassword("124"), TravelRoute = "Home4,Shop4,bus stop1"},
               new Employee { UserName = "passenger5",  Password = "125", PasswordHash = Verification.HashPassword("125"), TravelRoute = "Home5,Shop5,bus stop2"},
               //Drivers
               new Employee { UserName = "driver1",  Password = "121", PasswordHash = Verification.HashPassword("121"), TravelRoute = "Home1, bus stop1" },
               new Employee { UserName = "driver2",  Password = "122", PasswordHash = Verification.HashPassword("122"), TravelRoute = "Home1,Home2,Shop2,bus stop1"},
               new Employee { UserName = "driver3",  Password = "123", PasswordHash = Verification.HashPassword("123"), TravelRoute = "Shop2,Shop3"},
               new Employee { UserName = "driver4",  Password = "124", PasswordHash = Verification.HashPassword("124"), TravelRoute = "Home4,Shop4,bus stop1,bus stop2,bus stop3"},
               new Employee { UserName = "driver5",  Password = "125", PasswordHash = Verification.HashPassword("125"), TravelRoute = "Shop5,bus stop2"},
            };

            foreach (string roleName in roleNames)
            {
                if (!roleMgr.RoleExists(roleName))
                {
                    roleMgr.Create(new AppRole(roleName));
                }
            }
            foreach (var emploee in employees)
            {
                Employee user = userMgr.FindByName(emploee.UserName);
                if (user == null)
                {
                    userMgr.Create(emploee);
                    user = userMgr.FindByName(emploee.UserName);
                }
                if (emploee.UserName.Contains("passenger") && !userMgr.IsInRole(user.Id, roleNames[1]))
                {
                     userMgr.AddToRole(user.Id, roleNames[1]);
                }
                else if(emploee.UserName.Contains("driver") && !userMgr.IsInRole(user.Id, roleNames[0]))
                {
                    userMgr.AddToRole(user.Id, roleNames[0]);
                }
            }
        }

    }
}


 
