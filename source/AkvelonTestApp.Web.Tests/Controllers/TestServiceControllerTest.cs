using System.Collections.Generic;
using System.Linq;

using AkvelonTestApp.Web.Controllers;
using NUnit.Framework;

namespace AkvelonTestApp.Web.Tests.Controllers
{
	[TestFixture]
	public class TestServiceControllerTest
	{
		[Test]
		public void Get()
		{
			// Arrange
			TestServiceController controller = new TestServiceController();

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
			TestServiceController controller = new TestServiceController();

			// Act
			string result = controller.Get(5);

			// Assert
			Assert.AreEqual("value", result);
		}

		[Test]
		public void Post()
		{
			// Arrange
			TestServiceController controller = new TestServiceController();

			// Act
			controller.Post("value");

			// Assert
		}

		[Test]
		public void Put()
		{
			// Arrange
			TestServiceController controller = new TestServiceController();

			// Act
			controller.Put(5, "value");

			// Assert
		}

		[Test]
		public void Delete()
		{
			// Arrange
			TestServiceController controller = new TestServiceController();

			// Act
			controller.Delete(5);

			// Assert
		}
	}
}
