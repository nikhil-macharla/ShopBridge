using ShopBridge.Services.Core.Models;
using System.Threading.Tasks;

namespace ShopBridge.Services.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(UserLogin userLogin);
    }
}
