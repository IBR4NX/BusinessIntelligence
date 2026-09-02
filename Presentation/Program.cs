using Business.Metadata;
using Business.Query;
using Business.Services;
using Business.Validation;
using DataAccess;
using System.Diagnostics;

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



        var databaseRepository = new DatabaseRepository(login.Connection);
        var metadataService = new MetadataService(databaseRepository);
        Debug.WriteLine("begin load");

            metadataService.Load();

            var dataRepository = new DataRepository(login.Connection);
            var validator = new QueryValidator(metadataService.Metadata);
        Debug.WriteLine("begin try");
        try
        {
            var queryBuilder = new QueryBuilder();

            var queryService = new QueryService(
                dataRepository,
                queryBuilder,
                validator);
            Debug.WriteLine("Begin Main app");
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
