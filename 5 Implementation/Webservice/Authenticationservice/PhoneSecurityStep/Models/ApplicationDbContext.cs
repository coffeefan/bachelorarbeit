using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneSecurityStep.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<PhoneSecurityStepValidation> PhoneSecurityStepValidations { get; set; }
        public DbSet<PhoneSecurityStepConfig> PhoneSecurityStepConfigs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}