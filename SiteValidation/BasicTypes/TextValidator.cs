using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Text.RegularExpressions;
using GenericValidation.Messages;
using GenericValidation.Config;

namespace GenericValidation.BasicTypes
{
    public class TextValidator : AbstractValidator<object>
    {
        public TextValidator(bool isRequired,string resourceKey = "", string regularExpression = "", int minLength = -1, int maxLength = -1, bool preventXSS = true)
        {
            if (isRequired)
                RuleFor(s => s).NotNull().NotEmpty()
                    .WithMessage(Messages.Messages.NULL_OR_EMPTY_MSG);
            if (!string.IsNullOrEmpty(regularExpression))
                RuleFor(s => s.ToString()).Matches(regularExpression)
                    .WithMessage(Messages.Messages.REGULAR_EXPRESSION_MSG);
            if (minLength > -1)
                RuleFor(s => s).Must(s => s.ToString().Length >= minLength)
                    .WithMessage(Messages.Messages.MINIMUM_LENGTH_MSG);
            if (maxLength > -1)
                RuleFor(s => s).Must(s => s.ToString().Length <= maxLength)
                    .WithMessage(Messages.Messages.MAXIMUM_LENGTH_MSG);
            if (preventXSS)
                RuleFor(s => s).Must(s=> !(s.ToString().Contains("<") || s.ToString().Contains(">")) )
                    .WithMessage(Messages.Messages.PREVENT_XSS_EXPRESSION_MSG);
        }
        public static TextValidator CreateValidator(string wrapperName, string fieldName)
        {
            ConfigManager cm = new ConfigManager();
            IConfigField field = cm.GetAbstractValidatorByName(wrapperName, fieldName);
            if (field == null)
                return new TextValidator(false);
            return new TextValidator(field.Required, field.ResourceKey ,field.RegularExpression, field.MinLength, field.MaxLength, field.PreventXSS);
        }
    }
}
