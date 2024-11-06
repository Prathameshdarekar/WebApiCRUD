using System.Web.Http;
using WebActivatorEx;
using WebApiCrudDBFirst;
using Swashbuckle.Application;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiCrudDBFirst
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var config = GlobalConfiguration.Configuration;

            // Check if the route already exists to avoid adding it multiple times
            if (config.Routes.Cast<System.Web.Http.Routing.IHttpRoute>().Any(r => r.RouteTemplate == "swagger/docs/{apiVersion}"))
            {
                return; // Route already exists, skip configuration
            }

            // Enable Swagger
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Employee API");
                    // Additional Swagger configuration here, if needed
                })
                .EnableSwaggerUi();
        }
    }
}
