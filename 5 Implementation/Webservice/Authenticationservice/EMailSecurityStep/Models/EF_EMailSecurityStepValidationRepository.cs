using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMailSecurityStep.Models
{
    public class EF_EMailSecurityStepValidationRepository : EMailSecurityStep.Models.IEMailSecurityStepValidationRepository
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public void CreateNewEMailSecurityStepValidation(EMailSecurityStepValidation eMailSecurityStepValidation)
        {
            _db.EMailSecurityStepValidations.Add(eMailSecurityStepValidation);
            _db.SaveChanges();
            
        }

        public IEnumerable<EMailSecurityStepValidation> GetAllEMailSecurityStepValidations()
        {
            return _db.EMailSecurityStepValidations.ToList();
        }

        public EMailSecurityStepValidation GetEMailSecurityStepValidationByID(int id)
        {
            return _db.EMailSecurityStepValidations.FirstOrDefault(essv => essv.EMailSecurityStepValidationId == id);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

       

    }
}