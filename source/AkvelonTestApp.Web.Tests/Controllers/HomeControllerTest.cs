using System.Web.Mvc;
using AkvelonTestApp.Web.Controllers;

using NUnit.Framework;

namespace AkvelonTestApp.Web.Tests.Controllers
{
	[TestFixture]
	public class HomeControllerTest
	{
		[Test]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Home Page", result.ViewBag.Title);
		}
	}
}
