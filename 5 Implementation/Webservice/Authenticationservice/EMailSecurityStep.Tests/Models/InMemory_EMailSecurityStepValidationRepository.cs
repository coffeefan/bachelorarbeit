using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMailSecurityStep.Models;

namespace EMailSecurityStep.Tests.Models
{
    class InMemory_EMailSecurityStepValidationRepository : EMailSecurityStep.Models.IEMailSecurityStepValidationRepository
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
            return _db.FirstOrDefault(essv => essv.EMailSecurityStepId == id);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
