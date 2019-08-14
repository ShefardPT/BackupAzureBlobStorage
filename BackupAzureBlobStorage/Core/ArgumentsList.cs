using System;
using System.Collections.Generic;
using System.Linq;

namespace BackupAzureBlobStorage.Core
{
    public static class ArgumentsList
    {
        public static string AccountName { get; private set; }
        public static string AccountKey { get; private set; }
        public static TargetType Target { get; private set; }
        public static string TargetPath { get; private set; }
        public static bool DoShowHelp { get; private set; }

        public static Dictionary<string, string> ArgsList = new Dictionary<string, string>()
        {
            { "--acckey", nameof(AccountKey) },
            { "--accname", nameof(AccountName) },
            { "--target", nameof(Target) },
            { "--targetpath", nameof(TargetPath) },
            { "--help", nameof(DoShowHelp) }
        };

        public static void Init(string[] args)
        {
            var validArgsIndexes = new List<int>();

            for (int i = 0; i < args.Length; i++)
            {
                if (ArgsList.ContainsKey(args[i]))
                {
                    validArgsIndexes.Add(i);
                }
            }

            var argumentItems = new Dictionary<string, string>();

            foreach (var validArgsIndex in validArgsIndexes)
            {
                var key = args[validArgsIndex];
                var value = !validArgsIndexes.Contains(validArgsIndex + 1)
                    ? args.ElementAtOrDefault(validArgsIndex + 1)
                    : null;

                argumentItems.Add(key, value);
            }

            foreach (var item in argumentItems)
            {
                var prop = typeof(ArgumentsList).GetProperty(ArgsList[item.Key]);

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
    }
}
