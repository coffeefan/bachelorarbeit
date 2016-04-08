using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMailSecurityStep.Models
{
    public class EMailSecurityStepValidation
    {
        public int EMailSecurityStepValidationId { get; set; }
        public int ProjectId { get; set; }
        public string ProviderId { get; set; }
        public int StatusId { get; set; }
        public DateTime Created { get; set; }
        public string EMail { get; set; }
        public string Code { get; set; }
        public string CodeEntered { get; set; }


    }
}