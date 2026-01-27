namespace MonitoringService.DataAccess.Dapper.Interfaces
{
    /// <summary>
    /// Интерфейс контекста Dapper для работы с БД.
    /// </summary>
    /// <typeparam name="TSettings"><see cref="IDapperSettings"/>.</typeparam>
    public interface IDapperContext<TSettings> where TSettings : IDapperSettings
    {
        /// <summary>
        /// Получает первый элемент выборки или значение по умолчанию, если выборка пустая.
        /// </summary>
        /// <param name="queryObject"><see cref="IQueryObject"/>.</param>
        /// <typeparam name="T">Тип возвращаемого объекта.</typeparam>
        /// <returns>Первый элемент выборки или значение по умолчанию, если выборка пустая.</returns>
        Task<T> FirstOrDefault<T> (IQueryObject queryObject);

        /// <summary>
        /// Получает список элементов выборки или пустой список, если выборка пустая.
        /// </summary>
        /// <param name="queryObject"><see cref="IQueryObject"/>.</param>
        /// <typeparam name="T">Тип возвращаемого объекта.</typeparam>
        /// <returns>Список элементов выборки или пустой список, если выборка пустая.</returns>
        Task<List<T>> ListOrEmpty<T>(IQueryObject queryObject);

        /// <summary>
        /// Выполняет запрос в БД и использует транзакцию, если требуется.
        /// </summary>
        /// <param name="queryObject"><see cref="IQueryObject"/>.</param>
        Task Command(IQueryObject queryObject);
    }
}
