using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Authenticationservice.Controllers
{
    public class SecurityStepsController : ApiController
    {
        // GET: api/SecuritySteps
        public List<string> GetSecuritySteps()
        {
            return new SecurityStepInfoContainer().getSecurityStepInfos();
        }
    }
}
