using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InventoryControl
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Laptops", action = "Home", id = "" }
            );

            routes.MapRoute(
                name: "Products",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Laptops", action = "Products", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Details",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Details", id = UrlParameter.Optional }
            );

        }
    }
}