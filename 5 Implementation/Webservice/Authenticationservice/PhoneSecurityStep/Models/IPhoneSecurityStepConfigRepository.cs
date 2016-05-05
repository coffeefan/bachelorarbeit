using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneSecurityStep.Models
{
    public interface IPhoneSecurityStepConfigRepository
    {
        PhoneSecurityStepConfig GetPhoneSecurityStepConfigByProjectId(int projectid);
        void SavePhoneSecurityConfigByProjectId(PhoneSecurityStepConfig PhoneSecurityStepConfig);

    }
}
