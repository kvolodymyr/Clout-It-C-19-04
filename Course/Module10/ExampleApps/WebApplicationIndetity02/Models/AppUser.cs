using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebApplicationIndetity.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() { 
        }

        public AppUser(ClaimsPrincipal principal)
        {
            Name = principal.FindFirst(ClaimTypes.Name).Value;
            Country = principal.FindFirst(ClaimTypes.Country).Value;
        }

        public string Name { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }
    }
}