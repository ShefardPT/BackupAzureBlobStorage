namespace BackupAzureBlobStorage.Services
{
    public interface IBackupService
    {
        bool BackupStorage
            (string accountName, string accountKey,  string target);
    }
}
