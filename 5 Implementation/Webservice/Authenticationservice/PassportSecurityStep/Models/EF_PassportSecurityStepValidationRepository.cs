using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PassportSecurityStep.Models
{
    public class EF_PassportSecurityStepValidationRepository : PassportSecurityStep.Models.IPassportSecurityStepValidationRepository
    {
        private int maxSend = 10;
        private ApplicationDbContext _db = new ApplicationDbContext();

        public void CreateNewPassportSecurityStepValidation(PassportSecurityStepValidation PassportSecurityStepValidation)
        {
            _db.PassportSecurityStepValidations.Add(PassportSecurityStepValidation);
            _db.SaveChanges();
            
        }

        public IEnumerable<PassportSecurityStepValidation> GetAllPassportSecurityStepValidations()
        {
            return _db.PassportSecurityStepValidations.ToList();
        }

        public bool IsPassportUsed(string mobileNumber, int projectid)
        {
            if(_db.PassportSecurityStepValidations.Where(essv => essv.PassportNumber == mobileNumber
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

            var sum= (from Passportvalidation in _db.PassportSecurityStepValidations
                     where Passportvalidation.StatusId!= 1
                     group Passportvalidation by Passportvalidation.PassportNumber into grouped
                     where grouped.Key== mobileNumber
                      select new {total=grouped.Sum(i => i.PassportSendCount) }).FirstOrDefault();
            if (sum == null)
            {
                return 0;
            }
            return sum.total;
        }

        public PassportSecurityStepValidation GetPassportSecurityStepValidationByID(int id)
        {
            return _db.PassportSecurityStepValidations.FirstOrDefault(essv => essv.PassportSecurityStepValidationId == id && essv.IsDeleted != true);
        }

        public PassportSecurityStepValidation GetPassportSecurityStepValidationForValid(int projectid, string providerid)
        {
            return _db.PassportSecurityStepValidations.FirstOrDefault(essv => essv.ProjectId== projectid 
                && essv.ProviderId== providerid && essv.IsDeleted != true);
        }



        public void UpdatePassportSecurityStepValidation(PassportSecurityStepValidation PassportSecurityStepValidation)
        {
            
            PassportSecurityStepValidation essvtemp=
                _db.PassportSecurityStepValidations.FirstOrDefault(essv => essv.PassportSecurityStepValidationId == PassportSecurityStepValidation.PassportSecurityStepValidationId);

            essvtemp = PassportSecurityStepValidation;
            _db.Entry(essvtemp).State= EntityState.Modified;
            _db.SaveChanges();

        }

        public void resetPassportSecurityStepValidationByValid(int projectid, string providerid)
        {
            var PassportSecurityStepValidationList =_db.PassportSecurityStepValidations.Where(essv => essv.ProjectId == projectid
                    && essv.ProviderId == providerid && essv.StatusId != 1 && essv.IsDeleted != true).ToList();
            foreach (PassportSecurityStepValidation temp 
                in PassportSecurityStepValidationList)
            {
                temp.IsDeleted = true;
                _db.Entry(temp).State = EntityState.Modified;
                _db.SaveChanges();
            }
            
            
            _db.SaveChanges();
        }
    }
}