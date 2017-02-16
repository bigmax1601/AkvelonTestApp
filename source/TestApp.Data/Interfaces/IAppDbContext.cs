using System.Data.Entity;

using TestApp.Data.Models;

namespace TestApp.Data.Interfaces
{
	public interface IAppDbContext
	{
		IDbSet<UserModel> Users { get; set; }
		int SaveChanges();
	}
}