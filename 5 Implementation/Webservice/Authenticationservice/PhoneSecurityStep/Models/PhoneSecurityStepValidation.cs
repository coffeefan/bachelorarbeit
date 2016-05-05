using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneSecurityStep.Models
{
    public enum PhoneSecurityStepValidation_Status
    {
        NOTOPEN = -99,
        OPEN = -1,
        INVALID = 0,
        VALID = 1
    }
    public class PhoneSecurityStepValidation 
    {
        public int PhoneSecurityStepValidationId { get; set; }
        public int ProjectId { get; set; }
        public string ProviderId { get; set; }
        public int StatusId { get; set; }
        public DateTime Created { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneSendCount { get; set; }
        public string Code { get; set; }
        public string CodeEntered { get; set; }

        public bool IsDeleted { get; set; }

    }

    public class PhoneSecurityStepValidation_MobileNumber
    {
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Die Telefonnumer ist das Pflichtfeld")]
        [RegularExpression(@"(\+417)(\d{1})(\d{3})(\d{2})(\d{2})", ErrorMessage = "Keine gültige Telefonnummer, Beispiel: +415214178772")]
        public string PhoneNumber { get; set; }


    }

    public class PhoneSecurityStepValidation_Code
    {
        [Display(Name = "Validierungscode")]
        [Required(ErrorMessage = "Der Code ist ein Pflichtfeld")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Der Code muss eine Nummer sein")]
        public string Code { get; set; }

        public string PhoneNumber { get; set; }

    }
}