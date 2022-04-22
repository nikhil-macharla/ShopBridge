using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Services.Core.Interfaces;
using ShopBridge.Services.Data.Providers;

namespace ShopBridge.Services.Data.Extensions
{
    public static class ContainerServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
