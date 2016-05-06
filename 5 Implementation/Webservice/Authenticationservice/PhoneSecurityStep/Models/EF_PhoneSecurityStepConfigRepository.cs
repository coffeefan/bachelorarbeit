using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace PhoneSecurityStep.Models
{
    public class EF_PhoneSecurityStepConfigRepository : PhoneSecurityStep.Models.IPhoneSecurityStepConfigRepository, IDisposable
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public PhoneSecurityStepConfig GetPhoneSecurityStepConfigByProjectId(int projectid)
        {
            return _db.PhoneSecurityStepConfigs.FirstOrDefault(essc => essc.ProjectId == projectid);
        }

        public void SavePhoneSecurityConfigByProjectId(PhoneSecurityStepConfig PhoneSecurityStepConfig)
        {
            _db.PhoneSecurityStepConfigs.RemoveRange(
            _db.PhoneSecurityStepConfigs.Where(essc => essc.ProjectId == PhoneSecurityStepConfig.ProjectId));
            _db.SaveChanges();

            try
            {
                _db.PhoneSecurityStepConfigs.Add(PhoneSecurityStepConfig);
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._db != null)
            {
                this._db.Dispose();
                this._db = null;
            }
        }

    }
}