using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationDbcontext.Models
{
    public class Driver
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Hey, dude you forget name!"), MinLength(5)]
        public string Name { get; set; }
    }
}