using DataAccess;
using Domain;

namespace Business.Metadata;

public class MetadataService
{
    private readonly DatabaseRepository _databaseRepository;

    public DatabaseMetadata Metadata { get; private set; } = new();

    public MetadataService(DatabaseRepository databaseRepository)
    {
        _databaseRepository = databaseRepository;
    }

    public void Load()
    {
        var tables = _databaseRepository.GetTables();

        Metadata.Tables = tables;

        foreach (string table in tables)
        {
            Metadata.Columns[table] =
                _databaseRepository.GetColumns(table);
        }
    }
    public List<ColumnInfo> GetColumns(string tableName)
    {
        if (!Metadata.Columns.TryGetValue(tableName, out var columns))
            return new List<ColumnInfo>();

        return columns;
    }

    public List<ColumnInfo> GetForeignKeyColumns(string tableName)
    {
        return GetColumns(tableName)
            .Where(c => c.IsForeignKey)
            .ToList();
    }

    public void PrintMetadata()
    {
        Console.WriteLine("========== DATABASE METADATA ==========");

        Console.WriteLine("\nTABLES:");
        Console.WriteLine("----------------------------------------");

        foreach (var table in Metadata.Tables)
        {
            Console.WriteLine($"\nTABLE: {table}");

            if (!Metadata.Columns.TryGetValue(table, out var columns))
            {
                Console.WriteLine("  No columns found.");
                continue;
            }

            Console.WriteLine("  COLUMNS:");

            foreach (var column in columns.OrderBy(c => c.OrdinalPosition))
            {
                Console.WriteLine(
                    $"    Name           : {column.Name}\n" +
                    $"    DataType       : {column.DataType}\n" +
                    $"    Nullable       : {column.IsNullable}\n" +
                    $"    Ordinal        : {column.OrdinalPosition}\n" +
                    $"    MaxLength      : {column.MaxLength}\n" +
                    $"    Precision      : {column.NumericPrecision}\n" +
                    $"    Scale          : {column.NumericScale}\n" +
                    $"    DefaultValue   : {column.DefaultValue}\n" +
                    $"    PrimaryKey     : {column.IsPrimaryKey}\n" +
                    $"    ForeignKey     : {column.IsForeignKey}\n" +
                    $"    ReferencedTable: {column.ReferencedTable}\n" +
                    $"    ReferencedCol  : {column.ReferencedColumn}"
                );

                Console.WriteLine("    -------------------------------");
            }
        }

        Console.WriteLine("\n========== END METADATA ==========");
    }
}