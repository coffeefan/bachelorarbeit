using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentifizierungsservice.Models
{
    public class SecurityStep
    {
        public int SecurityStepId { get; set; }
        public string SecurityStepName { get; set; }

        public int PollAcceptionLevel { get; set; }
        public int WinAcceptionLevel { get; set; }

        public string Description { get; set; }

        public bool IsVerification { get; set; }
        public bool IsUniqueCheck { get; set; }
    
    }
}