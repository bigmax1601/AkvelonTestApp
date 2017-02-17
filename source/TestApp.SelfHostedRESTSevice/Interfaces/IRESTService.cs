using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

using TestApp.Data.Models;

namespace TestApp.SelfHostedRESTSevice.Interfaces
{
	[ServiceContract]
	public interface IRESTService
	{
		//GET operation
		[OperationContract]
		[WebGet(UriTemplate = Configuration.Routing.GetUsersRoute)]
		IEnumerable<string> GetAllUsers();

		//GET Operation
		[OperationContract]
		[WebGet(UriTemplate = Configuration.Routing.GetUserRoute)]
		UserModel GetUser(string nickName);

		//POST Operation
		[OperationContract]
		[WebInvoke(UriTemplate = Configuration.Routing.CreateUserRoute, Method = "POST")]
		UserModel CreateUser(UserModel user);

		//PUT Operation
		[OperationContract]
		[WebInvoke(UriTemplate = Configuration.Routing.UpdateUserRoute, Method = "PUT")]
		UserModel UpdateUser(string nickName, UserModel user);

		//DELETE Operation
		[OperationContract]
		[WebInvoke(UriTemplate = Configuration.Routing.DeleteUserRoute, Method = "DELETE")]
		void DeleteUser(string nickName);
	}
}