using PetShop.Application.Helpers;
using PetShop.Application.Interfaces.Repositories;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;

namespace PetShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public User? Authenticate(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null) 
            {
                return null;
            }

            bool valid = PasswordHasher.VerifyPassword(password, user.Password);
            return valid ? user : null;
        }
    }
}
