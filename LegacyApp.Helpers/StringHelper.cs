namespace LegacyApp.Helpers
{
    public static class StringHelper
    {
        public static bool HasValue(this string value)
        {
            return !(string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value));
        }
    }
}
