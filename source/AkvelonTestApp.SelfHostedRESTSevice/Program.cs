using System;
using System.ServiceModel.Web;

using AkvelonTestApp.Data;
using AkvelonTestApp.SelfHostedRESTSevice.Core;

namespace AkvelonTestApp.SelfHostedRESTSevice
{
	class Program
	{
		static Program()
		{
			Confguration.Initialize();
		}


		static void Main(string[] args)
		{
			var db = new AppDbContext();

			var restService = new RESTService(db);


			Console.WriteLine("Starting RESTService...\n\n");

			using (var serviceHost = new WebServiceHost(restService, new Uri("http://localhost:7777")))
			{
				serviceHost.Open();

				Console.WriteLine("RESTService is running now.\n\n");

				string serviceRoot = Confguration.Routing.RootServiceRoute;
				Console.WriteLine($"Use http://localhost:7777/{serviceRoot} + service_name in your browser.\n");

				Console.Write("Press Enter to stop RESTService...");
				Console.ReadLine();

				serviceHost.Close();
			}

			Console.WriteLine("RESTService is stopped.\n\n");

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}
