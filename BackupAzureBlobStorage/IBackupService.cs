using System;
using System.Collections.Generic;
using System.Text;

namespace BackupAzureBlobStorage
{
    public interface IBackupService
    {
        bool BackupStorage
            (string accountName, string accountKey,  string target);
    }
}
