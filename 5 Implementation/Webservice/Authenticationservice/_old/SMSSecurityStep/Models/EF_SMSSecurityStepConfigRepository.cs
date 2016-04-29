using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SMSSecurityStep.Models
{
    public class EF_SMSSecurityStepConfigRepository : SMSSecurityStep.Models.ISMSSecurityStepConfigRepository
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public SMSSecurityStepConfig GetSMSSecurityStepConfigByProjectId(int projectid)
        {
            return _db.SMSSecurityStepConfigs.FirstOrDefault(essc => essc.ProjectId == projectid);
        }

        public void SaveEMailSecurityConfigByProjectId(SMSSecurityStepConfig SMSSecurityStepConfig)
        {
            _db.SMSSecurityStepConfigs.RemoveRange(
            _db.SMSSecurityStepConfigs.Where(essc => essc.ProjectId == SMSSecurityStepConfig.ProjectId));
            _db.SaveChanges();
            _db.SMSSecurityStepConfigs.Add(SMSSecurityStepConfig);
            _db.SaveChanges();
        }
        
    }
}