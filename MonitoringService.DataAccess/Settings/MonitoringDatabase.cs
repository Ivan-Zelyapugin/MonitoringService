using MonitoringService.DataAccess.Dapper.Interfaces;
using MonitoringService.DataAccess.Dapper.Models;
using Microsoft.Extensions.Configuration;

namespace MonitoringService.DataAccess.Settings
{
    /// <summary>
    /// Настройки Dapper для MonitoringDatabase.
    /// </summary>
    public class MonitoringDatabase(IConfiguration configuration) : IDapperSettings
    {
        /// <inheritdoc />
        public string ConnectionString => configuration.GetSection("MonitoringDatabase")["ConnectionString"];

        /// <inheritdoc />
        public Provider Provider => Enum.Parse<Provider>(configuration.GetSection("MonitoringDatabase")["Provider"]);
    }
}
