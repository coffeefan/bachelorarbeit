using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SecurityStepContract
{
    public interface ISecurityStep
    {
        IHttpActionResult GetShowSecurityStepAuthentication(int projectid,string providerid );
        IHttpActionResult PostSecurityStepAuthentication(int projectid, string providerid, Object result);

        bool checkIsUnique(int projectid, string providerid);
        bool checkIsValidated(int projectid, string providerid);
    }
}
