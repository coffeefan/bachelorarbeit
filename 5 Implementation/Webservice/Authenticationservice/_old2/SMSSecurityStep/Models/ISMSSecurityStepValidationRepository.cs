using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSecurityStep.Models
{
    public interface ISMSSecurityStepValidationRepository
    {
        void CreateNewSMSSecurityStepValidation(SMSSecurityStepValidation SMSSecurityStepValidation);
        void UpdateSMSSecurityStepValidation(SMSSecurityStepValidation SMSSecurityStepValidation);
        void resetSMSSecurityStepValidationByValid(int projectid, string providerid);
        bool IsMobileNumberUsed(string mobileNumber, int projectid);
        bool IsMaxSend(string mobileNumbe);

        SMSSecurityStepValidation GetSMSSecurityStepValidationForValid(int projectid, string providerid);

        SMSSecurityStepValidation GetSMSSecurityStepValidationByID(int id);
        IEnumerable<SMSSecurityStepValidation> GetAllSMSSecurityStepValidations();

    }
}
