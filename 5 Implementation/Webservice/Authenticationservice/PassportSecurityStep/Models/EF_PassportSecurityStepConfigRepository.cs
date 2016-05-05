using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace PassportSecurityStep.Models
{
    public class EF_PassportSecurityStepConfigRepository : PassportSecurityStep.Models.IPassportSecurityStepConfigRepository
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public PassportSecurityStepConfig GetPassportSecurityStepConfigByProjectId(int projectid)
        {
            return _db.PassportSecurityStepConfigs.FirstOrDefault(essc => essc.ProjectId == projectid);
        }

        public void SavePassportSecurityConfigByProjectId(PassportSecurityStepConfig PassportSecurityStepConfig)
        {
            _db.PassportSecurityStepConfigs.RemoveRange(
            _db.PassportSecurityStepConfigs.Where(essc => essc.ProjectId == PassportSecurityStepConfig.ProjectId));
            _db.SaveChanges();

            try
            {
                _db.PassportSecurityStepConfigs.Add(PassportSecurityStepConfig);
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