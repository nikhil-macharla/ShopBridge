using ShopBridge.Services.Core.Models;
using System.Threading.Tasks;

namespace ShopBridge.Data.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserAsync(UserLogin userLogin);
    }
}
