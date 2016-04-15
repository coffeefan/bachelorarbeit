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

        public SMSSecurityStepValidation GetSMSSecurityStepValidationByValid(int projectid, string providerid)
        {
            return _db.FirstOrDefault(essv => essv.ProjectId == projectid && essv.ProviderId == providerid);
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

            essvtemp.EMail = SMSSecurityStepValidation.Code;
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
