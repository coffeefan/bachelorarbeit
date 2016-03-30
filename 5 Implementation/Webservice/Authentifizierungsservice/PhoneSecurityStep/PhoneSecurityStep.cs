using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneSecurityStep
{
    public class PhoneSecurityStep
    {
        public int PhoneSecurityStepId { get; set; }
        public int ProjectId { get; set; }
        public string ProviderId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string IPAdresse { get; set; }
        public bool IsUnique { get; set; }
        public bool IsValidated { get; set; }
    }
}