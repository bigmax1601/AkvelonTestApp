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
		[WebGet(UriTemplate = Confguration.Routing.GetUsersRoute)]
		IEnumerable<string> GetAllUsers();

		//GET Operation
		[OperationContract]
		[WebGet(UriTemplate = Confguration.Routing.GetUserRoute)]
		UserModel GetUser(string nickName);

		//POST Operation
		[OperationContract]
		[WebInvoke(UriTemplate = Confguration.Routing.CreateUserRoute, Method = "POST")]
		UserModel CreateUser(UserModel user);

		//PUT Operation
		[OperationContract]
		[WebInvoke(UriTemplate = Confguration.Routing.UpdateUserRoute, Method = "PUT")]
		UserModel UpdateUser(string nickName, UserModel user);

		//DELETE Operation
		[OperationContract]
		[WebInvoke(UriTemplate = Confguration.Routing.DeleteUserRoute, Method = "DELETE")]
		void DeleteUser(string nickName);
	}
}