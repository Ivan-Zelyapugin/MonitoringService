namespace MonitoringService.Services.Exceptions
{
    /// <summary>
    /// Абстрактный класс исключения BadRequest.
    /// </summary>
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message) : base(message) { }
    }
}
