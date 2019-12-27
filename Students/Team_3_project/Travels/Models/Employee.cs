using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Travels.Models
{
    // public class Employee: DropCreateDatabaseAlways<CustomerContext>
    public class Employee : IdentityUser
    {
        public  string UserId { get; set; }

       // public string UserName { get; set; }
         /* public  override string UserName {
              get
              {
                  if (FirstName != null && FirstName != null)
                  { return (FirstName + LastName).ToLower(); }
                  return String.Empty;
              }
          }*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string HashedPassword { get; set; }
        public string MarkAuto { get; set; }
        public int Capacity { get; set; }
        public string TravelPoint1 { get; set; }
        public string TravelPoint2 { get; set; }
        public string TravelPoint3 { get; set; }
        public string TravelPoint4 { get; set; }

        public DateTime MyProperty { get; set; }

        public bool IsDriver { get; set; }
    }
}