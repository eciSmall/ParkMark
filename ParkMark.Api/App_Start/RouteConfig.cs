using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ParkMark.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default", namespaces: new[] { "ParkMark.API.Controllers" },
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            RouteTable.Routes.MapHttpRoute(
                "Login",
                "api/Authentication/Login",
                defaults: new { Controller = "Authentication", Action = "Login" }
                );
            RouteTable.Routes.MapHttpRoute(
                "Register",
                "api/Authentication/Register",
                defaults: new { Controller = "Authentication", Action = "Register" }
                );
            RouteTable.Routes.MapHttpRoute(
                "CPLogin",
                "api/CPAuthentication/Login",
                defaults: new { Controller = "CPAuthentication", Action = "Login" }
                );
        }
    }
}
