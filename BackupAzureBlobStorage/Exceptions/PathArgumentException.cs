using System;
using System.Collections.Generic;
using System.Text;

namespace BackupAzureBlobStorage.Exceptions
{
    public class PathArgumentException : ArgumentException
    {
        public PathArgumentException() 
            : base()
        {
            
        }

        public PathArgumentException(string message) 
            : base(message)
        {
            
        }

        public PathArgumentException(string message, string paramName) 
            : base(message, paramName)
        {

        }
    }
}
