using ShopBridge.Data.Core.Interfaces;
using ShopBridge.Services.Core.Interfaces;
using ShopBridge.Services.Core.Models;
using System;
using System.Threading.Tasks;

namespace ShopBridge.Services.Data.Providers
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<User> Login(UserLogin userLogin)
        {
            return await _userRepository.GetUserAsync(userLogin);
        }
    }
}
