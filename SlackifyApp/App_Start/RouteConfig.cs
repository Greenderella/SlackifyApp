using System.Web.Mvc;
using System.Web.Routing;

namespace SlackifyApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Endpoint", // Route name
                url: "endpoint/{endpoint}", // URL with parameters
                defaults: new { controller = "Endpoint", action = "Process", endpoint = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }

    }
}
