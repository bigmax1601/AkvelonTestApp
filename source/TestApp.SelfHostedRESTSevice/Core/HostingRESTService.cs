using System;
using System.ServiceModel.Web;

using TestApp.SelfHostedRESTSevice.Interfaces;

namespace TestApp.SelfHostedRESTSevice.Core
{
	public class HostingRESTService
	{
		private readonly IRESTService _service;
		private readonly WebServiceHost _host;

		public HostingRESTService(IRESTService service, params Uri[] baseAdresses)
		{
			_service = service;
			_host = new WebServiceHost(service, baseAdresses);
		}

		public void Start()
		{
			_host.Open();
		}

		public void Stop()
		{
			_host.Close();
			((IDisposable)_host).Dispose();
		}
	}
}