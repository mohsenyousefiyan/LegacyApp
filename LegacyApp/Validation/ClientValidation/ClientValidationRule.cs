using LegacyApp.Validation.Base;
using System;

namespace LegacyApp.Validation.ClientValidation
{
    public class ClientValidationRule : ValidationRule<Client>
    {
        public override ValidationResult Validate(Client model)
        {
            throw new NotImplementedException();
        }
    }
}
