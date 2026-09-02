using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DataAccess;

public class DataRepository
{
    private readonly SqlConnection connection;
    private readonly DbConnection _dbConnection;

    public DataRepository(DbConnection dbConnection)
    {
        connection = dbConnection.connection;
        _dbConnection = dbConnection;
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
    public DataTable ExecuteQuery(
        string query,
        IReadOnlyDictionary<string, object?>? parameters = null)
    {

        //using SqlConnection connection = _dbConnection.CreateConnection();

        //using SqlCommand command = connection.CreateCommand();

        //command.CommandText = query;

        //if (parameters is not null)
        //{
        //    foreach (var parameter in parameters)
        //        command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
        //}

        SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
        Debug.WriteLine(query);
        var table = new DataTable();
        adapter.Fill(table);
        Debug.WriteLine("--------------------------------------------------");
        return table;
    }
}
