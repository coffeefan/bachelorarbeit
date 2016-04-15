using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SMSSecurityStep.Models
{
    public class EF_SMSSecurityStepValidationRepository : SMSSecurityStep.Models.ISMSSecurityStepValidationRepository
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public void CreateNewSMSSecurityStepValidation(SMSSecurityStepValidation SMSSecurityStepValidation)
        {
            _db.SMSSecurityStepValidations.Add(SMSSecurityStepValidation);
            _db.SaveChanges();
            
        }

        public IEnumerable<SMSSecurityStepValidation> GetAllSMSSecurityStepValidations()
        {
            return _db.SMSSecurityStepValidations.ToList();
        }

        public SMSSecurityStepValidation GetSMSSecurityStepValidationByID(int id)
        {
            return _db.SMSSecurityStepValidations.FirstOrDefault(essv => essv.SMSSecurityStepValidationId == id);
        }

        public SMSSecurityStepValidation GetSMSSecurityStepValidationByValid(int projectid, string providerid)
        {
            return _db.SMSSecurityStepValidations.FirstOrDefault(essv => essv.ProjectId== projectid && essv.ProviderId== providerid);
        }



        public void UpdateSMSSecurityStepValidation(SMSSecurityStepValidation SMSSecurityStepValidation)
        {
            SMSSecurityStepValidation essvtemp=
                _db.SMSSecurityStepValidations.FirstOrDefault(essv => essv.SMSSecurityStepValidationId == SMSSecurityStepValidation.SMSSecurityStepValidationId);

            essvtemp = SMSSecurityStepValidation;
            _db.Entry(essvtemp).State= EntityState.Modified;
            _db.SaveChanges();

        }

        public void resetSMSSecurityStepValidationByValid(int projectid, string providerid)
        {
            _db.SMSSecurityStepValidations.RemoveRange(
            _db.SMSSecurityStepValidations.Where(essv => essv.ProjectId == projectid && essv.ProviderId == providerid && essv.StatusId != 1));
            _db.SaveChanges();
        }
    }
}