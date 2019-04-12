using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CarFactoryService.DataAccess;

namespace CarFactory
{
    class DataConnection
    {
        public string connectionName;

        DataConnect db = new DataConnect();

        public string ConnectDB()
        {
            string connectionName;
            connectionName = db.Connect(connectionName);
            this.connectionName = connectionName;

            return connectionName;
        }
    }
}
