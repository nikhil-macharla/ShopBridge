using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Data.Core.Interfaces;
using ShopBridge.Data.Providers;

namespace ShopBridge.Data.Extensions
{
    public static class DataAccessContainerServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ShopBridgeConnection");
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<ShopBridgeDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
        }
    }
}
