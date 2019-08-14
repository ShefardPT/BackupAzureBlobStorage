using System;
using System.IO;

namespace BackupAzureBlobStorage.Services
{
    public class BackupToBlobStorageService : BackupService
    {
        public BackupToBlobStorageService(string accountName, string accountKey)
            : base(accountName, accountKey)
        {
        }

        public override bool BackupStorage
            (string target)
        {
            var storageUri = StorageAccount.BlobStorageUri;
            var SASToken = GetSharedAccessSignature();

            var arguments = $"cp \"{storageUri.PrimaryUri}{SASToken}\" \"{target}\" --recursive\"";

            // TODO THIS NEED TESTS BEFORE
            //Process.Start(Azcopy.FullName, arguments);

            return true;
        }
    }
}