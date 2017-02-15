using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AkvelonTestApp.Data;
using AkvelonTestApp.Data.Interfaces;

namespace AkvelonTestApp.Web.Controllers
{
	public class TestServiceController : ApiController
	{
		private readonly IAppDbContext _db;

		public TestServiceController() : this(new AppDbContext())
		{
			//TODO remove this constructor after mocking db in tests
		}

		public TestServiceController(IAppDbContext db)
		{
			_db = db;
		}

		// GET api/values
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
