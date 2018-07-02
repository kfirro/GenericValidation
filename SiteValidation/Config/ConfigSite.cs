using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericValidation.Config
{
    public class ConfigSite : IWrapper
    {
        public List<IFieldWrapper> Wrappers
        {
            get;
            set;
        }
    }
}
