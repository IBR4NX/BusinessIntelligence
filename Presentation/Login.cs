using Business.Builder;
using DataAccess;
using Domain.Settings;
using Infrastructure.Configuration;
using Infrastructure.Settings;

using System.Data.SqlClient;
namespace Presentation;

public partial class Login : Form
{
    public string ConnectionString { get; private set; } = string.Empty;
    private ConnectionSettingsStore store = new ConnectionSettingsStore(AppPaths.ConnectionsFile);
    public SqlConnection sqlConnection;
    public DbConnection Connection;

    public Login()
    {
        InitializeComponent();
    }

    private void Login_Load(object? sender, EventArgs e)
    {
        ConnectionSettingsCollection settings = store.Load();

        foreach (ConnectionSettings connection in settings.Connections)
        {
            if (!string.IsNullOrWhiteSpace(connection.Server) &&
                !CmBxServer.Items.Contains(connection.Server))
            {
                CmBxServer.Items.Add(connection.Server);
            }
        }

        if (settings.Connections.Count > 0)
        {
            var last = settings.Connections[^1];

            CmBxServer.SelectedText = last.Server;
            CmBxDatabase.SelectedText = last.Database;

            CmbxAuthentication.SelectedIndex =
                last.Authentication == AuthenticationType.SqlServer ? 1 : 0;

            TxtUsername.Text = last.Username ?? string.Empty;
        }

        UpdateAuthenticationState();
        CmbxAuthentication.SelectedIndex = 0;
        CmBxServer.Focus();
    }

    private void CmbxAuthentication_SelectedIndexChanged(object? sender, EventArgs e)
    {
        UpdateAuthenticationState();

    }
    private void UpdateAuthenticationState()
    {
        bool sqlAuthentication = CmbxAuthentication.SelectedIndex == 1;

        TxtUsername.Enabled = sqlAuthentication;
        TxtPassword.Enabled = sqlAuthentication;
        LblUsername.Enabled = sqlAuthentication;
        LblPassword.Enabled = sqlAuthentication;

        if (!sqlAuthentication)
        {
            TxtUsername.Clear();
            TxtPassword.Clear();
        }
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        string server = CmBxServer.Text.Trim();
        string database = CmBxDatabase.Text.Trim();
        string Username = TxtUsername.Text.Trim();
        string Password = TxtPassword.Text.Trim();
        bool sqlAuthentication = CmbxAuthentication.SelectedIndex == 1;

        if (string.IsNullOrWhiteSpace(server))
        {
            Helper.Show("Please enter the SQL Server name.");
            CmBxServer.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(database))
        {
            Helper.Show("Please enter the database name.");
            CmBxDatabase.Focus();
            return;
        }

        if (sqlAuthentication && string.IsNullOrWhiteSpace(Username))
        {
            Helper.Show("Please enter the username.");
            TxtUsername.Focus();
            return;
        }

        if (sqlAuthentication && string.IsNullOrWhiteSpace(Password))
        {
            Helper.Show("Please enter the password.");
            TxtPassword.Focus();
            return;
        }

        try
        {
            string connectionString =
                DatabaseConnectionBuilder.sqlBuild(server, database, sqlAuthentication, Username, Password);

            BtnLogin.Enabled = false;
            BtnLogin.Text = "Connecting...";

            Connection = new DbConnection(connectionString);
            sqlConnection = Connection.CreateConnection();



            ConnectionString = connectionString;

            SaveConnection(server, database, sqlAuthentication);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (SqlException ex)
        {
            MessageBox.Show(
                $"Could not connect to the database.\\n\\n{ex.Message}",
                "Connection Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Login Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            if (!IsDisposed)
            {
                BtnLogin.Enabled = true;
                BtnLogin.Text = "Connect";
            }
        }
    }

    private void SaveConnection(
        string server,
        string database,
        bool sqlAuthentication)
    {

        store.Save(new ConnectionSettings
        {
            Server = server,
            Database = database,
            Authentication = sqlAuthentication
                ? AuthenticationType.SqlServer
                : AuthenticationType.Windows,
            Username = sqlAuthentication ? TxtUsername.Text.Trim() : null
        });
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {

    }
}