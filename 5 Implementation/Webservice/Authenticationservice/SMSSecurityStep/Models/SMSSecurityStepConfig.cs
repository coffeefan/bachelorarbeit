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

        [Required(ErrorMessage = "SendName ist ein Pflichtfeld")]
        [MaxLength(8, ErrorMessage = "SendName darf nicht länger als 8 Zeichen sein")]
        public string SendName { get; set; }


    }
}