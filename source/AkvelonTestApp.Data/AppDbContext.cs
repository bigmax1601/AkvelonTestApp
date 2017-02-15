using System.Data.Entity;
using System.Diagnostics;
using AkvelonTestApp.Data.Interfaces;
using AkvelonTestApp.Data.Models;


namespace AkvelonTestApp.Data
{
	public class AppDbContext : DbContext, IAppDbContext
	{
		public AppDbContext() : base("name=AkvelonTestAppDb")
		{
			// http://stackoverflow.com/questions/23098191/failed-to-serialize-the-response-in-web-api-with-json
			//Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
		}

		public AppDbContext(bool MultipleActiveResultSets = false)
		{
			//http://stackoverflow.com/questions/4867602/entity-framework-there-is-already-an-open-datareader-associated-with-this-comma
			Database.Connection
				.ConnectionString += (MultipleActiveResultSets ? ";MultipleActiveResultSets=true;" : "");
		}

		static AppDbContext()
		{
			// Set the database intializer which is run once during application start
			Database.SetInitializer(new AppDbInitializer());
		}

		public IDbSet<UserModel> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
#if DEBUG
			Database.Log = s => Debug.Write(s);
#endif
		}
	}
}