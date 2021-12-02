using System;
using System.Collections.Generic;
using System.Linq;

namespace LegacyApp.Validation.Base
{
    public abstract class BaseValidationRule<T>
    {
        private readonly Dictionary<string, string> _errors;

        public BaseValidationRule()
        {
            
        }
        
        abstract public ValidationResult Validate(T model);         
    }
}
