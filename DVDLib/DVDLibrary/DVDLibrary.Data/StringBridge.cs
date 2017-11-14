using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data
{
    public class StringBridge
    {
        private static string _connectionString;

        public static string ConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;
            }
            return _connectionString;
        }
    }
}
