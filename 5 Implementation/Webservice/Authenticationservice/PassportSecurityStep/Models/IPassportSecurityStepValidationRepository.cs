using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportSecurityStep.Models
{
    public interface IPassportSecurityStepValidationRepository
    {
        void CreateNewPassportSecurityStepValidation(PassportSecurityStepValidation PassportSecurityStepValidation);
        void UpdatePassportSecurityStepValidation(PassportSecurityStepValidation PassportSecurityStepValidation);
        void resetPassportSecurityStepValidationByValid(int projectid, string providerid);
        bool IsPassportUsed(string passportNumber, int projectid);
        bool IsMaxSend(string mobileNumbe);

        PassportSecurityStepValidation GetPassportSecurityStepValidationForValid(int projectid, string providerid);

        PassportSecurityStepValidation GetPassportSecurityStepValidationByID(int id);
        IEnumerable<PassportSecurityStepValidation> GetAllPassportSecurityStepValidations();

    }
}
