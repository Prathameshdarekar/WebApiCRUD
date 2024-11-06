using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiCrudDBFirst
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Enable attribute routing
            config.MapHttpAttributeRoutes();

            // Define default route for Web API
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}
