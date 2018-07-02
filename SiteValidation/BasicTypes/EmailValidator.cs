using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using GenericValidation.Config;

namespace GenericValidation.BasicTypes
{
    public class EmailValidator : AbstractValidator<object>
    {
        private readonly Regex EMAIL_REGEX = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public EmailValidator(bool isRequired,string resourceKey = "")
        {
            if (isRequired)
                RuleFor(s => s).NotNull().NotEmpty()
                    .WithMessage(Messages.Messages.NULL_OR_EMPTY_MSG);
            RuleFor(s => s.ToString()).Matches(EMAIL_REGEX).
                WithMessage(Messages.Messages.EMAIL_EXPRESSION_MSG);
        }
        public static EmailValidator CreateValidator(string wrapperName, string fieldName)
        {
            ConfigManager cm = new ConfigManager();
            IConfigField field = cm.GetAbstractValidatorByName(wrapperName, fieldName);
            if (field == null)
                return new EmailValidator(false);
            return new EmailValidator(field.Required, field.ResourceKey);
        }
    }
}
