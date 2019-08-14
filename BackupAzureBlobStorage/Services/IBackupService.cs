namespace BackupAzureBlobStorage.Services
{
    public interface IBackupService
    {
        bool BackupStorage
            (string target);
    }
}
