using System.Collections.Generic;
using System.Linq;

using TestApp.Data.Interfaces;
using TestApp.Data.Models;
using TestApp.Web.Controllers;
using NUnit.Framework;
using Moq;

namespace TestApp.Web.Tests.Controllers
{
	[TestFixture]
	public class TestServiceControllerTest
	{
		private TestServiceController _controller;
		private IAppDbContext _dbMock;

		[SetUp]
		public void SetUp()
		{
			var mock = new Mock<IAppDbContext>();
			mock.Setup(x => x.Users)
				.Returns(new FakeDbSet<UserModel>
				{
					new UserModel {NickName = "nickName1", FullName = "fullName1"},
					new UserModel {NickName = "nickName2", FullName = "fullName2"},
				});
			_dbMock = mock.Object;

			_controller = new TestServiceController(_dbMock);
		}

		[Test]
		public void GetUsers()
		{
			// Arrange

			// Act
			IEnumerable<string> result = _controller.Users();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.Count());
			Assert.AreEqual("nickName1", result.ElementAt(0));
			Assert.AreEqual("nickName2", result.ElementAt(1));
		}

		[Test, TestCase("nickName1", "fullName1"), TestCase("nickName2", "fullName2")]
		public void GetUserByNickName(string nickName, string fullName)
		{
			// Arrange


			// Act
			UserModel result = _controller.GetUser(nickName);

			// Assert
			Assert.AreEqual(nickName, result.NickName);
			Assert.AreEqual(fullName, result.FullName);
		}

		[Test]
		public void CreateUser()
		{
			// Arrange
			string nickName = "nickName3";
			string fullName = "fullName3";

			// Act
			int userCount = _dbMock.Users.Count();
			_controller.CreateUser(nickName, fullName);
			var user = _dbMock.Users.FirstOrDefault(i => i.NickName == nickName);

			// Assert
			Assert.IsNotNull(user);
			Assert.AreEqual(fullName, user.FullName);
			Assert.AreEqual(userCount + 1, _dbMock.Users.Count());
		}

		[Test]
		public void DeleteUser()
		{
			// Arrange
			string nickName = "nickName1";

			// Act
			int userCount = _dbMock.Users.Count();
			_controller.DeleteUser(nickName);
			var user = _dbMock.Users.FirstOrDefault(i => i.NickName == nickName);

			// Assert
			Assert.IsNull(user);
			Assert.AreEqual(userCount - 1, _dbMock.Users.Count());
		}

		[Test]
		public void UpdateExistingUser()
		{
			// Arrange
			string nickName = "nickName1";
			string fullName = "fullName3";

			// Act
			int userCount = _dbMock.Users.Count();
			_controller.UpdateUser(nickName, fullName);
			var user = _dbMock.Users.FirstOrDefault(i => i.NickName == nickName);

			// Assert
			Assert.IsNotNull(user);
			Assert.AreEqual(fullName, user.FullName);
			Assert.AreEqual(userCount, _dbMock.Users.Count());
		}

		[Test]
		public void UpdateNotExistingUser()
		{
			// Arrange
			string nickName = "nickName4";
			string fullName = "fullName4";

			// Act
			int userCount = _dbMock.Users.Count();
			_controller.UpdateUser(nickName, fullName);
			var user = _dbMock.Users.FirstOrDefault(i => i.NickName == nickName);

			// Assert
			Assert.IsNotNull(user);
			Assert.AreEqual(fullName, user.FullName);
			Assert.AreEqual(userCount + 1, _dbMock.Users.Count());
		}


		[TearDown]
		public void TearDown()
		{
			_controller.Dispose();
			_controller = null;
		}
	}
}
