namespace MonitoringService.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса создания резервных копий данных устройств и сессий.
    /// </summary>
    public interface IBackupService
    {
        /// <summary>
        /// Создаёт бэкап всех устройств и сессий.
        /// </summary>
        /// <returns>Кортеж с содержимым файла и его именем.</returns>
        Task<(byte[] FileContent, string FileName)> BackupAsync();
    }
}
