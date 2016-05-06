using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneSecurityStep.Models
{
    public class EF_PhoneSecurityStepValidationRepository : PhoneSecurityStep.Models.IPhoneSecurityStepValidationRepository, IDisposable
    {
        private int maxSend = 10;
        private ApplicationDbContext _db = new ApplicationDbContext();

        public void CreateNewPhoneSecurityStepValidation(PhoneSecurityStepValidation PhoneSecurityStepValidation)
        {
            _db.PhoneSecurityStepValidations.Add(PhoneSecurityStepValidation);
            _db.SaveChanges();
            
        }

        public IEnumerable<PhoneSecurityStepValidation> GetAllPhoneSecurityStepValidations()
        {
            return _db.PhoneSecurityStepValidations.ToList();
        }

        public bool IsMobileNumberUsed(string mobileNumber, int projectid)
        {
            if(_db.PhoneSecurityStepValidations.Where(essv => essv.PhoneNumber == mobileNumber
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

            var sum= (from Phonevalidation in _db.PhoneSecurityStepValidations
                     where Phonevalidation.StatusId!= 1
                     group Phonevalidation by Phonevalidation.PhoneNumber into grouped
                     where grouped.Key== mobileNumber
                      select new {total=grouped.Sum(i => i.PhoneSendCount) }).FirstOrDefault();
            if (sum == null)
            {
                return 0;
            }
            return sum.total;
        }

        public PhoneSecurityStepValidation GetPhoneSecurityStepValidationByID(int id)
        {
            return _db.PhoneSecurityStepValidations.FirstOrDefault(essv => essv.PhoneSecurityStepValidationId == id && essv.IsDeleted != true);
        }

        public PhoneSecurityStepValidation GetPhoneSecurityStepValidationForValid(int projectid, string providerid)
        {
            return _db.PhoneSecurityStepValidations.FirstOrDefault(essv => essv.ProjectId== projectid 
                && essv.ProviderId== providerid && essv.IsDeleted != true);
        }



        public void UpdatePhoneSecurityStepValidation(PhoneSecurityStepValidation PhoneSecurityStepValidation)
        {
            
            PhoneSecurityStepValidation essvtemp=
                _db.PhoneSecurityStepValidations.FirstOrDefault(essv => essv.PhoneSecurityStepValidationId == PhoneSecurityStepValidation.PhoneSecurityStepValidationId);

            essvtemp = PhoneSecurityStepValidation;
            _db.Entry(essvtemp).State= EntityState.Modified;
            _db.SaveChanges();

        }

        public void resetPhoneSecurityStepValidationByValid(int projectid, string providerid)
        {
            var phoneSecurityStepValidationList =_db.PhoneSecurityStepValidations.Where(essv => essv.ProjectId == projectid
                    && essv.ProviderId == providerid && essv.StatusId != 1 && essv.IsDeleted != true).ToList();
            foreach (PhoneSecurityStepValidation temp 
                in phoneSecurityStepValidationList)
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