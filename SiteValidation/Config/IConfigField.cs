using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericValidation.Config
{
    public interface IConfigField
    {
        string Name { get; set; }
        bool PreventXSS { get; set; }
        bool Required { get; set; }
        int MinLength { get; set; }
        int MaxLength { get; set; }
        string RegularExpression { get; set; }
        string ResourceKey { get; set; }
    }
}
