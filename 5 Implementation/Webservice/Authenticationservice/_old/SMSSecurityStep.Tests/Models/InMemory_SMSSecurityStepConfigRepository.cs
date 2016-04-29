using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SMSSecurityStep.Models
{
    public class InMemory_SMSSecurityStepConfigRepository : SMSSecurityStep.Models.ISMSSecurityStepConfigRepository
    {

        private List<SMSSecurityStepConfig> _db = new List<SMSSecurityStepConfig>();

        public SMSSecurityStepConfig GetSMSSecurityStepConfigByProjectId(int projectid)
        {
            return _db.FirstOrDefault(essc => essc.ProjectId == projectid);
        }

        public void SaveEMailSecurityConfigByProjectId(SMSSecurityStepConfig SMSSecurityStepConfig)
        {
            foreach (SMSSecurityStepConfig essvtemp
               in _db.Where(essv => essv.ProjectId == SMSSecurityStepConfig.ProjectId))
            {
                _db.Remove(essvtemp);
            }
            _db.Add(SMSSecurityStepConfig);
        }
        
    }
}