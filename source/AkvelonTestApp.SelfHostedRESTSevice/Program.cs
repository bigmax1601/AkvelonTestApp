using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AkvelonTestApp.Data;

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
			var users = string.Join(", ", db.Users.Select(i => i.NickName).AsEnumerable());

			Console.WriteLine(users);

			Console.Write("PressEnter to exit...");
			Console.ReadLine();
		}
	}
}
