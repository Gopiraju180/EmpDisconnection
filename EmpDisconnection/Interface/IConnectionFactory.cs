using Microsoft.Data.SqlClient;

namespace EmpDisconnection
{
    public interface IConnectionFactory
    {
        SqlConnection hotelmanagementsqlConnectionString();

        SqlConnection Northwind_DBSqlConnectionString();

        SqlConnection MidLandSqlConnectionString();
    }
}
