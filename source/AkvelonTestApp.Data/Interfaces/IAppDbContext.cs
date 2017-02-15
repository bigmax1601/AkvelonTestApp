using System.Data.Entity;

using AkvelonTestApp.Data.Models;

namespace AkvelonTestApp.Data.Interfaces
{
	public interface IAppDbContext
	{
		IDbSet<UserModel> Users { get; set; }
		int SaveChanges();
	}
}