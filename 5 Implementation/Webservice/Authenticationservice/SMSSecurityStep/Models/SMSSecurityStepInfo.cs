using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Composition;

namespace SMSSecurityStep.Models
{
    [Export(typeof(SecurityStepContract.ISecurityStepInfo))]
    public class SMSSecurityStepInfo : SecurityStepContract.ISecurityStepInfo
    {
        public bool checkIsValidated(int projectid, string providerid)
        {
            throw new NotImplementedException();
        }

        public object getConfigParameters(int projectId)
        {
            SMSSecurityStepConfig config=
                new EF_SMSSecurityStepConfigRepository().GetSMSSecurityStepConfigByProjectId(projectId);

            if (config == null)
            {
                config = new SMSSecurityStepConfig();
            }
            return config;

        }

        public string saveConfigParameters(object config)
        {
            SMSSecurityStepConfig SMSSecurityStepConfig; 
            try
            {
                SMSSecurityStepConfig = (SMSSecurityStepConfig)config;
            }
            catch(Exception ex)
            {
                throw new HttpException(512, "False Parameters");
            }

            var context = new ValidationContext(SMSSecurityStepConfig, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(SMSSecurityStepConfig, context, results);
            if (!isValid)
                throw new HttpException(510, "Parameters are not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage).ToArray()));

            new EF_SMSSecurityStepConfigRepository().SaveEMailSecurityConfigByProjectId(SMSSecurityStepConfig);
            return "";

        }

        
    }
}