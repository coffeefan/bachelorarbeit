using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportSecurityStep.Models
{
    public interface IPassportSecurityStepConfigRepository
    {
        PassportSecurityStepConfig GetPassportSecurityStepConfigByProjectId(int projectid);
        void SavePassportSecurityConfigByProjectId(PassportSecurityStepConfig PassportSecurityStepConfig);

    }
}
