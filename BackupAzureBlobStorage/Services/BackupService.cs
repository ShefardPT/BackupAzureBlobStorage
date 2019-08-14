using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;

namespace BackupAzureBlobStorage.Services
{
    public abstract class BackupService : IBackupService
    {
        public BackupService
            (string accountName, string accountKey)
        {
            StorageCredentials storageCredentials;
            try
            {
                storageCredentials = new StorageCredentials(accountName, accountKey);
            }
            catch (FormatException ex)
            {
                throw;
            }

            StorageAccount = new CloudStorageAccount(storageCredentials, true);
            BlobClient = StorageAccount.CreateCloudBlobClient();
        }

        protected CloudStorageAccount StorageAccount { get; private set; }
        protected CloudBlobClient BlobClient { get; private set; }
        protected FileInfo Azcopy = new FileInfo("azcopy\\azcopy.exe");

        public abstract bool BackupStorage
            (string target);

        protected string GetSharedAccessSignature()
        {
            var sharePolicy = new SharedAccessAccountPolicy()
            {
                Services = SharedAccessAccountServices.Blob,
                Permissions = SharedAccessAccountPermissions.Read,
                ResourceTypes = SharedAccessAccountResourceTypes.Object,
                Protocols = SharedAccessProtocol.HttpsOnly
            };

            var token = StorageAccount.GetSharedAccessSignature(sharePolicy);

            return token;
        }
    }
}
