using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BackupAzureBlobStorage.Core;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;

namespace BackupAzureBlobStorage.Services
{
    public class BackupToLocalStorageService : BackupService
    {
        public BackupToLocalStorageService(string accountName, string accountKey) : base(accountName, accountKey)
        {
        }

        public override bool BackupStorage
            (string target)
        {
            var directoryInfo = new DirectoryInfo(target);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();

                //throw new PathArgumentException
                //    ("The target path is invalid.",  nameof(ArgumentsList.Target));
            }

            var storageUri = StorageAccount.BlobStorageUri;
            var SASToken = GetSharedAccessSignature();

            var arguments = $"cp \"{storageUri.PrimaryUri}{SASToken}\" \"{directoryInfo.FullName}\" --recursive\"";

            // TODO THIS NEED TESTS BEFORE
            //Process.Start(Azcopy.FullName, arguments);

            return true;
        }
    }
}