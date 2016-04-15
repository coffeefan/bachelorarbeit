using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMailSecurityStep.Models
{
    public class EMailSecurityStepConfig
    {
        public int EMailSecurityStepConfigId { get; set; }
        public int ProjectId { get; set; }
        public string FromName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ReplayMail { get; set; }
    }
}