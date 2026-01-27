namespace MonitoringService.DataAccess.Dapper.Models
{
    /// <summary>
    /// Провайдер БД.
    /// </summary>
    public enum Provider
    {
        /// <summary>
        /// Нет провайдера.
        /// </summary>
        None = 0,

        /// <summary>
        /// PostgreSQL.
        /// </summary>
        PostgreSQL = 1
    }
}
