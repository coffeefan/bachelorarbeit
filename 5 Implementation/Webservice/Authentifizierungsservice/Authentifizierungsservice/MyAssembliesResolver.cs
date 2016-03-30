using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Dispatcher;

namespace Authentifizierungsservice
{
    public class MyAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>(base.GetAssemblies());

            // Add all plugin assemblies containing the controller classes
            String link = @"C:\Project\Bachelorarbeit\5 Implementation\Webservice\Authentifizierungsservice\Authentifizierungsservice\bin\Plugins\PhoneSecurityStep.dll";
            assemblies.Add(Assembly.LoadFrom(link));

            return assemblies;
        }
    }
}