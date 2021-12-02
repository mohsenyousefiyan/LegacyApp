using System;
using System.Collections.Generic;
using System.Linq;

namespace LegacyApp.Validation.Base
{
    public  class ValidationResult
    {
        private readonly Dictionary<string, string> _errors;
       

        public ValidationResult()
        {
            _errors = new Dictionary<string, string>();
        }

        public void AddErrors(string fieldName, string errorMessage)
        {
            if (_errors.ContainsKey(fieldName))
                _errors[fieldName] += Environment.NewLine + errorMessage;
            else
                _errors.Add(fieldName, errorMessage);
        }
        public Dictionary<string, string> GetErrors() => _errors;
        public void ClearErrors() => _errors.Clear();
        public bool IsSuccess => ! _errors.Any();
    }
}
