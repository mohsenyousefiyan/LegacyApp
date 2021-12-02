using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.ValidationRule.Base
{
    public class ValidationResult
    {
        public bool Success { get; }
        public string FieldName { get; }
        public string Error { get; }

        public ValidationResult(bool success, string error, string fieldName)
        {
            Success = success;
            Error = error;
            FieldName = fieldName;
        }
    }
}
