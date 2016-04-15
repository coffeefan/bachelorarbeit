using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authenticationservice.Models
{
    public enum SecurityStep
    {
        SMS = 10,
        EMail = 20
    }
    public class ProjectSecurityStep
    {
        public int ProjectSecurityStepId {get; set;}
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public SecurityStep SecurityStep { get; set; }
        public int Position { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}