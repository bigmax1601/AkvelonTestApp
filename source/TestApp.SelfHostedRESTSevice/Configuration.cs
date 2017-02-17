using System;
using System.IO;
using System.Reflection;

namespace TestApp.SelfHostedRESTSevice
{
	public class Configuration
	{
		public static class Constants
		{
			public const string DataDirectoryRelative = "App_Data";
		}

		public static class Routing
		{
			public const string BaseAdress = "http://localhost:7777";
			public const string RootServiceRoute = "/Services/TestService/";

			public const string GetUsersRoute = RootServiceRoute + "Users";
			public const string GetUserRoute = RootServiceRoute + "GetUser/{nickName}";
			public const string CreateUserRoute = RootServiceRoute + "CreateUser";
			public const string UpdateUserRoute = RootServiceRoute + "UpdateUser/{nickName}";
			public const string DeleteUserRoute = RootServiceRoute + "DeleteUser/{nickName}";
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