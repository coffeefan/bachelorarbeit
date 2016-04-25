using System.Collections.Generic;

namespace SecurityStepContract
{
    public interface ISecurityStepInfo
    {
        object getConfigParameters(int projectId);
        string saveConfigParameters(IDictionary<string, string> config,int projectId);
        bool checkIsValidated(int projectid, string providerid);
        SecurityStepCompareInfo getSecurityStepCompareInfo();
    }

    public class SecurityStepCompareInfo
    {
        public float MultipleParticipation { get; set; }
        public float Automation { get; set; }
        public float Costs { get; set; }
        public float ClientEffort { get; set;}
        public float Awareness { get; set; }
    }

}
