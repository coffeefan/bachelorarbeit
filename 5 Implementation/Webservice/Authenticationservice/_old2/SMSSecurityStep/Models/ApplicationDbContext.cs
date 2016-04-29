using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SMSSecurityStep.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<SMSSecurityStepValidation> SMSSecurityStepValidations { get; set; }
        public DbSet<SMSSecurityStepConfig> SMSSecurityStepConfigs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}