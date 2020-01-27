using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace Stage2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapRoute("AliasRoute", "Shop/{action}",
            //    defaults: new { controller = "Home", action = "Index" });
            //routes.MapRoute("MyRoute", "{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index" });

            //Использование специальных переменных сегмента
            routes.MapRoute(
                name: "MyRoute",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                constraints: new
                {
                    controller = "^H.*",
                    httpMethod = new HttpMethodConstraint("GET"),
                    id = new RangeRouteConstraint(2, 30)
                }
                );
        }
    }
}
