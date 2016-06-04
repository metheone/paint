using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Model.common
{
    public class Settings :ISettings
    {
        private readonly string _databaseConnectionString;

        public Settings(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }
        public ConnectionStringSettings GetDatabaseConnectionStringSettings()
        {
            return ConfigurationManager.ConnectionStrings[_databaseConnectionString];
        }
    }
}
