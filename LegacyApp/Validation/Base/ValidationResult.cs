namespace LegacyApp.Validation.Base
{
    public  class ValidationResult
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
