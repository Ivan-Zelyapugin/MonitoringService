namespace MonitoringService.Services.Exceptions
{
    /// <summary>
    /// Абстрактный класс исключения NotFound.
    /// </summary>
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message) { }
    }
}
