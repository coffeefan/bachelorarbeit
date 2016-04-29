using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

        public void SaveSMSSecurityConfigByProjectId(SMSSecurityStepConfig smsSecurityStepConfig)
        {
            _db.SMSSecurityStepConfigs.RemoveRange(
            _db.SMSSecurityStepConfigs.Where(essc => essc.ProjectId == smsSecurityStepConfig.ProjectId));
            _db.SaveChanges();

            try
            {
                _db.SMSSecurityStepConfigs.Add(smsSecurityStepConfig);
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string errormessage = ""; 
                foreach (var eve in e.EntityValidationErrors)
                {             

                    foreach (var ve in eve.ValidationErrors)
                    {
                        errormessage +=ve.ErrorMessage;
                    }

                }
                throw new HttpException(510, errormessage);
            }
                
           
        }
        
    }
}