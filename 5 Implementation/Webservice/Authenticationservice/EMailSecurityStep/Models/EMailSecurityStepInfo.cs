using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Composition;
using System.Reflection;

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
            EMailSecurityStepConfig eMailSecurityStepConfig; 
            try
            {
                
                eMailSecurityStepConfig = DictionaryToObject<EMailSecurityStepConfig>(config);
            }
            catch(Exception ex)
            {
                throw new HttpException(512, "False Parameters");
            }

            if(eMailSecurityStepConfig.ProjectId!= projectId)
            {
                throw new HttpException(511, "No ProjectAcess ");
            }

            var context = new ValidationContext(eMailSecurityStepConfig, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(eMailSecurityStepConfig, context, results);
            if (!isValid)
                throw new HttpException(510, "Parameters are not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage).ToArray()));

            new EF_EMailSecurityStepConfigRepository().SaveEMailSecurityConfigByProjectId(eMailSecurityStepConfig);
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