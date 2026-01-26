namespace MonitoringService.DataAccess.Dapper.Interfaces
{
    public interface IDapperContext<TSettings> where TSettings : IDapperSettings
    {
        Task<T> FirstOrDefault<T> (IQueryObject queryObject);
        Task<List<T>> ListOrEmpty<T>(IQueryObject queryObject);
        Task Command(IQueryObject queryObject);
    }
}
