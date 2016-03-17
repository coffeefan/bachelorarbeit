using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Authentifizierungsservice.Models
{
    public class ProjectSecurityStep
    {
        public int ProjectSecurityStepId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("SecurityStepId")]
        public SecurityStep SecurityStep { get; set; }
        public int SecurityStepId { get; set; }
    }
}