using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Results;
using GenericValidation.DataValidators;
using GenericValidation.BasicTypes;

namespace GenericValidation
{
    public static class ValidationManager
    {
        public static Dictionary<string, ValidationResult> Validate<T>(T obj,out bool isValid) 
            where T : IDataValidators
        {
            Dictionary<string, ValidationResult> results = new Dictionary<string, ValidationResult>();
            isValid = false;
            if (obj == null)
                return results;

            var validators = GetRules<T>();
            foreach (var kvp in validators)
            {
                results.Add(kvp.Key, kvp.Value.Validate(GetValueByKey(obj, kvp.Key)));
            }
            isValid = IsValid(results);
            return results;
        }
        public static object GetValueByKey(object o, string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;
            var propValue = o.GetType().GetProperty(key).GetValue(o, null);
            return propValue;
            //return propValue != null ? propValue.ToString() : null;
        }
        public static bool IsValid(Dictionary<string, ValidationResult> results)
        {
            return results.All(kvp => kvp.Value.IsValid);
        }
        public static string GetErrors(Dictionary<string, ValidationResult> results)
        {
            if (results == null)
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in results)
            {
                if (!kvp.Value.IsValid)
                {
                    sb.AppendLine($"{kvp.Key}:</br>");
                    kvp.Value.Errors.ToList().ForEach(f =>
                    {
                        sb.AppendLine($"&nbsp;&nbsp;&nbsp;&nbsp;{f.ErrorMessage}</br>");
                    });
                }
            }
            return sb.ToString();
        }
        public static KeyValuePair<string, FluentValidation.AbstractValidator<object>> GetValidator<T>(System.Reflection.PropertyInfo prop)
            where T : IDataValidators
        {
            Validators validator = ValidationManager.GetValidatorType<T>(prop);
            //TODO: Using IoC get the right validator
            switch (validator)
            {
                case Validators.EmailValidator:
                    return new KeyValuePair<string, FluentValidation.AbstractValidator<object>>(prop.Name, EmailValidator.CreateValidator(string.Empty, prop.Name));
                case Validators.TextValidator:
                default:
                    return new KeyValuePair<string, FluentValidation.AbstractValidator<object>>(prop.Name, TextValidator.CreateValidator(string.Empty, prop.Name));
            }
        }
        private static Dictionary<string,FluentValidation.AbstractValidator<object>> GetRules<T>()
            where T : IDataValidators
        {
            var rules = new Dictionary<string, FluentValidation.AbstractValidator<object>>();
            foreach (var prop in typeof(T).GetProperties())
            {
                KeyValuePair<string, FluentValidation.AbstractValidator<object>> kvp =
                    ValidationManager.GetValidator<T>(prop);
                rules.Add(kvp.Key, kvp.Value);
            }
            return rules;
        }
        private static Validators GetValidatorType<T>(System.Reflection.PropertyInfo prop)
            where T : IDataValidators
        {
            var customAttributes = (ValidatorAttribute[])typeof(T).GetCustomAttributes(typeof(ValidatorAttribute), true);
            if (customAttributes.Length > 0)
            {
                var myAttribute = customAttributes[0];
                return myAttribute.Validator;
            }
            return Validators.TextValidator; //Default validator
        }

    }
}
