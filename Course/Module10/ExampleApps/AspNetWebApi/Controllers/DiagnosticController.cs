using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace AspNetWebApi.Controllers
{
    // REST
    public class DiagnosticController : ApiController
    {
        // http://localhost:11135/api/diagnostic/version
        [HttpGet]
        public string GetVersion() {
            // CookieCollection
            // HttpContext.Current.Request.Cookies.AllKeys
            // HttpContext.Current.Response.Cookies.Add(new HttpCookie("key1", "djkhgjkhsdjkg"));
            Assembly assembly = this.GetType().Assembly;
            object[] attribs = assembly.GetCustomAttributes(typeof(AssemblyVersionAttribute), true);
            return attribs.Length > 0 ? ((AssemblyVersionAttribute)attribs[0]).Version : "unknown";
        }

        /*
         * public string GetCompany()
         * Routing don't understand what method need to call
        {"Message":"An error has occurred.","ExceptionMessage":
        "Multiple actions were found that match the request: \r\n
        AspNetWebApi.Controllers.DiagnosticController\r\nGetCompany on type AspNetWebApi.Controllers.DiagnosticController","ExceptionType":"System.InvalidOperationException","StackTrace":" at System.Web.Http.Controllers.ApiControllerActionSelector.ActionSelectorCacheItem.SelectAction(HttpControllerContext controllerContext)\r\n at System.Web.Http.Controllers.ApiControllerActionSelector.SelectAction(HttpControllerContext controllerContext)\r\n at System.Web.Http.ApiController.ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)\r\n at System.Web.Http.Dispatcher.HttpControllerDispatcher.d__15.MoveNext()"}        
        FIX: Update global routing
        */

        [HttpGet /*, ActionName("company") */]
        public string GetCompany()
        {
            Assembly assembly = this.GetType().Assembly;
            object[] attribs = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true);
            return attribs.Length > 0 ? ((AssemblyCompanyAttribute)attribs[0]).Company : "unknown";
        }

        [HttpGet, ActionName("author")]
        public string GetAuthor()
        {
            return "Bill Gates";
        }

    }
}
