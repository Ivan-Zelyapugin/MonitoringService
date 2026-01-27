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
    /// <summary>
    /// Класс с методами расширения для добавления функциональности слоя доступа к данным.
    /// </summary>
    public static class DataAccessExtensions
    {
        /// <summary>
        /// Выполняет миграцию базы данных.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
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

        /// <summary>
        /// Добавляет поддержку Dapper.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddDapper(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDapperSettings, MonitoringDatabase>()
                .AddSingleton<IDapperContext<IDapperSettings>, DapperContext<IDapperSettings>>();
        }

        /// <summary>
        /// Добавляет репозитории.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IDeviceRepository, DeviceRepository>()
                .AddScoped<IActivitySessionRepository, ActivitySessionRepository>();
        }
    }
}

    
