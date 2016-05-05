using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneSecurityStep.Models;

namespace PhoneSecurityStep.Tests.Models
{
    class InMemory_PhoneSecurityStepValidationRepository : IPhoneSecurityStepValidationRepository
    {
        private List<PhoneSecurityStepValidation> _db = new List<PhoneSecurityStepValidation>();

        public Exception ExceptionToThrow { get; set; }

        public void CreateNewPhoneSecurityStepValidation(PhoneSecurityStepValidation PhoneSecurityStepValidation)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(PhoneSecurityStepValidation);
        }

        public IEnumerable<PhoneSecurityStepValidation> GetAllPhoneSecurityStepValidations()
        {
            return _db.ToList();
        }

        public PhoneSecurityStepValidation GetPhoneSecurityStepValidationByID(int id)
        {
            return _db.FirstOrDefault(essv => essv.PhoneSecurityStepValidationId == id);
        }

        public PhoneSecurityStepValidation GetPhoneSecurityStepValidationForValid(int projectid, string providerid)
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

            var sum = (from Phonevalidation in _db
                       where Phonevalidation.StatusId != 1
                       group Phonevalidation by Phonevalidation.PhoneNumber into grouped
                       where grouped.Key == mobileNumber
                       select new { total = grouped.Sum(i => i.PhoneSendCount) }).FirstOrDefault();
            if (sum == null)
            {
                return 0;
            }
            return sum.total;
        }

        public bool IsMobileNumberUsed(string mobileNumber, int projectid)
        {
            if (_db.Where(essv => essv.PhoneNumber == mobileNumber
                 && essv.ProjectId == projectid
                 && essv.StatusId == 1).Count() > 0)
            {
                return true;
            }
            return false;
        }



       

        public void resetPhoneSecurityStepValidationByValid(int projectid, string providerid)
        {
            foreach(PhoneSecurityStepValidation essvtemp 
                in _db.Where(essv => essv.ProjectId == projectid && essv.ProviderId == providerid && essv.StatusId != 1))
            {
                _db.Remove(essvtemp);
            }
        }



        public void UpdatePhoneSecurityStepValidation(PhoneSecurityStepValidation PhoneSecurityStepValidation)
        {
            var essvtemp =
                _db.FirstOrDefault(essv => essv.PhoneSecurityStepValidationId == PhoneSecurityStepValidation.PhoneSecurityStepValidationId);

            essvtemp.PhoneNumber = PhoneSecurityStepValidation.PhoneNumber;
            essvtemp.CodeEntered = PhoneSecurityStepValidation.CodeEntered;
            essvtemp.Code = PhoneSecurityStepValidation.Code;
            essvtemp.StatusId = PhoneSecurityStepValidation.StatusId;
            essvtemp.PhoneSecurityStepValidationId = PhoneSecurityStepValidation.PhoneSecurityStepValidationId;
            essvtemp.ProjectId = PhoneSecurityStepValidation.ProjectId;
            essvtemp.ProviderId = PhoneSecurityStepValidation.ProviderId;
            essvtemp.Created = PhoneSecurityStepValidation.Created;

        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       