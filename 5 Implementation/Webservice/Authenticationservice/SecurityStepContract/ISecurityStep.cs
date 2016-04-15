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
        string saveConfigParameters(object config);
        bool checkIsValidated(int projectid, string providerid);
    }
}
