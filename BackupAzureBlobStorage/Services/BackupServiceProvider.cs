using System.Collections.Generic;
using System.Text;
using BackupAzureBlobStorage.Core;

namespace BackupAzureBlobStorage.Services
{
    public class BackupServiceProvider : IBackupServiceProvider
    {
        public IBackupService GetBackupService(TargetType type)
        {
            var dict = new Dictionary<TargetType, IBackupService>()
            {
                { TargetType.ToLocalStorage, new BackupToLocalStorageService() },
                { TargetType.ToBlobStorage, new BackupToBlobStorageService() }
            };

            return dict[type];
        }
    }
}
