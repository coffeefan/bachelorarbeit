using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassportSecurityStep.Models
{
    public class InMemory_PassportSecurityStepConfigRepository : PassportSecurityStep.Models.IPassportSecurityStepConfigRepository
    {

        private List<PassportSecurityStepConfig> _db = new List<PassportSecurityStepConfig>();

        public PassportSecurityStepConfig GetPassportSecurityStepConfigByProjectId(int projectid)
        {
            return _db.FirstOrDefault(essc => essc.ProjectId == projectid);
        }

        public void SavePassportSecurityConfigByProjectId(PassportSecurityStepConfig PassportSecurityStepConfig)
        {
            foreach (PassportSecurityStepConfig essvtemp
               in _db.Where(essv => essv.ProjectId == PassportSecurityStepConfig.ProjectId))
            {
                _db.Remove(essvtemp);
            }
            _db.Add(PassportSecurityStepConfig);
        }
        
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              