using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneSecurityStep.Models
{
    public class PhoneSecurityStepConfig
    {
        public int PhoneSecurityStepConfigId { get; set; }
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Salutation ist ein Pflichtfeld")]
        [MaxLength(30, ErrorMessage = "Salutation darf nicht länger als 30 Zeichen sein")]
        public string Salutation { get; set; }


    }
}