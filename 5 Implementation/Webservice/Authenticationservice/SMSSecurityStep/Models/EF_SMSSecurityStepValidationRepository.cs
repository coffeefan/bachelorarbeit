using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SMSSecurityStep.Models
{
    public class EF_SMSSecurityStepValidationRepository : SMSSecurityStep.Models.ISMSSecurityStepValidationRepository, IDisposable
    {
        private int maxSend = 10;
        private ApplicationDbContext _db = new ApplicationDbContext();

        public void CreateNewSMSSecurityStepValidation(SMSSecurityStepValidation SMSSecurityStepValidation)
        {
            _db.SMSSecurityStepValidations.Add(SMSSecurityStepValidation);
            _db.SaveChanges();
            
        }

        public IEnumerable<SMSSecurityStepValidation> GetAllSMSSecurityStepValidations()
        {
            return _db.SMSSecurityStepValidations.ToList();
        }

        public bool IsMobileNumberUsed(string mobileNumber, int projectid)
        {
            if(_db.SMSSecurityStepValidations.Where(essv => essv.MobileNumber == mobileNumber
                && essv.ProjectId == projectid 
                && essv.StatusId== 1).Count() > 0)
            {
                
                return true;
            }

            

            return false;
        }

        public bool IsMaxSend(string mobileNumber)
        {
            if (sumMobileNumberUsed(mobileNumber) >= maxSend)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int sumMobileNumberUsed(string mobileNumber)
        {

            var sum= (from smsvalidation in _db.SMSSecurityStepValidations
                     where smsvalidation.StatusId!= 1
                     group smsvalidation by smsvalidation.MobileNumber into grouped
                     where grouped.Key== mobileNumber
                      select new {total=grouped.Sum(i => i.SMSSendCount) }).FirstOrDefault();
            if (sum == null)
            {
                return 0;
            }
            return sum.total;
        }

        public SMSSecurityStepValidation GetSMSSecurityStepValidationByID(int id)
        {
            return _db.SMSSecurityStepValidations.FirstOrDefault(essv => essv.SMSSecurityStepValidationId == id && essv.IsDeleted != true);
        }

        public SMSSecurityStepValidation GetSMSSecurityStepValidationForValid(int projectid, string providerid)
        {
            return _db.SMSSecurityStepValidations.FirstOrDefault(essv => essv.ProjectId== projectid 
                && essv.ProviderId== providerid && essv.IsDeleted != true);
        }



        public void UpdateSMSSecurityStepValidation(SMSSecurityStepValidation SMSSecurityStepValidation)
        {
            
            SMSSecurityStepValidation essvtemp=
                _db.SMSSecurityStepValidations.FirstOrDefault(essv => essv.SMSSecurityStepValidationId == SMSSecurityStepValidation.SMSSecurityStepValidationId);

            essvtemp = SMSSecurityStepValidation;
            _db.Entry(essvtemp).State= EntityState.Modified;
            _db.SaveChanges();

        }

        public void resetSMSSecurityStepValidationByValid(int projectid, string providerid)
        {
            var sMSSecurityStepValidationList = _db.SMSSecurityStepValidations.Where(essv => essv.ProjectId == projectid
                     && essv.ProviderId == providerid && essv.StatusId != 1 && essv.IsDeleted != true).ToList();
            foreach (SMSSecurityStepValidation temp 
                in sMSSecurityStepValidationList)
            {
                temp.IsDeleted = true;
                _db.Entry(temp).State = EntityState.Modified;
                _db.SaveChanges();
            }
            
            
            _db.SaveChanges();
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