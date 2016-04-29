using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSSecurityStep.Models;

namespace SMSSecurityStep.Tests.Models
{
    class InMemory_SMSSecurityStepValidationRepository : ISMSSecurityStepValidationRepository
    {
        private List<SMSSecurityStepValidation> _db = new List<SMSSecurityStepValidation>();

        public Exception ExceptionToThrow { get; set; }

        public void CreateNewSMSSecurityStepValidation(SMSSecurityStepValidation SMSSecurityStepValidation)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(SMSSecurityStepValidation);
        }

        public IEnumerable<SMSSecurityStepValidation> GetAllSMSSecurityStepValidations()
        {
            return _db.ToList();
        }

        public SMSSecurityStepValidation GetSMSSecurityStepValidationByID(int id)
        {
            return _db.FirstOrDefault(essv => essv.SMSSecurityStepValidationId == id);
        }

        public SMSSecurityStepValidation GetSMSSecurityStepValidationForValid(int projectid, string providerid)
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

            var sum = (from smsvalidation in _db
                       where smsvalidation.StatusId != 1
                       group smsvalidation by smsvalidation.MobileNumber into grouped
                       where grouped.Key == mobileNumber
                       select new { total = grouped.Sum(i => i.SMSSendCount) }).FirstOrDefault();
            if (sum == null)
            {
                return 0;
            }
            return sum.total;
        }

        public bool IsMobileNumberUsed(string mobileNumber, int projectid)
        {
            if (_db.Where(essv => essv.MobileNumber == mobileNumber
                 && essv.ProjectId == projectid
                 && essv.StatusId == 1).Count() > 0)
            {
                return true;
            }
            return false;
        }



       

        public void resetSMSSecurityStepValidationByValid(int projectid, string providerid)
        {
            foreach(SMSSecurityStepValidation essvtemp 
                in _db.Where(essv => essv.ProjectId == projectid && essv.ProviderId == providerid && essv.StatusId != 1))
            {
                _db.Remove(essvtemp);
            }
        }



        public void UpdateSMSSecurityStepValidation(SMSSecurityStepValidation SMSSecurityStepValidation)
        {
            var essvtemp =
                _db.FirstOrDefault(essv => essv.SMSSecurityStepValidationId == SMSSecurityStepValidation.SMSSecurityStepValidationId);

            essvtemp.MobileNumber = SMSSecurityStepValidation.MobileNumber;
            essvtemp.CodeEntered = SMSSecurityStepValidation.CodeEntered;
            essvtemp.Code = SMSSecurityStepValidation.Code;
            essvtemp.StatusId = SMSSecurityStepValidation.StatusId;
            essvtemp.SMSSecurityStepValidationId = SMSSecurityStepValidation.SMSSecurityStepValidationId;
            essvtemp.ProjectId = SMSSecurityStepValidation.ProjectId;
            essvtemp.ProviderId = SMSSecurityStepValidation.ProviderId;
            essvtemp.Created = SMSSecurityStepValidation.Created;

        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       