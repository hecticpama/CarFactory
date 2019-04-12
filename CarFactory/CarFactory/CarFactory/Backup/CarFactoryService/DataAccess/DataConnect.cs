using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace CarFactoryService.DataAccess
{
    public class DataConnect
    {
        public string Connect(string connectionString)
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            return connectionString;
        }
    }
}
