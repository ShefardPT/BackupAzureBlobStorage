using System;
using System.Collections.Generic;
using System.Linq;

namespace BackupAzureBlobStorage.Core
{
    public static class ArgumentsList
    {
        public static void Init(string[] args)
        {
            var argsList = new Dictionary<string, string>()
            {
                { "--acckey", nameof(AccountKey) },
                { "--accname", nameof(AccountName) },
                { "--target", nameof(Target) },
                { "--targetpath", nameof(TargetPath) },
                { "--help", nameof(DoShowHelp) }
            };

            var temp = args
                .Select(x => x.Split('=', StringSplitOptions.RemoveEmptyEntries))
                .Where(x => x.Any())
                .Select(x => new string[2]
                {
                    x[0],
                    x.ElementAtOrDefault(1)
                })
                .ToDictionary(x => x[0], x => x[1])
                .Join(argsList, argsDict => argsDict.Key, x => x.Key, (argsDict, x) => argsDict);

            foreach (var item in temp)
            {
                var prop = typeof(ArgumentsList).GetProperty(argsList[item.Key]);

                if (prop == null)
                {
                    continue;
                }

                var parseDict = new Dictionary<Type, Func<string, object>>()
                {
                    { typeof(string), x => x },
                    { typeof(TargetType), x => TargetTypeExtension.Parse(x) },
                    { typeof(bool), x => true }
                };

                if (!parseDict.ContainsKey(prop.PropertyType))
                {
                    throw new Exception("Cannot parse input value.");
                }

                prop.SetValue(null, parseDict[prop.PropertyType].Invoke(item.Value));
            }
        }

        public static string AccountName { get; private set; }
        public static string AccountKey { get; private set; }
        public static TargetType Target { get; private set; }
        public static string TargetPath { get; private set; }
        public static bool DoShowHelp { get; private set; }
    }
}
