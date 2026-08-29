using System.Data;
using System.Data.SqlClient;

namespace DataAccess;

public class DataRepository
{
    private readonly SqlConnection connection;

    public DataRepository(DbConnection dbConnection)
    {
        connection = dbConnection.connection;
    }

    public DataTable GetTableData(string tableName)
    {
        var table = new DataTable();

        //using SqlConnection connection = _dbConnection.CreateConnection();


        using SqlCommand command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM [{tableName}]";

        using SqlDataAdapter adapter = new SqlDataAdapter(command);

        adapter.Fill(table);

        return table;
    }

    public DataTable GetById(string tableName, string primaryKeyColumn, object id)
    {
        var table = new DataTable();

        //using SqlConnection connection = _dbConnection.CreateConnection();


        using SqlCommand command = connection.CreateCommand();

        command.CommandText =
            $"SELECT * FROM [{tableName}] WHERE [{primaryKeyColumn}] = @Id";

        command.Parameters.AddWithValue("@Id", id);

        using SqlDataAdapter adapter = new SqlDataAdapter(command);

        adapter.Fill(table);

        return table;
    }
    public DataTable ExecuteQuery(string query)
    {
        var table = new DataTable();

        //using SqlConnection connection = _dbConnection.CreateConnection();

        using SqlCommand command = connection.CreateCommand();

        command.CommandText = query;

        using SqlDataAdapter adapter = new SqlDataAdapter(command);

        adapter.Fill(table);

        return table;
    }
}