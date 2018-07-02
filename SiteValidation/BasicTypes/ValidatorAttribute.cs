using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericValidation.BasicTypes
{
    public enum Validators { TextValidator, EmailValidator }
    public class ValidatorAttribute : Attribute
    {
        public Validators Validator { get; set; }
    }
}
