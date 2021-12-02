namespace LegacyApp.Helpers
{
    public static class EmailHelper
    {
        public static bool IsValid(this string email)
        {
            if (!email.HasValue())
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        } 
    }
}
