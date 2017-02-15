using System.Data.Entity;
using System.Linq;

using AkvelonTestApp.Data.Models;

namespace AkvelonTestApp.Data
{
	public class AppDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
	{
		protected override void Seed(AppDbContext context)
		{
			InitializeIdentities(context);
			base.Seed(context);
		}

		private static void InitializeIdentities(AppDbContext db)
		{
			if (db.Users.Any())
			{
				return;
			}

			db.Users.Add(new UserModel {NickName = "nickName1", FullName = "fullName1"});
			db.Users.Add(new UserModel {NickName = "nickName2", FullName = "fullName2"});
			db.SaveChanges();
		}
	}
}


