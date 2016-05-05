using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassportSecurityStep.Models;

namespace PassportSecurityStep.Tests.Models
{
    class InMemory_PassportSecurityStepValidationRepository : IPassportSecurityStepValidationRepository
    {
        private List<PassportSecurityStepValidation> _db = new List<PassportSecurityStepValidation>();

        public Exception ExceptionToThrow { get; set; }

        public void CreateNewPassportSecurityStepValidation(PassportSecurityStepValidation PassportSecurityStepValidation)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(PassportSecurityStepValidation);
        }

        public IEnumerable<PassportSecurityStepValidation> GetAllPassportSecurityStepValidations()
        {
            return _db.ToList();
        }

        public PassportSecurityStepValidation GetPassportSecurityStepValidationByID(int id)
        {
            return _db.FirstOrDefault(essv => essv.PassportSecurityStepValidationId == id);
        }

        public PassportSecurityStepValidation GetPassportSecurityStepValidationForValid(int projectid, string providerid)
        {
            return _db.FirstOrDefault(essv => essv.ProjectId == projectid && essv.ProviderId == providerid);
        }

        public bool IsMaxSend(string mobileNumber)
        {
            if (sumMobileNumberUsed(mobileNumber) >= 10)
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

            var sum = (from Passportvalidation in _db
                       where Passportvalidation.StatusId != 1
                       group Passportvalidation by Passportvalidation.PassportNumber into grouped
                       where grouped.Key == mobileNumber
                       select new { total = grouped.Sum(i => i.PassportSendCount) }).FirstOrDefault();
            if (sum == null)
            {
                return 0;
            }
            return sum.total;
        }

        public bool IsPassportUsed(string passportNumber, int projectid)
        {
            if (_db.Where(essv => essv.PassportNumber == passportNumber
                 && essv.ProjectId == projectid
                 && essv.StatusId == 1).Count() > 0)
            {
                return true;
            }
            return false;
        }



       

        public void resetPassportSecurityStepValidationByValid(int projectid, string providerid)
        {
            foreach(PassportSecurityStepValidation essvtemp 
                in _db.Where(essv => essv.ProjectId == projectid && essv.ProviderId == providerid && essv.StatusId != 1))
            {
                _db.Remove(essvtemp);
            }
        }



        public void UpdatePassportSecurityStepValidation(PassportSecurityStepValidation PassportSecurityStepValidation)
        {
            var essvtemp =
                _db.FirstOrDefault(essv => essv.PassportSecurityStepValidationId == PassportSecurityStepValidation.PassportSecurityStepValidationId);

            essvtemp.PassportNumber = PassportSecurityStepValidation.PassportNumber;
            essvtemp.CodeEntered = PassportSecurityStepValidation.CodeEntered;
           
            essvtemp.StatusId = PassportSecurityStepValidation.StatusId;
            essvtemp.PassportSecurityStepValidationId = PassportSecurityStepValidation.PassportSecurityStepValidationId;
            essvtemp.ProjectId = PassportSecurityStepValidation.ProjectId;
            essvtemp.ProviderId = PassportSecurityStepValidation.ProviderId;
            essvtemp.Created = PassportSecurityStepValidation.Created;

        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       