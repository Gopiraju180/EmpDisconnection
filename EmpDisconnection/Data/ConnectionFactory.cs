using EmpDisconnection.Data;
using EmpDisconnection.utils;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmpDisconnection.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _config;
        public ConnectionFactory(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection hotelmanagementsqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection(ConnectionStringName.DBHotelConnectionStringName).Value);
            SqlConnection con = new SqlConnection(connStr);
            return con;
        }

        public SqlConnection MidLandSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection(ConnectionStringName.DBMidLandSqlConnectionStringName).Value);
            SqlConnection con = new SqlConnection(connStr);
            return con;
        }

        public SqlConnection Northwind_DBSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection(ConnectionStringName.DBNorthwind_DBSqlConnectionStringName).Value);
            SqlConnection con = new SqlConnection(connStr);
            return con;
        }
    }
}


