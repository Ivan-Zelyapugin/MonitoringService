namespace MonitoringService.Services.Exceptions
{
    /// <summary>
    /// Абстрактный класс исключения NotFound.
    /// </summary>
    public abstract class NotFoundException : Exception
    {
        /// <summary>
        /// Абстрактный базовый класс исключений, связанных с отсутствием сущности (NotFound).
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        protected NotFoundException(string message) : base(message) { }
    }
}
