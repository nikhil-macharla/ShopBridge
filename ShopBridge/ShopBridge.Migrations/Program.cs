using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace ShopBridge.Migrations
{
    public class Program
    {
        public static void Main()
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration(config => config.AddJsonFile("appsettings.json", false))
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddHostedService<MigrationRunnerService>();
                    services.AddFluentMigratorCore()
                    .ConfigureRunner(runner =>
                        runner.AddSqlServer()
                        .WithGlobalConnectionString(hostContext.Configuration.GetConnectionString("ShopBridgeConnection"))
                        .WithGlobalCommandTimeout(TimeSpan.FromMinutes(5))
                        .ScanIn(Assembly.GetExecutingAssembly()).For.All()
                    );
                })
                .ConfigureLogging(logging => logging.AddFluentMigratorConsole());

            using var host = builder.Build();
            var migrator = host.Services.GetService<IMigrationRunner>();
            migrator.MigrateUp();
        }
    }
}
