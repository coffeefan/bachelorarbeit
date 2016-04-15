using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Composition;

namespace EMailSecurityStep.Models
{
    [Export(typeof(SecurityStepContract.ISecurityStepInfo))]
    public class EMailSecurityStepInfo : SecurityStepContract.ISecurityStepInfo
    {
        public bool checkIsValidated(int projectid, string providerid)
        {
            throw new NotImplementedException();
        }

        public object getConfigParameters(int projectId)
        {
            EMailSecurityStepConfig config=
                new EF_EMailSecurityStepConfigRepository().GetEMailSecurityStepConfigByProjectId(projectId);

            if (config == null)
            {
                config = new EMailSecurityStepConfig();
            }
            return config;

        }

        public string saveConfigParameters(object config)
        {
            EMailSecurityStepConfig eMailSecurityStepConfig; 
            try
            {
                eMailSecurityStepConfig = (EMailSecurityStepConfig)config;
            }
            catch(Exception ex)
            {
                throw new HttpException(512, "False Parameters");
            }

            var context = new ValidationContext(eMailSecurityStepConfig, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(eMailSecurityStepConfig, context, results);
            if (!isValid)
                throw new HttpException(510, "Parameters are not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage).ToArray()));

            new EF_EMailSecurityStepConfigRepository().SaveEMailSecurityConfigByProjectId(eMailSecurityStepConfig);
            return "";

        }

        
    }
}