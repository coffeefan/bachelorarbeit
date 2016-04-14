using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Authenticationservice.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string ValidationCode { get; set; }        
        public string ReturnUrl { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
        public ApplicationUser User { get; set; }
        public string ApplicationUserId { get; set; }
    }
}