using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SecurityStepContract
{
    public interface ISecurityStepInfo
    {

        object getConfigParameters(int projectId);
        string saveConfigParameters(IDictionary<string, string> config,int projectId);
        bool checkIsValidated(int projectid, string providerid);
    }
}
