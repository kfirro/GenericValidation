using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericValidation.Messages
{
    public static class Messages
    {
        public const string NULL_OR_EMPTY_MSG = "Field is null or empty!";
        public const string REQUIRED_MSG = "This field is required!";
        public const string MINIMUM_LENGTH_MSG = "Minimum characters limit reached!";
        public const string MAXIMUM_LENGTH_MSG = "Minimum characters limit reached!";
        public const string REGULAR_EXPRESSION_MSG = "Regular Expression did not matched!";
        public const string EMAIL_EXPRESSION_MSG = "Email is not valid!";
        public const string PREVENT_XSS_EXPRESSION_MSG = "Input characters is not allowed!";
    }
}
