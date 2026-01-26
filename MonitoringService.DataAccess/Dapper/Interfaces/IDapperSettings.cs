using MonitoringService.DataAccess.Dapper.Models;

namespace MonitoringService.DataAccess.Dapper.Interfaces
{
    public interface IDapperSettings
    {
        string ConnectionString { get; }
        Provider Provider { get; }
    }
}
