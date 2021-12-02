using LegacyApp.Helpers;
using LegacyApp.Validation.Base;
using System;

namespace LegacyApp.Validation.UserValidation
{
    public class UserValidationRule : BaseValidationRule<User>
    {
        public override ValidationResult Validate(User model)
        {         
            var validationResult=new ValidationResult();

            if (!model.Firstname.HasValue())
                validationResult.AddErrors(nameof(model.Firstname), "نام  فاقد مقدار می باشد");

            if(!model.Surname.HasValue())
                validationResult.AddErrors(nameof(model.Surname), "نام خانوادگی  فاقد مقدار می باشد");

            if(!model.EmailAddress.IsValid())
                validationResult.AddErrors(nameof(model.EmailAddress), "ایمیل نامعتبر است");


            var now = DateTime.Now;
            int age = now.Year - model.DateOfBirth.Year;
            if (now.Month < model.DateOfBirth.Month || (now.Month == model.DateOfBirth.Month && now.Day < model.DateOfBirth.Day))           
                age--;
            
            if (age < 21)
               validationResult.AddErrors(nameof(model.DateOfBirth),"تاریخ تولد نامعتبر است" );


            return validationResult;
        }
    }
}
