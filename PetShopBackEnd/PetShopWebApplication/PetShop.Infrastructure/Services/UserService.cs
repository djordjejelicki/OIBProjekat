using PetShop.Application.Helpers;
using PetShop.Application.Interfaces.Repositories;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;

namespace PetShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoggerService _loggerService;
        public UserService(IUserRepository userRepository,ILoggerService loggerService)
        {
            _userRepository = userRepository;
            _loggerService = loggerService;
        }
        
        public User? Authenticate(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null) 
            {
                _loggerService.Log(LogLevel.Error, $"Login failed — user not found: {username}");
                return null;
            }

            bool valid = PasswordHasher.VerifyPassword(password, user.Password);
            if (valid) 
            {
                _loggerService.Log(LogLevel.Info, $"User successfully logged in: {username}");
                return user;
            }
            else
            {
                _loggerService.Log(LogLevel.Error, $"Login failed — wrong password for user: {username}");
                return null;
            }
                
        }
    }
}
