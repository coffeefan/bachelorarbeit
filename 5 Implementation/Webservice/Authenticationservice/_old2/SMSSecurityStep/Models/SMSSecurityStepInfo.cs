using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Composition;
using System.Reflection;

namespace SMSSecurityStep.Models
{
    [Export(typeof(SecurityStepContract.ISecurityStepInfo))]
    public class SMSSecurityStepInfo : SecurityStepContract.ISecurityStepInfo
    {
        private ISMSSecurityStepConfigRepository SMSSecurityStepConfigRepository;
        private ISMSSecurityStepValidationRepository SMSSecurityStepValidationRepository;

        public SMSSecurityStepInfo() : this(new EF_SMSSecurityStepConfigRepository(), new EF_SMSSecurityStepValidationRepository()) { }
        public SMSSecurityStepInfo(ISMSSecurityStepConfigRepository SMSSecurityStepConfigRepository,
            ISMSSecurityStepValidationRepository SMSSecurityStepValidationRepository)
        {
            this.SMSSecurityStepConfigRepository = SMSSecurityStepConfigRepository;
            this.SMSSecurityStepValidationRepository = SMSSecurityStepValidationRepository;
        }
        public bool checkIsValidated(int projectid, string providerid)
        {
            SMSSecurityStepValidation SMSSecurityStepValidation =
                SMSSecurityStepValidationRepository.GetSMSSecurityStepValidationForValid(projectid, providerid);

            if (SMSSecurityStepValidation != null && SMSSecurityStepValidation.StatusId == 1)
            {
                return true;
            }
            return false;
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

        private T DictionaryToObject<T>(IDictionary<string, string> dict) where T : new()
        {
            var t = new T();
            PropertyInfo[] properties = t.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!dict.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                KeyValuePair<string, string> item = dict.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

                // Find which property type (int, string, double? etc) the CURRENT property is...
                Type tPropertyType = t.GetType().GetProperty(property.Name).PropertyType;

                // Fix nullables...
                Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

                // ...and change the type
                object newA = Convert.ChangeType(item.Value, newT);
                t.GetType().GetProperty(property.Name).SetValue(t, newA, null);
            }
            return t;
        }

        public string saveConfigParameters(IDictionary<string, string> config, int projectId)
        {
            SMSSecurityStepConfig SMSSecurityStepConfig; 
            try
            {
                
                SMSSecurityStepConfig = DictionaryToObject<SMSSecurityStepConfig>(config);
            }
            catch(Exception ex)
            {
                throw new HttpException(512, "False Parameters");
            }

            if(SMSSecurityStepConfig.ProjectId!= projectId)
            {
                throw new HttpException(511, "No ProjectAcess ");
            }

            var context = new ValidationContext(SMSSecurityStepConfig, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(SMSSecurityStepConfig, context, results);
            if (!isValid)
                throw new HttpException(510, "Parameters are not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage).ToArray()));

                SMSSecurityStepConfigRepository.SaveSMSSecurityConfigByProjectId(SMSSecurityStepConfig);
            return "";

        }

        public SecurityStepCompareInfo getSecurityStepCompareInfo()
        {
            return new SecurityStepCompareInfo()
            {
                MultipleParticipation = 4,
                Automation = 4.5F,
                Costs = 6,
                ClientEffort = 4.5F,
                Awareness = 6
            };
        }
    }
}