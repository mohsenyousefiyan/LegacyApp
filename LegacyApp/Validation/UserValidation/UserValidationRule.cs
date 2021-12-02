using LegacyApp.Helpers;
using LegacyApp.Validation.Base;
using System;

namespace LegacyApp.Validation.UserValidation
{
    public class UserValidationRule : ValidationRule<User>
    {
        public override ValidationResult Validate(User model)
        {
            if (!model.Firstname.HasValue())
                return new ValidationResult(false, "نام  فاقد مقدار می باشد", nameof(model.Firstname));

            if(!model.Surname.HasValue())
                return new ValidationResult(false, "نام خانوادگی  فاقد مقدار می باشد", nameof(model.Surname));

            if(!model.EmailAddress.IsValid())
                return new ValidationResult(false, "ایمیل نامعتبر است", nameof(model.EmailAddress));


            var now = DateTime.Now;
            int age = now.Year - model.DateOfBirth.Year;

            if (now.Month < model.DateOfBirth.Month || (now.Month == model.DateOfBirth.Month && now.Day < model.DateOfBirth.Day))           
                age--;
            

            if (age < 21)
                return new ValidationResult(false, "تاریخ تولد نامعتبر است", nameof(model.DateOfBirth));
                    

            return new ValidationResult(true, null, null);
        }
    }
}
