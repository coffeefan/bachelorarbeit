using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Authentifizierungsservice.Controllers
{
    public class ValuesController : ApiController
    {
        Dictionary<string, ISecurityStep> _SecuritySteps;


        // GET api/values
        public IEnumerable<string> Get()
        {
            List<string> back = new List<string>();

            //String link = System.Web.Hosting.HostingEnvironment.MapPath(@"~/");
            String link = @"C:\Project\Bachelorarbeit\5 Implementation\Webservice\Authentifizierungsservice\Authentifizierungsservice\bin\Plugins";
            GenericMEFSecurityStepLoader<ISecurityStep> loader = new GenericMEFSecurityStepLoader<ISecurityStep>(link);
            _SecuritySteps = new Dictionary<string, ISecurityStep>();
            IEnumerable<ISecurityStep> securitySteps = loader.SecuritySteps;
            foreach (var item in securitySteps)
            {


                back.Add(item.checkIsValidated(1,"2").ToString());
            }


            

            return back;

        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
