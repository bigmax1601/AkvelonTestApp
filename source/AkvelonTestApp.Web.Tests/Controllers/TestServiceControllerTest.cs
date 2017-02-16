using System.Collections.Generic;
using System.Linq;

using AkvelonTestApp.Web.Controllers;
using NUnit.Framework;

namespace AkvelonTestApp.Web.Tests.Controllers
{
	[TestFixture]
	public class TestServiceControllerTest
	{
		private TestServiceController controller;

		[OneTimeSetUp]
		public void SetUp()
		{
			controller = new TestServiceController();
		}

		[Test]
		public void Get()
		{
			// Arrange

			// Act
			IEnumerable<string> result = controller.Get();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.Count());
			Assert.AreEqual("value1", result.ElementAt(0));
			Assert.AreEqual("value2", result.ElementAt(1));
		}

		[Test]
		public void GetById()
		{
			// Arrange

			// Act
			string result = controller.Get(5);

			// Assert
			Assert.AreEqual("value", result);
		}

		[Test]
		public void Post()
		{
			// Arrange

			// Act
			controller.Post("value");

			// Assert
		}

		[Test]
		public void Put()
		{
			// Arrange

			// Act
			controller.Put(5, "value");

			// Assert
		}

		[Test]
		public void Delete()
		{
			// Arrange

			// Act
			controller.Delete(5);

			// Assert
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			controller.Dispose();
			controller = null;
		}
	}
}
