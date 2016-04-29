using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool IsEMailUsed(string email,int projectid)
        {
            if(_db.EMailSecurityStepValidations.Where(essv => essv.EMail == email 
                && essv.ProjectId == projectid 
                && essv.StatusId== 1).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public EMailSecurityStepValidation GetEMailSecurityStepValidationByID(int id)
        {
            return _db.EMailSecurityStepValidations.FirstOrDefault(essv => essv.EMailSecurityStepValidationId == id);
        }

        public EMailSecurityStepValidation GetEMailSecurityStepValidationForValid(int projectid, string providerid)
        {
            return _db.EMailSecurityStepValidations.FirstOrDefault(essv => essv.ProjectId== projectid && essv.ProviderId== providerid);
        }



        public void UpdateEMailSecurityStepValidation(EMailSecurityStepValidation eMailSecurityStepValidation)
        {
            EMailSecurityStepValidation essvtemp=
                _db.EMailSecurityStepValidations.FirstOrDefault(essv => essv.EMailSecurityStepValidationId == eMailSecurityStepValidation.EMailSecurityStepValidationId);

            essvtemp = eMailSecurityStepValidation;
            _db.Entry(essvtemp).State= EntityState.Modified;
            _db.SaveChanges();

        }

        public void resetEMailSecurityStepValidationByValid(int projectid, string providerid)
        {
            _db.EMailSecurityStepValidations.RemoveRange(
            _db.EMailSecurityStepValidations.Where(essv => essv.ProjectId == projectid && essv.ProviderId == providerid && essv.StatusId != 1));
            _db.SaveChanges();
        }
    }
}