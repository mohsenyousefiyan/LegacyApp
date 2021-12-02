namespace LegacyApp.Validation.Base
{
    public abstract class ValidationRule<T>
    {
        abstract public ValidationResult Validate(T model);
    }
}
