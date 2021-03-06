// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using TestApp.Data;
using TestApp.Data.Interfaces;
using TestApp.Web.Areas.HelpPage.Controllers;

using StructureMap;
using StructureMap.Web.Pipeline;

namespace TestApp.Web.DependencyResolution
{
	public class DefaultRegistry : Registry
	{
		#region Constructors and Destructors

		public DefaultRegistry()
		{
			Scan(
				scan =>
				{
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
				});

			For<IAppDbContext>()
				.LifecycleIs(new HttpContextLifecycle())
				.Use(i => new AppDbContext());

			// http://stackoverflow.com/questions/19687841/structuremap-exception-after-adding-the-webapi-helppage-to-a-webapi-project
			For<HelpController>()
				.LifecycleIs(new HttpContextLifecycle()) // http context
				.Use(ctx => new HelpController());

			//For<IExample>().Use<Example>();
		}

		#endregion
	}
}