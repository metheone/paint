using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Model.common
{
   public interface ISettings
    {
       ConnectionStringSettings GetDatabaseConnectionStringSettings();
    }
}
