using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authenticationservice.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Bezeichnung { get; set; }
        public string Validationcode { get; set; }        
        public string ReturnUrl { get; set; }
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}