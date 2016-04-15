using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EMailSecurityStep.Models
{
    public class EF_EMailSecurityStepConfigRepository : EMailSecurityStep.Models.IEMailSecurityStepConfigRepository
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public EMailSecurityStepConfig GetEMailSecurityStepConfigByProjectId(int projectid)
        {
            return _db.EMailSecurityStepConfigs.FirstOrDefault(essc => essc.ProjectId == projectid);
        }

        public void SaveEMailSecurityConfigByProjectId(EMailSecurityStepConfig eMailSecurityStepConfig)
        {
            _db.EMailSecurityStepConfigs.RemoveRange(
            _db.EMailSecurityStepConfigs.Where(essc => essc.ProjectId == eMailSecurityStepConfig.ProjectId));
            _db.SaveChanges();
            _db.EMailSecurityStepConfigs.Add(eMailSecurityStepConfig);
            _db.SaveChanges();
        }
        
    }
}