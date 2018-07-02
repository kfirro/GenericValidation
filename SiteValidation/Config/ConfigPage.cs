using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericValidation.Config
{
    public class ConfigPage : IFieldWrapper
    {
        public List<IConfigField> Fields
        {
            get;
            set;
        }
    }
}
