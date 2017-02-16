using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TestApp.Web
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "Services/{controller}/{action}/{nickName}",
				defaults: new { nickName = RouteParameter.Optional }
			);
		}
	}
}
