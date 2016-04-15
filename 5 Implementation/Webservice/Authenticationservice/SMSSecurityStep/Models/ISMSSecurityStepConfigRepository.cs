using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSecurityStep.Models
{
    public interface ISMSSecurityStepConfigRepository
    {
        SMSSecurityStepConfig GetSMSSecurityStepConfigByProjectId(int projectid);
        void SaveEMailSecurityConfigByProjectId(SMSSecurityStepConfig SMSSecurityStepConfig);

    }
}
