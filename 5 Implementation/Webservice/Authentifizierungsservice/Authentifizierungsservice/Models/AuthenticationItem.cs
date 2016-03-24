using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentifizierungsservice.Models
{
    public class AuthenticationItem
    {
        public int AuthenticationItemId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public bool IsAuthenticated { get; set; }
        public string IP { get; set; }
        public string RemotePort { get; set; }
        public string UserAgent { get; set; }
        public string Accept { get; set; }
        public string AcceptCharset { get; set; }
        public string AcceptEncoding { get; set; }
        public string AcceptLanguage { get; set; }

    }
}