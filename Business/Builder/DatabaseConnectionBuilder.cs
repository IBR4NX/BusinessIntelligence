using System.Data.SqlClient;

namespace Business.Builder;

public static class DatabaseConnectionBuilder
{
    public static string sqlBuild(
        string server,
        string database,
        bool sqlAuthentication,
        string Username,
        string Password)
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = server,
            InitialCatalog = database,
            TrustServerCertificate = true,
            ConnectTimeout = 10
        };

        if (sqlAuthentication)
        {
            builder.IntegratedSecurity = false;
            builder.UserID = Username.Trim();
            builder.Password = Password;
        }
        else
        {
            builder.IntegratedSecurity = true;
        }

        return builder.ConnectionString;
    }
}