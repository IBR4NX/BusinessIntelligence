using Business.Metadata;
using Business.Query;
using Business.Services;
using Business.Validation;
using DataAccess;
using Domain.Definition;
using System.Data;




try
{
    string connectionString = @"Server=IBOVSPC;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;";
    DbConnection dbConnection = new DbConnection(connectionString);
    DatabaseRepository dataBaseRepository = new DatabaseRepository(dbConnection);

    MetadataService metaDataService = new MetadataService(dataBaseRepository);
    metaDataService.Load();

    DataRepository dataRepository = new DataRepository(dbConnection);
    var validator = new QueryValidator(metaDataService.Metadata);
    var queryBuilder = new QueryBuilder();

    var queryService = new QueryService(
        dataRepository,
        queryBuilder,
        validator);
    metaDataService.PrintMetadata();
    //List<string> tables = dataBaseRepository.GetTables();

    ////Console.WriteLine("Tables:");

    //foreach (string table in tables)
    //{
    //    Console.WriteLine($" - {table}");
    //}
    var columns = dataBaseRepository.GetColumns("Products");

    Console.WriteLine("\n---------------------");
    Console.WriteLine("Columns in Employees:");

    //foreach (var column in columns)
    //{
    //    Console.WriteLine($"{column.Name} | {column.DataType} | Nullable: {column.IsNullable} | {column.IsForeignKey} | {column.IsPrimaryKey} | {column.ReferencedTable} | {column.ReferencedColumn}");
    //    //Console.WriteLine(column);
    //}

    var query = new QueryDefinition
    {
        TableName = "Products",

        SelectedColumns = new List<string>
    {
        "ProductID",
        "ProductName",
        "UnitPrice",
        "UnitsInStock"
    },

        Filters = new List<FilterDefinition>
    {
        new()
        {
            ColumnName = "UnitPrice",
            Operator = ComparisonOperator.GreaterThan,
            Value = 2,
            LogicalOperator = LogicalOperator.And
        },

        new()
        {
            ColumnName = "UnitsInStock",
            Operator = ComparisonOperator.Between,
            Values = {2,10 },
            LogicalOperator = LogicalOperator.And
        }
    }
    };
    var result = queryService.Execute(query);
    foreach (DataRow row in result.Rows)
    {
        foreach (DataColumn column in result.Columns)
        {
            Console.Write($"{column.ColumnName}: {row[column]} | ");
        }

        Console.WriteLine();
    }


}
catch (Exception ex)
{
    Console.WriteLine("Error:");
    Console.WriteLine(ex);
}

//Console.ReadKey();