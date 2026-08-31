using Business.Metadata;
using Business.Query;
using Business.Services;
using Business.Validation;
using DataAccess;

namespace Presentation;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        using var login = new Login();

        if (login.ShowDialog() != DialogResult.OK)
            return;

        var dbConnection = new DbConnection(login.ConnectionString);

        var databaseRepository = new DatabaseRepository(dbConnection);
        var metadataService = new MetadataService(databaseRepository);

        try
        {
            metadataService.Load();

            var dataRepository = new DataRepository(dbConnection);
            var validator = new QueryValidator(metadataService.Metadata);
            var queryBuilder = new QueryBuilder();

            var queryService = new QueryService(
                dataRepository,
                queryBuilder,
                validator);

            Application.Run(new Main(metadataService, queryService));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Unable to load the database metadata.\\n\\n{ex.Message}",
                "Startup Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
