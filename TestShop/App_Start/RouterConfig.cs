using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace TestShop
{
	public static class RouterConfig
	{
		public static void RegisterRoutes(RouteCollection routeCollection)
		{
			routeCollection.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
				);
		}
	}
}