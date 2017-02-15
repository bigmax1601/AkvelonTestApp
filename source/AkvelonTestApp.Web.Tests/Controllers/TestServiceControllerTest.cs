using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AkvelonTestApp.Web;
using AkvelonTestApp.Web.Controllers;

namespace AkvelonTestApp.Web.Tests.Controllers
{
	[TestClass]
	public class TestServiceControllerTest
	{
		[TestMethod]
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

		[TestMethod]
		public void GetById()
		{
			// Arrange
			TestServiceController controller = new TestServiceController();

			// Act
			string result = controller.Get(5);

			// Assert
			Assert.AreEqual("value", result);
		}

		[TestMethod]
		public void Post()
		{
			// Arrange
			TestServiceController controller = new TestServiceController();

			// Act
			controller.Post("value");

			// Assert
		}

		[TestMethod]
		public void Put()
		{
			// Arrange
			TestServiceController controller = new TestServiceController();

			// Act
			controller.Put(5, "value");

			// Assert
		}

		[TestMethod]
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
