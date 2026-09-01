using Domain;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess;

public class DatabaseRepository
{
    private readonly DbConnection _dbConnection;
    private readonly SqlConnection connection;

    public DatabaseRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        connection = dbConnection.CreateConnection();
    }

    public List<string> GetTables()
    {
        const string query = """
            SELECT TABLE_NAME
            FROM INFORMATION_SCHEMA.TABLES
            WHERE TABLE_TYPE = 'BASE TABLE'
            ORDER BY TABLE_NAME;
            """;
        var tables = new List<string>();


        using SqlCommand command = new(query, connection);

        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            tables.Add(reader.GetString(0));
        }
        connection.Close();
        return tables;
    }
    public List<ColumnInfo> GetColumns(string tableName)
    {
        var columns = new List<ColumnInfo>();

        //using SqlConnection connection = _dbConnection.CreateConnection();

        connection.Open();

        DataTable schema = connection.GetSchema(
            "Columns",
            new[] { null, null, tableName, null });

        var primaryKeys = GetPrimaryKeys(tableName);
        var foreignKeys = GetForeignKeys(tableName);

        foreach (DataRow row in schema.Rows)
        {
            string columnName = row["COLUMN_NAME"]?.ToString() ?? string.Empty;

            var foreignKey = foreignKeys.FirstOrDefault(
                fk => fk.ColumnName == columnName);

            columns.Add(new ColumnInfo
            {
                Name = columnName,

                DataType = row["DATA_TYPE"]?.ToString()
                           ?? string.Empty,

                IsNullable = row["IS_NULLABLE"]?.ToString() == "YES",

                OrdinalPosition = Convert.ToInt32(
                    row["ORDINAL_POSITION"]),

                MaxLength = row["CHARACTER_MAXIMUM_LENGTH"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(
                        row["CHARACTER_MAXIMUM_LENGTH"]),

                NumericPrecision = row["NUMERIC_PRECISION"] == DBNull.Value
                    ? null
                    : Convert.ToByte(
                        row["NUMERIC_PRECISION"]),

                NumericScale = row["NUMERIC_SCALE"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(
                        row["NUMERIC_SCALE"]),

                IsPrimaryKey = primaryKeys.Contains(columnName),

                IsForeignKey = foreignKey != null,

                ReferencedTable = foreignKey?.ReferencedTable,

                ReferencedColumn = foreignKey?.ReferencedColumn
            });
        }
        connection.Close();

        return columns;
    }

    public List<string> GetPrimaryKeys(string tableName)
    {
        const string query = """
        SELECT c.name
        FROM sys.indexes i
        INNER JOIN sys.index_columns ic
            ON i.object_id = ic.object_id
            AND i.index_id = ic.index_id
        INNER JOIN sys.columns c
            ON ic.object_id = c.object_id
            AND ic.column_id = c.column_id
        WHERE i.is_primary_key = 1
          AND i.object_id = OBJECT_ID(@TableName)
        ORDER BY ic.key_ordinal;
        """;

        var primaryKeys = new List<string>();

        //using var connection = _dbConnection.CreateConnection();

        //connection.Open();

        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@TableName", tableName);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            primaryKeys.Add(reader.GetString(0));
        }

        return primaryKeys;
    }
    public List<ForeignKeyInfo> GetForeignKeys(string tableName)
    {
        const string query = """
        SELECT
            fk.name AS ForeignKeyName,
            c.name AS ColumnName,
            rt.name AS ReferencedTable,
            rc.name AS ReferencedColumn
        FROM sys.foreign_keys fk
        INNER JOIN sys.foreign_key_columns fkc
            ON fk.object_id = fkc.constraint_object_id
        INNER JOIN sys.tables t
            ON fk.parent_object_id = t.object_id
        INNER JOIN sys.columns c
            ON fkc.parent_object_id = c.object_id
            AND fkc.parent_column_id = c.column_id
        INNER JOIN sys.tables rt
            ON fkc.referenced_object_id = rt.object_id
        INNER JOIN sys.columns rc
            ON fkc.referenced_object_id = rc.object_id
            AND fkc.referenced_column_id = rc.column_id
        WHERE t.name = @TableName
        ORDER BY fk.name, fkc.constraint_column_id;
        """;

        var foreignKeys = new List<ForeignKeyInfo>();

        //using var connection = _dbConnection.CreateConnection();

        //connection.Open();

        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@TableName", tableName);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            foreignKeys.Add(new ForeignKeyInfo
            {
                Name = reader["ForeignKeyName"].ToString()!,
                ColumnName = reader["ColumnName"].ToString()!,
                ReferencedTable = reader["ReferencedTable"].ToString()!,
                ReferencedColumn = reader["ReferencedColumn"].ToString()!
            });
        }

        return foreignKeys;
    }

}