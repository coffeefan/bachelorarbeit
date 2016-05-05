using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PassportSecurityStep.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<PassportSecurityStepValidation> PassportSecurityStepValidations { get; set; }
        public DbSet<PassportSecurityStepConfig> PassportSecurityStepConfigs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}