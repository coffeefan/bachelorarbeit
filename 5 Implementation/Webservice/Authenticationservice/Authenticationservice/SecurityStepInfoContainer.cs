using SecurityStepContract;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Authenticationservice
{
    public class SecurityStepInfoContainer
    {
        private static SecurityStepInfoComposer securityStepInfoComposer =null;

        public void runSecurityStepInfoContainer()
        {
            SecurityStepInfoContainer.securityStepInfoComposer 
                = new SecurityStepInfoComposer().runSecurityStepInfoContainer();
        }

        public List<string> getSecurityStepInfos()
        {
            List<string> securityStepInfoNames = new List<string>();
            foreach (ISecurityStepInfo contract in securityStepInfoComposer.getSecurityStepInfo())
            {
                securityStepInfoNames.Add(contract.GetType().Name);
                
            }
            return securityStepInfoNames;
        }

        public ISecurityStepInfo getSecurityStepInfo(string name)
        {
            ISecurityStepInfo securityStepInfo = null;
            foreach (ISecurityStepInfo securityStepInfoItem in securityStepInfoComposer.getSecurityStepInfo())
            {
                if(securityStepInfoItem.GetType().Name== name)
                {
                    return securityStepInfoItem;
                }

            }
            return securityStepInfo;
        }
    }

    public class SecurityStepInfoComposer
    {
        [ImportMany(typeof(ISecurityStepInfo))]
        private ISecurityStepInfo[] securitystepinfos = null;

        public SecurityStepInfoComposer runSecurityStepInfoContainer()
        {
            var catalog = new DirectoryCatalog("./bin/");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            return this;
        }

        public ISecurityStepInfo[] getSecurityStepInfo()
        {
            return securitystepinfos;
        }
    }
      
}