namespace MonitoringService.Services.Exceptions
{
    /// <summary>
    /// Абстрактный класс исключения BadRequest.
    /// </summary>
    public abstract class BadRequestException : Exception
    {
        /// <summary>
        /// Абстрактный базовый класс исключений, связанных с некорректными запросами (BadRequest).
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        protected BadRequestException(string message) : base(message) { }
    }
}
