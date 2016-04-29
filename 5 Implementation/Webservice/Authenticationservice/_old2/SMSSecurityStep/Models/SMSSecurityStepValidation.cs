using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMSSecurityStep.Models
{
    public enum SMSSecurityStepValidation_Status
    {
        NOTOPEN = -99,
        OPEN = -1,
        INVALID = 0,
        VALID = 1
    }
    public class SMSSecurityStepValidation 
    {
        public int SMSSecurityStepValidationId { get; set; }
        public int ProjectId { get; set; }
        public string ProviderId { get; set; }
        public int StatusId { get; set; }
        public DateTime Created { get; set; }
        public string MobileNumber { get; set; }
        public int SMSSendCount { get; set; }
        public string Code { get; set; }
        public string CodeEntered { get; set; }

        public bool IsDeleted { get; set; }

    }

    public class SMSSecurityStepValidation_MobileNumber
    {
        [Display(Name = "Mobilenummer")]
        [Required(ErrorMessage = "Die Mobilenummer ist das Pflichtfeld")]
        [RegularExpression(@"(\+417)(\d{1})(\d{3})(\d{2})(\d{2})", ErrorMessage = "Keine gültige Nummer, Beispiel: +417914178772")]
        public string MobileNumber { get; set; }


    }

    public class SMSSecurityStepValidation_Code
    {
        [Display(Name = "Validierungscode")]
        [Required(ErrorMessage = "Der Code ist ein Pflichtfeld")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Der Code muss eine Nummer sein")]
        public string Code { get; set; }

        public string MobileNumber { get; set; }

    }
}