using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authenticationservice.Models.Helper
{
    public class RegistrierungDTO
    {
        public string Code { get; set; } 
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EMail { get; set; } 
        public string ConfigurationUrl { get; set; }

    }
}