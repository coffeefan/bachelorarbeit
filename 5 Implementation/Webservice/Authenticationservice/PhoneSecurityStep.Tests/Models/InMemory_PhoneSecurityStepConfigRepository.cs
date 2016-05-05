using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneSecurityStep.Models
{
    public class InMemory_PhoneSecurityStepConfigRepository : PhoneSecurityStep.Models.IPhoneSecurityStepConfigRepository
    {

        private List<PhoneSecurityStepConfig> _db = new List<PhoneSecurityStepConfig>();

        public PhoneSecurityStepConfig GetPhoneSecurityStepConfigByProjectId(int projectid)
        {
            return _db.FirstOrDefault(essc => essc.ProjectId == projectid);
        }

        public void SavePhoneSecurityConfigByProjectId(PhoneSecurityStepConfig PhoneSecurityStepConfig)
        {
            foreach (PhoneSecurityStepConfig essvtemp
               in _db.Where(essv => essv.ProjectId == PhoneSecurityStepConfig.ProjectId))
            {
                _db.Remove(essvtemp);
            }
            _db.Add(PhoneSecurityStepConfig);
        }
        
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              