using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Authentifizierungsservice.Models
{
    public class AcceptionLevel
    {
        public enum InteractiveTypeEnum
        {
            poll = 10,
            win = 20
        }
        public int AcceptionLevelId { get; set; }

        [ForeignKey("SecurityStepId")]
        public SecurityStep SecurityStep { get; set; }
        public int SecurityStepId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public InteractiveTypeEnum InteractiveType { get; set; }

        public int Level { get; set; }
        public String Description { get; set; }

    }
}