using System.Data.SqlClient;

namespace DataAccess;

public class DbConnection
{
    private readonly string _connectionString;

    public SqlConnection connection { get; set; }

    public DbConnection(string connectionString)
    {
        _connectionString = connectionString;
        connection = new SqlConnection(_connectionString);
    }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
