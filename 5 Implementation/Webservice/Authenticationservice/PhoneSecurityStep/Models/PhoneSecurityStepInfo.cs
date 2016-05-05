using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Composition;
using System.Reflection;

namespace PhoneSecurityStep.Models
{
    [Export(typeof(SecurityStepContract.ISecurityStepInfo))]
    public class PhoneSecurityStepInfo : SecurityStepContract.ISecurityStepInfo
    {
        private IPhoneSecurityStepConfigRepository PhoneSecurityStepConfigRepository;
        private IPhoneSecurityStepValidationRepository PhoneSecurityStepValidationRepository;

        public PhoneSecurityStepInfo() : this(new EF_PhoneSecurityStepConfigRepository(), new EF_PhoneSecurityStepValidationRepository()) { }
        public PhoneSecurityStepInfo(IPhoneSecurityStepConfigRepository PhoneSecurityStepConfigRepository,
            IPhoneSecurityStepValidationRepository PhoneSecurityStepValidationRepository)
        {
            this.PhoneSecurityStepConfigRepository = PhoneSecurityStepConfigRepository;
            this.PhoneSecurityStepValidationRepository = PhoneSecurityStepValidationRepository;
        }
        public bool checkIsValidated(int projectid, string providerid)
        {
            PhoneSecurityStepValidation PhoneSecurityStepValidation =
                PhoneSecurityStepValidationRepository.GetPhoneSecurityStepValidationForValid(projectid, providerid);

            if (PhoneSecurityStepValidation != null && PhoneSecurityStepValidation.StatusId == 1)
            {
                return true;
            }
            return false;
        }

        public object getConfigParameters(int projectId)
        {
            PhoneSecurityStepConfig config=
                new EF_PhoneSecurityStepConfigRepository().GetPhoneSecurityStepConfigByProjectId(projectId);

            if (config == null)
            {
                config = new PhoneSecurityStepConfig();
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
            PhoneSecurityStepConfig PhoneSecurityStepConfig; 
            try
            {
                
                PhoneSecurityStepConfig = DictionaryToObject<PhoneSecurityStepConfig>(config);
            }
            catch(Exception ex)
            {
                throw new HttpException(512, "False Parameters");
            }

            if(PhoneSecurityStepConfig.ProjectId!= projectId)
            {
                throw new HttpException(511, "No ProjectAcess ");
            }

            var context = new ValidationContext(PhoneSecurityStepConfig, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(PhoneSecurityStepConfig, context, results);
            if (!isValid)
                throw new HttpException(510, "Parameters are not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage).ToArray()));

                PhoneSecurityStepConfigRepository.SavePhoneSecurityConfigByProjectId(PhoneSecurityStepConfig);
            return "";

        }

        public SecurityStepCompareInfo getSecurityStepCompareInfo()
        {
            return new SecurityStepCompareInfo()
            {
                MultipleParticipation = 5.25F, 
                Automation = 5.75F,
                Costs = 5,
                ClientEffort = 4.5F,
                Awareness = 5.75F
            };
        }
    }
}