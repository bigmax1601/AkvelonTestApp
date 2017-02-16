using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestApp.Data.Interfaces;
using TestApp.Data.Models;

namespace TestApp.Web.Controllers
{
	public class TestServiceController : ApiController
	{
		private readonly IAppDbContext _db;

		public TestServiceController(IAppDbContext db)
		{
			_db = db;
		}

		/// <summary>
		/// Get all user nicknames
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<string> Users()
		{
			return _db.Users.Select(i => i.NickName).ToList();
		}

		/// <summary>
		/// Get User info by NickName
		/// </summary>
		/// <param name="nickName"></param>
		/// <returns></returns>
		[HttpGet]
		public UserModel GetUser(string nickName)
		{
			return _db.Users.First(i => i.NickName == nickName);
		}

		/// <summary>
		/// Create user
		/// </summary>
		/// <param name="nickName"></param>
		/// <param name="value"></param>
		[HttpPost]
		public void CreateUser(string nickName, [FromBody]string value)
		{
			_db.Users.Add(new UserModel { NickName = nickName, FullName = value });
			_db.SaveChanges();
		}

		/// <summary>
		/// Update user
		/// </summary>
		/// <param name="nickName"></param>
		/// <param name="value"></param>
		[HttpPut]
		public void UpdateUser(string nickName, [FromBody]string value)
		{
			var user = _db.Users.FirstOrDefault(i => i.NickName == nickName);

			if (user == null)
			{
				user = new UserModel { NickName = nickName };
				_db.Users.Add(user);
			}

			user.FullName = value;

			_db.SaveChanges();
		}

		/// <summary>
		/// Delete user
		/// </summary>
		/// <param name="nickName"></param>
		[HttpDelete]
		public void DeleteUser(string nickName)
		{
			var user = _db.Users.First(i => i.NickName == nickName);
			_db.Users.Remove(user);

			_db.SaveChanges();
		}
	}
}
