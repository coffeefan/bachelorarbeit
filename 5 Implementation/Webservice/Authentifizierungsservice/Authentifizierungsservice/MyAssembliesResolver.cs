using System;
using System.Collections.Generic;
using System.IO;
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
            String path = @"C:\Project\Bachelorarbeit\5 Implementation\Webservice\Authentifizierungsservice\Authentifizierungsservice\bin\Plugins\";

            List<string> filesInddrectory = ProcessDirectory(path, ".dll");
            foreach(string fileName in filesInddrectory)
            {
                assemblies.Add(Assembly.LoadFrom(fileName));
            }
            

            return assemblies;
        }

        public static List<string> ProcessDirectory(string targetDirectory,string ending)
        {
            List<string> filesInddrectory = new List<string>();
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                if (fileName.Trim().EndsWith(ending))
                {
                    filesInddrectory.Add(fileName);
                }

            return filesInddrectory;
        }
    }
}