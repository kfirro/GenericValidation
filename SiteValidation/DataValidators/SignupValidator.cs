using System.Collections.Generic;
using GenericValidation.BasicTypes;
using FluentValidation;

namespace GenericValidation.DataValidators
{
    public class SignupValidator : IDataValidators
    {
        [Validator(Validator = Validators.TextValidator)]
        public string username { get; set; }

        [Validator(Validator = Validators.TextValidator)]
        public string password { get; set; }

        [Validator(Validator = Validators.EmailValidator)]
        public string email { get; set; }
    }
}
