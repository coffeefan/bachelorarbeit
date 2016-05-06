using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassportSecurityStep.Models
{
    public enum PassportSecurityStepValidation_Status
    {
        NOTOPEN = -99,
        OPEN = -1,
        INVALID = 0,
        VALID = 1
    }
    public class PassportSecurityStepValidation 
    {
        public int PassportSecurityStepValidationId { get; set; }
        public int ProjectId { get; set; }
        public string ProviderId { get; set; }
        public int StatusId { get; set; }
        public DateTime Created { get; set; }
        public string PassportNumber { get; set; }
        public int PassportSendCount { get; set; }
       
        public string CodeEntered { get; set; }

        public bool IsDeleted { get; set; }

    }

    public class PassportSecurityStepValidation_Passport
    {
        [Display(Name = "Roter Bereich")]
        [Required(ErrorMessage = "Roter Bereich ist Pflichtfeld")]
        [MaxLength(8, ErrorMessage = "Der Roter Bereich ist 8 Zeichen lang")]
        [MinLength(8, ErrorMessage = "Der Roter Bereich ist 8 Zeichen lang")]
        public string PassportNumber { get; set; }

        [Display(Name = "Dunkel Roter Bereich ")]
        [Required(ErrorMessage = "Dunkel Roter Bereich ist Pflichtfeld")]
        [MaxLength(1, ErrorMessage = "Der Dunkel Roter Bereich ist 1 Zeichen lang")]
        [MinLength(1, ErrorMessage = "Der Dunkel Roter Bereich ist 1 Zeichen lang")]
        public string PassportAddOn { get; set; }

        [Display(Name = "Blauer Bereich")]
        [Required(ErrorMessage = "Blauer Bereich  ist Pflichtfeld")]
        [MaxLength(7, ErrorMessage = "Der Blauer Bereich  ist 7 Zeichen lang")]
        [MinLength(7, ErrorMessage = "Der Blauer Bereichist 7 Zeichen lang")]
        public string Birthday { get; set; }

        [Display(Name = "Grüner Bereich")]
        [Required(ErrorMessage = "Grüner Bereich  ist Pflichtfeld")]
        [MaxLength(7, ErrorMessage = "Der Grüner Bereich  ist 7 Zeichen lang")]
        [MinLength(7, ErrorMessage = "Der Grüner Zusatz ist 7 Zeichen lang")]
        public string ExpiryDate { get; set; }

        [Display(Name = "Gelber Bereich")]
        [Required(ErrorMessage = "Gelber Bereich  ist Pflichtfeld")]
        [MaxLength(1, ErrorMessage = "Der Gelber Bereich  ist 1 Zeichen lang")]
        [MinLength(1, ErrorMessage = "Der Gelber Zusatz ist 1 Zeichen lang")]
        public string EndCheck { get; set; }

    }

   
}