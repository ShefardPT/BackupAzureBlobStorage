using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BackupAzureBlobStorage.Core;
using BackupAzureBlobStorage.Services;

namespace BackupAzureBlobStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ArgumentsList.Init(args);
            }
            catch (InvalidEnumArgumentException)
            {
                Console.WriteLine("Cannot recognize parameters.");
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (ArgumentsList.DoShowHelp)
            {
                new HelpInfoShower().ShowHelp();
                return;
            }








            Console.ReadLine();
        }

    }
}
