using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    public class UserCreditCalculateService
    {
        private readonly User user;
        private readonly UserCreditServiceClient userCreditService;

        public UserCreditCalculateService(User user, UserCreditServiceClient userCreditService)
        {
            this.user = user;
            this.userCreditService = userCreditService;
        }

        public void Handle()
        {
            if (user.Client.Name == "VeryImportantClient")        
                user.HasCreditLimit = false;            
            else if (user.Client.Name == "ImportantClient")
            {
                
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditServiceClient())
                {
                    var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                // Do credit check
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditServiceClient())
                {
                    var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }
        }
    }
}
