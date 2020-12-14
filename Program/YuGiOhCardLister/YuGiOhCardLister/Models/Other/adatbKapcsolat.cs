using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace YuGiOhCardLister.Models.Other
{
    class adatbKapcsolat
    {
        public OracleConnection openConnection()
        {
            OracleConnection connection = new OracleConnection();

            string connectionString = @"Data Source = 193.225.33.71;User Id = ORA_S1340;Password = EKE2020;";
            connection.ConnectionString = connectionString;
            connection.Open();
            return connection;
        }
        
    }
}
