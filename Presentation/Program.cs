using Business.Metadata;
using Business.Query;
using Business.Services;
using Business.Validation;
using DataAccess;
namespace Presentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

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
            Application.Run(new Main(metaDataService, queryService));
        }
    }
}