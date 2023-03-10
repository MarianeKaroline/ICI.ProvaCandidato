using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ICI.ProvaCandidato.Web.App_Start
{
    public static class RouteConfig
    {
        public static IRouteBuilder RegisterRoutes(IRouteBuilder route)
        {
            route.MapRoute(
                name: "default", 
                template: "{controller=Home}/{action=Index}/{id?}"
            );

            return route;
        }
    }
}
