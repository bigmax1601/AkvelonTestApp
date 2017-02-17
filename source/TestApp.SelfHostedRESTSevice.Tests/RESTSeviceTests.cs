using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using TestApp.Data.Interfaces;
using TestApp.Data.Models;
using TestApp.SelfHostedRESTSevice.Core;
using TestApp.SelfHostedRESTSevice.Interfaces;
using TestApp.TestsLib;

namespace TestApp.SelfHostedRESTSevice.Tests
{
	[TestFixture]
    public class RESTSeviceTests
    {
		private IAppDbContext _dbMock;
		private IRESTService _RESTService;

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

			_RESTService = new RESTService(_dbMock);
		}

		[Test]
		public void GetUsers()
		{
			// Arrange

			// Act
			IEnumerable<string> result = _RESTService.GetAllUsers();

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
			UserModel result = _RESTService.GetUser(nickName);

			// Assert
			Assert.AreEqual(nickName, result.NickName);
			Assert.AreEqual(fullName, result.FullName);
		}

		[Test]
		public void CreateUser()
		{
			// Arrange
			int userCount = _dbMock.Users.Count();
			var user = new UserModel
			{
				NickName = "nickName3",
				FullName = "fullName3"
			};

			// Act
			_RESTService.CreateUser(user);
			var dbUser = _dbMock.Users.FirstOrDefault(i => i.NickName == user.NickName);

			// Assert
			Assert.IsNotNull(dbUser);
			Assert.AreEqual(user.FullName, dbUser.FullName);
			Assert.AreEqual(userCount + 1, _dbMock.Users.Count());
		}

		[Test]
		public void DeleteUser()
		{
			// Arrange
			int userCount = _dbMock.Users.Count();
			string nickName = "nickName1";

			// Act
			_RESTService.DeleteUser(nickName);
			var user = _dbMock.Users.FirstOrDefault(i => i.NickName == nickName);

			// Assert
			Assert.IsNull(user);
			Assert.AreEqual(userCount - 1, _dbMock.Users.Count());
		}

		[Test]
		public void UpdateExistingUser()
		{
			// Arrange
			int userCount = _dbMock.Users.Count();
			var user = new UserModel
			{
				NickName = "nickName2",
				FullName = "fullName222"
			};

			// Act
			_RESTService.UpdateUser(user.NickName, user);
			var dbUser = _dbMock.Users.FirstOrDefault(i => i.NickName == user.NickName);

			// Assert
			Assert.IsNotNull(dbUser);
			Assert.AreEqual(user.FullName, dbUser.FullName);
			Assert.AreEqual(userCount, _dbMock.Users.Count());
		}

		[Test]
		public void UpdateNotExistingUser()
		{
			// Arrange
			int userCount = _dbMock.Users.Count();
			var user = new UserModel
			{
				NickName = "nickName3",
				FullName = "fullName3"
			};

			// Act
			_RESTService.UpdateUser(user.NickName, user);
			var dbUser = _dbMock.Users.FirstOrDefault(i => i.NickName == user.NickName);

			// Assert
			Assert.IsNotNull(dbUser);
			Assert.AreEqual(user.FullName, dbUser.FullName);
			Assert.AreEqual(userCount + 1, _dbMock.Users.Count());
		}


		[TearDown]
		public void TearDown()
		{
			_RESTService = null;
		}
	}
}
