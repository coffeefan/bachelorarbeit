using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EMailSecurityStep.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<EMailSecurityStepValidation> EMailSecurityStepValidations { get; set; }
        public DbSet<EMailSecurityStepConfig> EMailSecurityStepConfigs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}