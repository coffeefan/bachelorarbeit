using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authenticationservice.Models
{
    public enum AuthenticationStatus
    {
        NOTOPEN = -99,
        OPEN = -1,
        INVALID = 0,
        VALID = 1
    }
    public class ProjectAuthentication
    {
        public int ProjectAuthenticationId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string ProviderId { get; set; }
        public string IPAdresse { get; set; }
        public AuthenticationStatus AuthenticationStatus { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Finished { get; set; }
    }
}