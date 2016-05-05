using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneSecurityStep.Models
{
    public interface IPhoneSecurityStepValidationRepository
    {
        void CreateNewPhoneSecurityStepValidation(PhoneSecurityStepValidation PhoneSecurityStepValidation);
        void UpdatePhoneSecurityStepValidation(PhoneSecurityStepValidation PhoneSecurityStepValidation);
        void resetPhoneSecurityStepValidationByValid(int projectid, string providerid);
        bool IsMobileNumberUsed(string mobileNumber, int projectid);
        bool IsMaxSend(string mobileNumbe);

        PhoneSecurityStepValidation GetPhoneSecurityStepValidationForValid(int projectid, string providerid);

        PhoneSecurityStepValidation GetPhoneSecurityStepValidationByID(int id);
        IEnumerable<PhoneSecurityStepValidation> GetAllPhoneSecurityStepValidations();

    }
}
