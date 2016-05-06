using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticationservice.Models
{
    public interface IProjectAuthenticationRepository
    {
        AuthenticationStatus  OpenProjectAuthentication(int ProjectId, string ProviderId);

        void  FinishProjectAuthentication(int ProjectId, string ProviderId);

        string getDeveloperEMailOfProject(int projectId);
    }
}
