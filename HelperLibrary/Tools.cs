using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public static class Tools
    {
        public static string GetConnectionStringPerson(string name = "PersonDB")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string GetConnectionStringDapper(string name = "DapperDB")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
}
