using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMailSecurityStep.Models
{
    public interface IEMailSecurityStepConfigRepository
    {
        EMailSecurityStepConfig GetEMailSecurityStepConfigByProjectId(int projectid);
        void SaveEMailSecurityConfigByProjectId(EMailSecurityStepConfig eMailSecurityStepConfig);

    }
}
