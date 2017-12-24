using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace admin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{JobType}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Verification",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Verification", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "BankCardChange",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "BankCardChange", action = "AcceptingList", id = UrlParameter.Optional }
            );
        }
    }
}