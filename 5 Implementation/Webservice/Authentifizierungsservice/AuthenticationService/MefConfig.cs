using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationService
{
    public static class MefConfig
        {
            public static void RegisterMef()
            {
                var container = ConfigureContainer();

                ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(container));

                var dependencyResolver = System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver;
            }

            private static CompositionContainer ConfigureContainer()
            {
                var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                var container = new CompositionContainer(assemblyCatalog);

                return container;
            }
        }
    
}