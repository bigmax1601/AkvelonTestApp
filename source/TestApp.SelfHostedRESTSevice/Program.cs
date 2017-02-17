using System;

using TestApp.Data;
using TestApp.SelfHostedRESTSevice.Core;

namespace TestApp.SelfHostedRESTSevice
{
	class Program
	{
		static Program()
		{
			Configuration.Initialize();
		}


		static void Main(string[] args)
		{
			//Arrange
			var db = new AppDbContext();
			var restService = new RESTService(db);
			var hostingService = new HostingRESTService(restService,
				new Uri(Configuration.Routing.BaseAdress));

			//Act
			Msg.Start();
			hostingService.Start();

			Msg.IsRunning();
			Msg.Usage();
			Msg.Wait("stop RESTService");
			
			hostingService.Stop();
			Msg.Stop();

			Msg.Wait("exit");
		}
	}
}
