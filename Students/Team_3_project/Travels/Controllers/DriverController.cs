using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Travels.Controllers
{
    public class DriverController : ApiController
    {
        [ActionName("greeting")]
        [HttpGet]
        public string Greeting() {
            return "hello";
        }
    }
}
