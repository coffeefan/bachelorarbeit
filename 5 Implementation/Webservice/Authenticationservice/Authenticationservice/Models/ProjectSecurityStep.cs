using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authenticationservice.Models
{
    
    public class ProjectSecurityStep
    {
        public int ProjectSecurityStepId {get; set;}
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public String SecurityStep { get; set; }
        public int Position { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}