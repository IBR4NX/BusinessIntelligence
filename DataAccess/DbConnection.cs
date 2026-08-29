using System.Data.SqlClient;

namespace DataAccess;

public class DbConnection
{
    private readonly string _connectionString;

    public DbConnection(string connectionString)
    {
        _connectionString = connectionString;
        connection = new SqlConnection(connectionString);
    }
    public SqlConnection connection { get; private set; }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
