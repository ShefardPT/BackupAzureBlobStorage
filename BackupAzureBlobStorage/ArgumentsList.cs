using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace BackupAzureBlobStorage
{
    public static class ArgumentsList
    {
        public static void Init(string[] args)
        {
            var argsList = new Dictionary<string, string>()
            {
                { "--acckey", nameof(AccountKey) },
                { "--accname", nameof(AccountName) }
            };

            var temp = args
                .Select(x => x.Split('=', StringSplitOptions.RemoveEmptyEntries))
                .Where(x => x.Length == 2)
                .ToDictionary(x => x[0], x => x[1])
                .Join(argsList, argsDict => argsDict.Key, x => x.Key, (argsDict, x) => argsDict);
            
            foreach (var item in temp)
            {
                var prop = typeof(ArgumentsList).GetProperty(argsList[item.Key]);

                if (prop == null)
                {
                    continue;
                }

                prop.SetValue(null, item.Value);
            }
        }

        public static string AccountName { get; private set; }
        public static string AccountKey { get; private set; }
    }
}
