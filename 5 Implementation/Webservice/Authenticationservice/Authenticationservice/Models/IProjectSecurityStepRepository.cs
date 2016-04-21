using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticationservice.Models
{
    public interface IProjectSecurityStepRepository
    {
        List<ProjectSecurityStep> GetProjectSecurityStepList(int projectId);
        void SaveProjectSecurityStepList(List<ProjectSecurityStep> projectSecurityStepList, int projectId);

    }
}
