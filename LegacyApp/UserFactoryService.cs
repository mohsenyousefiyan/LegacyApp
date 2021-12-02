using LegacyApp.Validation.UserValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LegacyApp
{
    public class UserFactoryService
    {
        private const string VeryImportantClient = "VeryImportantClient";
        private const string ImportantClient = "ImportantClient";

        private readonly UserValidationRule userValidationRule;
        private readonly UserCreditServiceClient userCreditServiceClient;
        private Dictionary<string, Func<User, User>> calcDictionary;

        public UserFactoryService(UserValidationRule userValidationRule,UserCreditServiceClient userCreditServiceClient)
        {
            calcDictionary = new Dictionary<string, Func<User, User>>();
            calcDictionary.Add(VeryImportantClient, CalculateVeryImportantClient);
            calcDictionary.Add(ImportantClient, CalculateImportantClient);

            this.userValidationRule = userValidationRule;
            this.userCreditServiceClient = userCreditServiceClient;
        }
        public  User Create(Client Client, string Firstname, string Surname, DateTime DateOfBirth, string EmailAddress)
        {
            var user = new User
            {
                Client = Client,
                Firstname = Firstname,
                Surname = Surname,
                DateOfBirth = DateOfBirth,
                EmailAddress = EmailAddress
            };
            
            if (!userValidationRule.Validate(user).IsSuccess)
                return null;

           
            var calculator=calcDictionary.Where(x=>x.Key==Client.Name)
                .Select(x=>x.Value)
                .FirstOrDefault();

            if (calculator == null)
                calculator = CalculateNormalClient;

            user=calculator.Invoke(user);

            return user;
        }

        private User CalculateVeryImportantClient(User user)
        {
            user.HasCreditLimit = false;
            return user;
        }

        private User CalculateImportantClient(User user)
        {
            user.HasCreditLimit = true;           
            user.CreditLimit = GetCredit(user) * 2;

            return user;
        }

        private User CalculateNormalClient(User user)
        {
            user.HasCreditLimit = true;            
            user.CreditLimit = GetCredit(user);

            return user;
        }

        private int GetCredit(User user)
        {
            return userCreditServiceClient.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
        }
    }
}
