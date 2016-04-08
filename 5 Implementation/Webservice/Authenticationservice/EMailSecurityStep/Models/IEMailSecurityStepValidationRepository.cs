using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMailSecurityStep.Models
{
    public interface IEMailSecurityStepValidationRepository
    {
        void CreateNewEMailSecurityStepValidation(EMailSecurityStepValidation eMailSecurityStepValidation);
        EMailSecurityStepValidation GetEMailSecurityStepValidationByID(int id);
        IEnumerable<EMailSecurityStepValidation> GetAllEMailSecurityStepValidations();
        int SaveChanges();

    }
}
