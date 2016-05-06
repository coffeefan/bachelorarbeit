using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticationservice.Models
{
    public interface IProjectRepository
    {
        bool hasCurrentUserAcessProject(int projectId, string username);

        object GetAuthenticationStatusOverview(int projectId);
        object GetValidationTimeOverview(int projectId);
        object LastMonthsValidationsOverview(int projectId);


    }
}
