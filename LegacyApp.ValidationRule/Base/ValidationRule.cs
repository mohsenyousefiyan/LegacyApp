namespace LegacyApp.ValidationRule.Base
{
    public abstract class ValidationRule<T>
    {
        abstract protected ValidationResult Validation(T model);
    }
}
