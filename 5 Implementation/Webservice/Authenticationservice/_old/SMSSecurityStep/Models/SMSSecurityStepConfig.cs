using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMSSecurityStep.Models
{
    public class SMSSecurityStepConfig
    {
        public int SMSSecurityStepConfigId { get; set; }
        public int ProjectId { get; set; }

        [MaxLength(8)]
        public string SenderName { get; set; }
    }
}