using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMailSecurityStep.Models;

namespace EMailSecurityStep.Tests.Models
{
    class InMemory_EMailSecurityStepValidationRepository : IEMailSecurityStepValidationRepository
    {
        private List<EMailSecurityStepValidation> _db = new List<EMailSecurityStepValidation>();

        public Exception ExceptionToThrow { get; set; }

        public void CreateNewEMailSecurityStepValidation(EMailSecurityStepValidation eMailSecurityStepValidation)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(eMailSecurityStepValidation);
        }

        public IEnumerable<EMailSecurityStepValidation> GetAllEMailSecurityStepValidations()
        {
            return _db.ToList();
        }

        public EMailSecurityStepValidation GetEMailSecurityStepValidationByID(int id)
        {
            return _db.FirstOrDefault(essv => essv.EMailSecurityStepValidationId == id);
        }

        public EMailSecurityStepValidation GetEMailSecurityStepValidationByValid(int projectid, string providerid)
        {
            return _db.FirstOrDefault(essv => essv.ProjectId == projectid && essv.ProviderId == providerid);
        }

        public void resetEMailSecurityStepValidationByValid(int projectid, string providerid)
        {
            foreach(EMailSecurityStepValidation essvtemp 
                in _db.Where(essv => essv.ProjectId == projectid && essv.ProviderId == providerid && essv.StatusId != 1))
            {
                _db.Remove(essvtemp);
            }
        }



        public void UpdateEMailSecurityStepValidation(EMailSecurityStepValidation eMailSecurityStepValidation)
        {
            var essvtemp =
                _db.FirstOrDefault(essv => essv.EMailSecurityStepValidationId == eMailSecurityStepValidation.EMailSecurityStepValidationId);

            essvtemp.EMail = eMailSecurityStepValidation.Code;
            essvtemp.CodeEntered = eMailSecurityStepValidation.CodeEntered;
            essvtemp.Code = eMailSecurityStepValidation.Code;
            essvtemp.StatusId = eMailSecurityStepValidation.StatusId;
            essvtemp.EMailSecurityStepValidationId = eMailSecurityStepValidation.EMailSecurityStepValidationId;
            essvtemp.ProjectId = eMailSecurityStepValidation.ProjectId;
            essvtemp.ProviderId = eMailSecurityStepValidation.ProviderId;
            essvtemp.Created = eMailSecurityStepValidation.Created;

        }
    }
}
