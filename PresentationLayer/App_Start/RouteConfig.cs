using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PresentationLayer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Contact",
              url: "{controller}/{Mail}/{u}/{0}/{filter}",
              defaults: new { controller = "Contact", action = "Index", String = "" }
            );

            routes.MapRoute(
              name: "Dashboard",
              url: "Dashboard/{controller}/{action}/{id}",
              defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Filter",
              url: "{controller}/{Mail}/{mails}/{filter}",
              defaults: new { controller = "Message", action = "Mails", String = "" }
            );

            routes.MapRoute(
               name: "Detail",
               url: "{controller}/{Mail}/{mails}/{url}/{id}",
               defaults: new { controller = "Message", action = "Detail", String = "", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Message",
                url: "{controller}/{Mail}/{mails}",
                defaults: new { controller = "Message", action = "Mails", String = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
