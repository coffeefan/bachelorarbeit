using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMailSecurityStep.Models
{
    public enum EMailSecurityStepValidation_Status
    {
        NOTOPEN = -99,
        OPEN = -1,
        INVALID = 0,
        VALID = 1
    }
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

    public class EMailSecurityStepValidation_Mail
    {
        [Display(Name = "E-Mail Adresse")]
        [Required(ErrorMessage = "Die E-Mail Adresse ist ein Pflichtfeld")]
        [EmailAddress(ErrorMessage = "Inavlide E-Mail")]
        public string EMail { get; set; }


    }

    public class EMailSecurityStepValidation_Code
    {
        [Display(Name = "Validierungscode")]
        [Required(ErrorMessage = "Der Code ist ein Pflichtfeld")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Der Code muss eine Nummer sein")]
        public string Code { get; set; }

        public string EMail { get; set; }

    }
}