using LegacyApp.Validation.UserValidation;
using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientRepository clientRepository;
        private readonly IUserRepository userRepository;
        private readonly UserFactoryService userFactoryService;

        public UserService(IClientRepository clientRepository,IUserRepository userRepository, UserFactoryService userFactoryService )
        {
            this.clientRepository = clientRepository;
            this.userRepository = userRepository;
            this.userFactoryService = userFactoryService;
        }

        public UserService()
        {
            this.clientRepository= new ClientRepository();        
            this.userFactoryService=new UserFactoryService(new UserValidationRule(),new UserCreditServiceClient());
            this.userRepository = new UserDataAccess();
        }

        public bool AddUser(string firname, string surname, string email, DateTime dateOfBirth, int clientId)
        {           
            var client = clientRepository.GetById(clientId);
            
            var user = userFactoryService.Create(client,firname,surname,dateOfBirth,email);
           
            if(user==null)  
                return false;
                                            
            if (user.HasCreditLimit && user.CreditLimit < 500)          
                return false;


            userRepository.AddUser(user);

            return true;
        }
       
    }
}