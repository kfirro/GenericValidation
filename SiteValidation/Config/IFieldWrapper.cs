﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericValidation.Config
{
    public interface IFieldWrapper
    {
        List<IConfigField> Fields { get; set; }
    }
}