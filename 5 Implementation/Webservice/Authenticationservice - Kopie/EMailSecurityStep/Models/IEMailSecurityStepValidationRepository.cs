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
        void UpdateEMailSecurityStepValidation(EMailSecurityStepValidation eMailSecurityStepValidation);
        void resetEMailSecurityStepValidationByValid(int projectid, string providerid);

        EMailSecurityStepValidation GetEMailSecurityStepValidationByValid(int projectid, string providerid);

        EMailSecurityStepValidation GetEMailSecurityStepValidationByID(int id);
        IEnumerable<EMailSecurityStepValidation> GetAllEMailSecurityStepValidations();

    }
}
