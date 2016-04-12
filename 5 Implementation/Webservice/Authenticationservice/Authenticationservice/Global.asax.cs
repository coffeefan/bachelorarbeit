using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Authenticationservice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AntiForgeryConfig.SuppressXFrameOptionsHeader = true;
            var pluginFolders = new List<string>();

            var plugins = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules")).ToList();

            plugins.ForEach(s =>
            {
                var di = new DirectoryInfo(s);
                pluginFolders.Add(di.Name);
            });

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Compose(pluginFolders);
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
            ViewEngines.Engines.Add(new CustomViewEngine(pluginFolders));

            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
