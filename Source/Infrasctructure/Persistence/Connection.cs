using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace todoListBackEnd.Source.Infrasctructure.Persistence
{
    public class Connection
    {
        public readonly IConfiguration Configuration;
        public static string ConnectionValue(string dbName) 
        {
            
            //string connString = Configuration.GetSection("ConnectionStrings")["DatabaseConnection"];
            //return connString;
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString; //"DatabaseConnection" in appsetting.json
            //"Server=PORTATIL-HUAWEI\\SQLEXPRESS;Database=SQLTutorial;Trusted_Connection=True;"

        }

    }
}
