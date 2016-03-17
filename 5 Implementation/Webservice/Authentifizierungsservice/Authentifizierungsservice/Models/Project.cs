using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Authentifizierungsservice.Models
{

    public class Project
    {
       

        public int ProjectID { get; set; }
        public String ProjectName { get; set; }
        [ForeignKey("OwnerId")]
        public ApplicationUser Owner { get; set; }
        public String OwnerId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AcceptionLevel.InteractiveTypeEnum InteractiveType { get; set; }

        public virtual ICollection<ProjectSecurityStep> SecurityStep{get; set;}
    }
}       