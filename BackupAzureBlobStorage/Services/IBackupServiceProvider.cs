using System;
using System.Collections.Generic;
using System.Text;
using BackupAzureBlobStorage.Core;

namespace BackupAzureBlobStorage.Services
{
    public interface IBackupServiceProvider
    {
        IBackupService GetBackupService(TargetType type);
    }
}
