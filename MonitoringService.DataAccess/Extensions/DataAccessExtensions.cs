using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonitoringService.DataAccess.Dapper;
using MonitoringService.DataAccess.Dapper.Interfaces;
using MonitoringService.DataAccess.Repositories;
using MonitoringService.DataAccess.Repositories.Interfaces;
using MonitoringService.DataAccess.Settings;
using System.Reflection;

namespace MonitoringService.DataAccess.Extensions
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection MigrateDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MonitoringDatabase")["ConnectionString"];

            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .WithTransaction()
                .WithVariablesDisabled()
                .LogToConsole()
                .Build();

            if (upgrader.IsUpgradeRequired())
            {
                upgrader.PerformUpgrade();
            }

            return services;
        }

        public static IServiceCollection AddDapper(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDapperSettings, MonitoringDatabase>()
                .AddSingleton<IDapperContext<IDapperSettings>, DapperContext<IDapperSettings>>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IDeviceRepository, DeviceRepository>()
                .AddScoped<IActivitySessionRepository, ActivitySessionRepository>();
        }
    }
}

    
