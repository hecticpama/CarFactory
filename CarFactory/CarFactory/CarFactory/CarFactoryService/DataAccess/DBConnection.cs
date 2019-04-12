using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CarFactoryService.DataAccess;

namespace CarFactoryService
{
    public class DBConnection
    {
        DataConnect db = new DataConnect();

        public string ConnectDB(string connectionName)
        {
            connectionName = db.Connect(connectionName);
            return connectionName;
        }
    }
}
