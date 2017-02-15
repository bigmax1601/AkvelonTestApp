﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AkvelonTestApp.Web
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			// http://stackoverflow.com/questions/23098191/failed-to-serialize-the-response-in-web-api-with-json
			//GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
			//	.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
			//GlobalConfiguration.Configuration.Formatters
			//	.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
		}
	}
}
