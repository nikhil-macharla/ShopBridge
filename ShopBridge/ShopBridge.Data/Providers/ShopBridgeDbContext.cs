using Microsoft.EntityFrameworkCore;

namespace ShopBridge.Data.Providers
{
    public class ShopBridgeDbContext : DbContext
    {
        public ShopBridgeDbContext(DbContextOptions<ShopBridgeDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopBridgeDbContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
