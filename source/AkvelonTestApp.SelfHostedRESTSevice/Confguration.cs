using System;
using System.IO;
using System.Reflection;

namespace AkvelonTestApp.SelfHostedRESTSevice
{
	public class Confguration
	{
		public static class Constants
		{
			public const string DataDirectoryRelative = "App_Data";
		}

		public static void Initialize()
		{
			SetDataDirectory();
		}

		static void SetDataDirectory()
		{
			string executable = Assembly.GetExecutingAssembly().Location;
			string path = Path.GetDirectoryName(executable);
			string dataPath = Path.Combine(path ?? string.Empty, Constants.DataDirectoryRelative);

			if (!Directory.Exists(dataPath))
			{
				Directory.CreateDirectory(dataPath);
			}
			
			AppDomain.CurrentDomain.SetData("DataDirectory", dataPath);
		}
	}
}