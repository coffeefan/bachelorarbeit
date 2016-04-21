using Newtonsoft.Json.Linq;
using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;


namespace Authenticationservice.Controllers
{
    public class SecurityStepsController : ApiController
    {
        // GET: api/SecuritySteps
        public List<string> GetSecuritySteps()
        {
            return new SecurityStepInfoContainer().getSecurityStepInfos();
        }


        [Route("api/SecurityStepProject/")]
        public IHttpActionResult GetSecurityStepProject(string securitystepname,int projectId)
        {
            ISecurityStepInfo securityStepInfo=  new SecurityStepInfoContainer().getSecurityStepInfo(securitystepname);
            return Ok(securityStepInfo.getConfigParameters(projectId));    
        }

        [Route("api/SecurityStepProject/")]
        public IHttpActionResult PutSecurityStepProject([FromBody]IDictionary<string, string> config, string securitystepname,int projectid)
        {
            ISecurityStepInfo securityStepInfo = new SecurityStepInfoContainer().getSecurityStepInfo(securitystepname);

           
            securityStepInfo.saveConfigParameters(config,projectid);
            return Ok();
        }
    }
}
