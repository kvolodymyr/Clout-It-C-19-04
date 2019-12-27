using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Travels.Models
{
    // public class Employee: DropCreateDatabaseAlways<CustomerContext>
    public class Employee : IdentityUser
    {
        // hide ID field in html code in view  [ScaffoldColumn(false)]
        public string Name { get; set; }

        public string Password { get; set; }
        public string TravelRoute { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}