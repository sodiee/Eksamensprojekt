﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebGUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ferry", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "FerryDetails",
                url: "Ferry/Details/{id}",
                defaults: new { controller = "Ferry", action = "Details", id = UrlParameter.Optional }
            );
        }
    }
}
