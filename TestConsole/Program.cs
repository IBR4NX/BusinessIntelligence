using Business.Metadata;
using Business.Query;
using Business.Services;
using Business.Validation;
using DataAccess;
using Domain.Definition;
using Domain.Settings;
using Infrastructure.Configuration;
using Infrastructure.Settings;
using System.Data;


try
{
    TestSql();
    //var store = new ConnectionSettingsStore(
    //AppPaths.ConnectionsFile);
    //ConnectionSettingsCollection s = store.Load();
    //store.Save(new ConnectionSettings { Server = "IBOVS", Database = "ddsd" });
    //foreach (ConnectionSettings c in s.Connections)
    //{
    //    Console.WriteLine("1" + c.Server);
    //}





}
catch (Exception ex)
{
    Console.WriteLine("Error:");
    Console.WriteLine(ex);
}

//Console.ReadKey();

void TestSql()
{
    try { 
    string connectionString = @"Server=IBOVSPC;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;";
    DbConnection dbConnection = new DbConnection(connectionString);
    DatabaseRepository dataBaseRepository = new DatabaseRepository(dbConnection);

    MetadataService metaDataService = new MetadataService(dataBaseRepository);
    metaDataService.Load();

    DataRepository dataRepository = new DataRepository(dbConnection);
    var validator = new QueryValidator(metaDataService.Metadata);
    var queryBuilder = new QueryBuilder();
    //validator.IsValidColumn("");

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
        TableName = "Orders",

        SelectedColumns =
    {
        "OrderID",
        "OrderDate",
        "Customers.CustomerName"
    },

        Filters =
    {
        new FilterDefinition
        {
            ColumnName = "OrderID",
            Operator = ComparisonOperator.GreaterThan,
            Value = 100,
            LogicalOperator = LogicalOperator.And
        }
    },

        Joins =
    {
        new JoinDefinition
        {
            TableName = "Customers",
            LeftColumn = "CustomerID",
            RightColumn = "CustomerID",
            JoinType = JoinType.Inner
        }
    },

        OrderBy = "OrderDate",
        Descending = true
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

}


void stringPrint()
{
    string text = "Hello World";
    Console.WriteLine(text.Length); // 11
    Console.WriteLine(text.ToUpper()); // HELLO WORLD
    Console.WriteLine(text.ToLower()); // hello world
    Console.WriteLine(text.Contains("Hello")); // True
    Console.WriteLine(text.StartsWith("Hello")); // True
    Console.WriteLine(text.EndsWith("World")); // True
    Console.WriteLine(text.IndexOf("World")); // 6
    Console.WriteLine(text.LastIndexOf("l")); // 9
    Console.WriteLine(text.Replace("Hello", "Hi")); // Hi World
    Console.WriteLine(text.Substring(0, 5)); // Hello
    Console.WriteLine(text.Substring(6, 5)); // World
    Console.WriteLine(text.Remove(5)); // Hello
    Console.WriteLine(text.Remove(0, 6)); // World
    string text2 = "   Hello World   ";
    Console.WriteLine(text2.Trim()); // Hello World
    Console.WriteLine(text2.TrimStart()); // Hello World   
    Console.WriteLine(text2.TrimEnd()); //    Hello World
    string[] result = "Ali,Ahmed,Ibrahim".Split(',');
    Console.WriteLine(result[0]); // Ali
    Console.WriteLine(result[1]); // Ahmed
    Console.WriteLine(result[2]); // Ibrahim
    string[] names = { "Ali", "Ahmed", "Ibrahim" };
    Console.WriteLine(string.Join("-", names)); // Ali-Ahmed-Ibrahim
    Console.WriteLine(string.Concat("Hello", " ", "World")); // Hello World
    Console.WriteLine(string.Equals("Hello", "Hello")); // True
    Console.WriteLine(string.Equals("Hello", "hello")); // False
    Console.WriteLine(string.Compare("Ali", "Ahmed")); // رقم موجب
    Console.WriteLine(string.IsNullOrEmpty("")); // True
    Console.WriteLine(new string('*', 5)); // *****
}