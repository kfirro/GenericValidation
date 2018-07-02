using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericValidation.Config
{
    public class ConfigField : IConfigField
    {
        public int MaxLength
        {
            get;
            set;
        }

        public int MinLength
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public bool PreventXSS
        {
            get;
            set;
        }

        public string RegularExpression
        {
            get;
            set;
        }

        public bool Required
        {
            get;
            set;
        }

        public string ResourceKey
        {
            get;
            set;
        }
    }
}
