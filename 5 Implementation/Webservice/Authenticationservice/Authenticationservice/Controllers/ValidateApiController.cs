using Authenticationservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Authenticationservice.Controllers
{
    public class ValidateApiController : ApiController
    {
        private IProjectAuthenticationRepository par;
        public ValidateApiController() : this(new EF_ProjectAuthenticationRepository()) { }
        public ValidateApiController(IProjectAuthenticationRepository temppar)
        {
            par = temppar;
        }
        [Route("api/Validate/")]
        public AuthenticationStatus getValidate(int projectId, string providerId)
        {
            return par.OpenProjectAuthentication(projectId, providerId);
        }
    }
}
