using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FirstMVCApp.classes;

namespace FirstMVCApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{value1}/{value2}",
                defaults: new { controller = "Home", action = "Max", value1="0",value2="0" },
                constraints:new { value1 = @"_?[0-9]+", value2 = @"_?\d+" ,
                    method= new  HttpMethodConstraint("Get"),
                port = new LocalhostConstraint() }
            );

            routes.MapRoute(
    name: "hello",
    url: "{controller}/{action}/{name}",
    defaults: new { controller = "Home", action = "Welcomex", name ="" }
  
);
        }
    }
}
