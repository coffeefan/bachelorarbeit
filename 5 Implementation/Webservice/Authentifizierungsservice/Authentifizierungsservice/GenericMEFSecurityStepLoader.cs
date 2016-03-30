using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;

namespace Authentifizierungsservice
{
   
    public class GenericMEFSecurityStepLoader<T>
    {
        private CompositionContainer _Container;

        [ImportMany]
        public IEnumerable<T> SecuritySteps
        {
            get;
            set;
        }

        public GenericMEFSecurityStepLoader(string path)
        {
            DirectoryCatalog directoryCatalog = new DirectoryCatalog(path);

            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog(directoryCatalog);

            // Create the CompositionContainer with all parts in the catalog (links Exports and Imports)
            _Container = new CompositionContainer(catalog);

            //Fill the imports of this object
            _Container.ComposeParts(this);
        }

        public GenericMEFSecurityStepLoader(ref CompositionContainer container, string path)
        {
            DirectoryCatalog directoryCatalog = new DirectoryCatalog(path);

            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog(directoryCatalog);

            // Create the CompositionContainer with all parts in the catalog (links Exports and Imports)
            container = new CompositionContainer(catalog);

            //Fill the imports of this object
            container.ComposeParts(this);
        }
    }
}