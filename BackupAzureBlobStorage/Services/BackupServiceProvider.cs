using System;
using System.Collections.Generic;
using System.Text;
using BackupAzureBlobStorage.Core;

namespace BackupAzureBlobStorage.Services
{
    public class BackupServiceProvider : IBackupServiceProvider
    {
        public IBackupService GetBackupService(TargetType type)
        {
            var dict = new Dictionary<TargetType, Type>()
            {
                {
                    TargetType.ToLocalStorage,
                    typeof(BackupToLocalStorageService)
                },
                {
                    TargetType.ToBlobStorage,
                    typeof(BackupToBlobStorageService)
                }
            };

            var serviceType = dict[type];

            var service = serviceType
                .GetConstructor(new Type[] {typeof(string), typeof(string)})
                .Invoke(new object[] {ArgumentsList.AccountName, ArgumentsList.AccountKey});


            return (IBackupService)service;
        }
    }
}
