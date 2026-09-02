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
        SELECT TABLE_SCHEMA, TABLE_NAME
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_TYPE = 'BASE TABLE'
        ORDER BY TABLE_SCHEMA, TABLE_NAME;
        """;

        var tables = new List<string>();

        using SqlCommand command = new(query, connection);

        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            string schema = reader.GetString(0);
            string table = reader.GetString(1);

            tables.Add($"{schema}.{table}");
        }

        connection.Close();

        return tables;
    }

    public List<ColumnInfo> GetColumns(string fullTableName)
    {
        var (schemaName, tableName) =
            SplitTableName(fullTableName);

        var columns = new List<ColumnInfo>();

        connection.Open();

        DataTable schema = connection.GetSchema(
            "Columns",
            new[] { null, null, tableName, null });

        var primaryKeys =
            GetPrimaryKeys(schemaName, tableName);

        var foreignKeys =
            GetForeignKeys(schemaName, tableName);

        foreach (DataRow row in schema.Rows)
        {
            string columnName =
                row["COLUMN_NAME"]?.ToString()
                ?? string.Empty;

            var foreignKey = foreignKeys.FirstOrDefault(
                fk => fk.ColumnName == columnName);

            columns.Add(new ColumnInfo
            {
                Name = columnName,

                DataType =
                    row["DATA_TYPE"]?.ToString()
                    ?? string.Empty,

                IsNullable =
                    row["IS_NULLABLE"]?.ToString() == "YES",

                OrdinalPosition =
                    Convert.ToInt32(row["ORDINAL_POSITION"]),

                MaxLength =
                    row["CHARACTER_MAXIMUM_LENGTH"] == DBNull.Value
                        ? null
                        : Convert.ToInt32(
                            row["CHARACTER_MAXIMUM_LENGTH"]),

                NumericPrecision =
                    row["NUMERIC_PRECISION"] == DBNull.Value
                        ? null
                        : Convert.ToByte(
                            row["NUMERIC_PRECISION"]),

                NumericScale =
                    row["NUMERIC_SCALE"] == DBNull.Value
                        ? null
                        : Convert.ToInt32(
                            row["NUMERIC_SCALE"]),

                IsPrimaryKey =
                    primaryKeys.Contains(columnName),

                IsForeignKey =
                    foreignKey != null,

                ReferencedTable =
                    foreignKey?.ReferencedTable,

                ReferencedColumn =
                    foreignKey?.ReferencedColumn
            });
        }

        connection.Close();

        return columns;
    }

    private HashSet<string> GetPrimaryKeys(
    string schemaName,
    string tableName)
    {
        const string sql = """
        SELECT c.name
        FROM sys.indexes i
        INNER JOIN sys.index_columns ic
            ON i.object_id = ic.object_id
            AND i.index_id = ic.index_id
        INNER JOIN sys.columns c
            ON ic.object_id = c.object_id
            AND ic.column_id = c.column_id
        INNER JOIN sys.tables t
            ON i.object_id = t.object_id
        INNER JOIN sys.schemas s
            ON t.schema_id = s.schema_id
        WHERE i.is_primary_key = 1
          AND s.name = @SchemaName
          AND t.name = @TableName
        ORDER BY ic.key_ordinal;
        """;

        var primaryKeys = new HashSet<string>(
            StringComparer.OrdinalIgnoreCase);

        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@SchemaName", schemaName);
        command.Parameters.AddWithValue("@TableName", tableName);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            primaryKeys.Add(reader.GetString(0));
        }

        return primaryKeys;
    }

    private List<ForeignKeyInfo> GetForeignKeys(
        string schemaName,
        string tableName)
    {
        const string sql = """
        SELECT
            c.name AS ColumnName,
            rs.name AS ReferencedSchema,
            rt.name AS ReferencedTable,
            rc.name AS ReferencedColumn
        FROM sys.foreign_key_columns fkc

        INNER JOIN sys.tables t
            ON fkc.parent_object_id = t.object_id

        INNER JOIN sys.schemas s
            ON t.schema_id = s.schema_id

        INNER JOIN sys.columns c
            ON fkc.parent_object_id = c.object_id
            AND fkc.parent_column_id = c.column_id

        INNER JOIN sys.tables rt
            ON fkc.referenced_object_id = rt.object_id

        INNER JOIN sys.schemas rs
            ON rt.schema_id = rs.schema_id

        INNER JOIN sys.columns rc
            ON fkc.referenced_object_id = rc.object_id
            AND fkc.referenced_column_id = rc.column_id

        WHERE s.name = @SchemaName
          AND t.name = @TableName

        ORDER BY fkc.constraint_column_id;
        """;

        var foreignKeys = new List<ForeignKeyInfo>();

        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@SchemaName", schemaName);
        command.Parameters.AddWithValue("@TableName", tableName);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            foreignKeys.Add(new ForeignKeyInfo
            {
                ColumnName = reader.GetString(0),
                ReferencedTable = reader.GetString(2),
                ReferencedColumn = reader.GetString(3)
            });
        }

        return foreignKeys;
    }

    private static (string Schema, string Table) SplitTableName(string fullTableName)
    {
        string[] parts = fullTableName.Split('.', 2);

        if (parts.Length == 1)
            return ("dbo", parts[0]);

        return (parts[0], parts[1]);
    }

}