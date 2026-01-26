using MonitoringService.DataAccess.Dapper.Interfaces;

namespace MonitoringService.DataAccess.Dapper.Models
{
    public class QueryObject : IQueryObject
    {
        public string Sql { get; }
        public object Params { get; }
        public int CommandTimeout { get; }

        public QueryObject(string sql, object parameters = null, int commandTimeout = 30) 
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }

            Sql = sql;
            Params = parameters;
            CommandTimeout = commandTimeout;
        }
    }
}
