using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using TestApp.Data.Interfaces;
using TestApp.Data.Models;
using TestApp.SelfHostedRESTSevice.Interfaces;

namespace TestApp.SelfHostedRESTSevice.Core
{
	[AspNetCompatibilityRequirements
		(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
		ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
	public class RESTService : IRESTService
	{
		private readonly IAppDbContext _db;
		public RESTService(IAppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<string> GetAllUsers()
		{
			return _db.Users.Select(i => i.NickName).ToList();
		}

		public UserModel GetUser(string nickName)
		{
			return _db.Users.First(i => i.NickName == nickName);
		}

		public UserModel CreateUser(UserModel user)
		{
			_db.Users.Add(user);
			_db.SaveChanges();

			return user;
		}

		public UserModel UpdateUser(string nickName, UserModel user)
		{
			var dbUser = _db.Users.FirstOrDefault(i => i.NickName == nickName);

			if (dbUser == null)
			{
				dbUser = user;
				_db.Users.Add(dbUser);
			}

			dbUser.FullName = user.FullName; //Or map all db fields with UserModel fields

			_db.SaveChanges();

			return dbUser;
		}

		public void DeleteUser(string nickName)
		{
			var user = _db.Users.First(i => i.NickName == nickName);
			_db.Users.Remove(user);

			_db.SaveChanges();
		}
	}
}