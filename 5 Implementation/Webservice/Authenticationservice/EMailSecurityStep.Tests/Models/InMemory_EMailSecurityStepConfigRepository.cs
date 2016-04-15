using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMailSecurityStep.Models
{
    public class InMemory_EMailSecurityStepConfigRepository : EMailSecurityStep.Models.IEMailSecurityStepConfigRepository
    {

        private List<EMailSecurityStepConfig> _db = new List<EMailSecurityStepConfig>();

        public EMailSecurityStepConfig GetEMailSecurityStepConfigByProjectId(int projectid)
        {
            return _db.FirstOrDefault(essc => essc.ProjectId == projectid);
        }

        public void SaveEMailSecurityConfigByProjectId(EMailSecurityStepConfig eMailSecurityStepConfig)
        {
            foreach (EMailSecurityStepConfig essvtemp
               in _db.Where(essv => essv.ProjectId == eMailSecurityStepConfig.ProjectId))
            {
                _db.Remove(essvtemp);
            }
            _db.Add(eMailSecurityStepConfig);
        }
        
    }
}