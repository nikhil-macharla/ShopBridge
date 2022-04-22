using Microsoft.EntityFrameworkCore;
using ShopBridge.Data.Core.Interfaces;
using ShopBridge.Services.Core.Models;
using System.Threading.Tasks;

namespace ShopBridge.Data.Providers
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ShopBridgeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserAsync(UserLogin userLogin)
        {
            var user =await FindByAsNoTracking(x => x.Username.ToLower() == userLogin.Username.ToLower() && x.Password == userLogin.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
