using MonitoringService.DataAccess.Dapper.Interfaces;

namespace MonitoringService.DataAccess.Dapper.Models
{
    /// <summary>
    /// Запрос к БД.
    /// </summary>
    public class QueryObject : IQueryObject
    {
        /// <inheritdoc />
        public string Sql { get; }

        /// <inheritdoc />
        public object Params { get; }

        /// <inheritdoc />
        public int CommandTimeout { get; }

        /// <summary>
        /// Создаёт новый объект запроса к базе данных.
        /// </summary>
        /// <param name="sql">SQL-запрос. Не может быть <c>null</c> или пустой строкой.</param>
        /// <param name="parameters">Параметры запроса (необязательно).</param>
        /// <param name="commandTimeout">Таймаут команды в секундах. По умолчанию 30.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="sql"/> равен <c>null</c> или пустой строке.</exception>
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
