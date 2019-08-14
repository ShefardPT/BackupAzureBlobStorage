using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BackupAzureBlobStorage
{
    public enum TargetType
    {
        ToBlobStorage = 1,
        ToLocalStorage = 2
    }
    public static class TargetTypeExtension
    {
        public static TargetType Parse(string key)
        {
            var dict = new Dictionary<string, TargetType>()
            {
                { "blob", TargetType.ToBlobStorage },
                { "local", TargetType.ToLocalStorage }
            };

            if (dict.TryGetValue(key, out var value))
            {
                return value;
            }

            throw new InvalidEnumArgumentException();
        }
    }
}
