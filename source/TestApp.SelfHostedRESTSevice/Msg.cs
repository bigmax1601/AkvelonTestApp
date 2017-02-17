using System;

namespace TestApp.SelfHostedRESTSevice
{
	public static class Msg
	{
		public static void Message(string str)
		{
			Console.WriteLine(str);
		}

		public static void Start()
		{
			Message("Starting RESTService...\n\n");
		}

		public static void Stop()
		{
			Message("RESTService is stopped.\n\n");
		}

		public static void IsRunning()
		{
			Message("RESTService is running now.\n\n");
		}

		public static void Usage()
		{
			var baseUri = new Uri(Configuration.Routing.BaseAdress);
			var serviceRootUri = new Uri(baseUri, Configuration.Routing.RootServiceRoute);

			Message($"Use {serviceRootUri} + service_name in your browser.\n");
		}

		public static void Wait(string message)
		{
			Message($"Press Enter to {message}...");
			Console.ReadLine();
		}
	}
}