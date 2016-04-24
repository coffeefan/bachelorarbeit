using Authenticationservice.Models;
using Authenticationservice.Models.Helper;
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
        [Route("api/SecurityStepCompareInfo/")]
        public IHttpActionResult GetSecurityStepProject(string securitystepname)
        {
            ISecurityStepInfo securityStepInfo = new SecurityStepInfoContainer().getSecurityStepInfo(securitystepname);
            SecurityStepCompareInfo sSecurityStepCompareInfo = securityStepInfo.getSecurityStepCompareInfo();
            return Ok(
            new {
                labels =new string[] { "Verhinderung Mehrfachteilnahme", "Automatsierung", "Kosten", "Aufwand Benutzer", "Verbreitung" },
                data = new int[][] {new int[] {
                    MasterFunctions.NoteTo100(sSecurityStepCompareInfo.MultipleParticipation),
                    MasterFunctions.NoteTo100(sSecurityStepCompareInfo.Automation),
                    MasterFunctions.NoteTo100(sSecurityStepCompareInfo.Costs),
                    MasterFunctions.NoteTo100(sSecurityStepCompareInfo.ClientEffort),
                    MasterFunctions.NoteTo100(sSecurityStepCompareInfo.Awareness),
                } },
            }
            );
        }

        [Route("api/SecurityStepAvailable/")]
        public List<string> GetSecuritySteps()
        {
            return new SecurityStepInfoContainer().getSecurityStepInfos();
        }

        [Route("api/SecurityStepProjectList/")]
        public IHttpActionResult GetSecurityStepProjectList(int projectId)
        {
            return Ok(new EF_ProjectSecurityStepRepository().GetProjectSecurityStepList(projectId));
        }

        [Route("api/SecurityStepProjectList/")]
        public IHttpActionResult PutSecurityStepProjectList(List<ProjectSecurityStep> list, int projectId)
        {
            new EF_ProjectSecurityStepRepository().SaveProjectSecurityStepList(list, projectId);
            return Ok();
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
