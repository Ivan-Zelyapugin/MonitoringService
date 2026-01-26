namespace MonitoringService.Services.Interfaces
{
    public interface IBackupService
    {
        Task<(byte[] FileContent, string FileName)> BackupAsync();
    }
}
