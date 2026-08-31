from pathlib import Path
import zipfile, shutil

src_zip = Path("/data/BusinessIntelligence-master.zip")
work = Path("/mnt/data/bi_login_update")
shutil.rmtree(work, ignore_errors=True)
work.mkdir(parents=True)

with zipfile.ZipFile(src_zip) as z:
    z.extractall(work)

root = work / "BusinessIntelligence-master"

(root/"Domain/Settings/AuthenticationType.cs").write_text("""namespace Domain.Settings;

public enum AuthenticationType
{
    Windows,
    SqlServer
}
""", encoding="utf-8")

(root/"Domain/Settings/ConnectionSettings.cs").write_text("""namespace Domain.Settings;

public class ConnectionSettings
{
    public string Server { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public AuthenticationType Authentication { get; set; } = AuthenticationType.Windows;
    public string? Username { get; set; }
}
""", encoding="utf-8")

(root/"Presentation/Login.cs").write_text("""using Domain.Settings;
using Infrastructure.Configuration;
using Infrastructure.Settings;
using System.Data.SqlClient;

namespace Presentation;

public partial class Login : Form
{
    public string ConnectionString { get; private set; } = string.Empty;

    public Login()
    {
        InitializeComponent();
        ConfigureAuthenticationControls();

        BtnLogin.Click += BtnLogin_Click;
        CmbxAuthentication.SelectedIndexChanged += CmbxAuthentication_SelectedIndexChanged;
    }

    private void Login_Load(object? sender, EventArgs e)
    {
        var store = new ConnectionSettingsStore(AppPaths.ConnectionsFile);
        var settings = store.Load();

        foreach (var connection in settings.Connections)
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

            CmBxServer.Text = last.Server;
            CmBxDatabase.Text = last.Database;

            CmbxAuthentication.SelectedIndex =
                last.Authentication == AuthenticationType.SqlServer ? 1 : 0;

            TxtUsername.Text = last.Username ?? string.Empty;
        }

        UpdateAuthenticationState();
        CmBxServer.Focus();
    }

    private void ConfigureAuthenticationControls()
    {
        CmbxAuthentication.Items.Clear();
        CmbxAuthentication.Items.Add("Windows Authentication");
        CmbxAuthentication.Items.Add("SQL Server Authentication");
        CmbxAuthentication.SelectedIndex = 0;

        TxtPassword.UseSystemPasswordChar = true;
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
        bool sqlAuthentication = CmbxAuthentication.SelectedIndex == 1;

        if (string.IsNullOrWhiteSpace(server))
        {
            ShowValidation("Please enter the SQL Server name.");
            CmBxServer.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(database))
        {
            ShowValidation("Please enter the database name.");
            CmBxDatabase.Focus();
            return;
        }

        if (sqlAuthentication && string.IsNullOrWhiteSpace(TxtUsername.Text))
        {
            ShowValidation("Please enter the username.");
            TxtUsername.Focus();
            return;
        }

        if (sqlAuthentication && string.IsNullOrWhiteSpace(TxtPassword.Text))
        {
            ShowValidation("Please enter the password.");
            TxtPassword.Focus();
            return;
        }

        try
        {
            string connectionString =
                BuildConnectionString(server, database, sqlAuthentication);

            BtnLogin.Enabled = false;
            BtnLogin.Text = "Connecting...";

            using var connection = new SqlConnection(connectionString);
            connection.Open();

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

    private string BuildConnectionString(
        string server,
        string database,
        bool sqlAuthentication)
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
            builder.UserID = TxtUsername.Text.Trim();
            builder.Password = TxtPassword.Text;
        }
        else
        {
            builder.IntegratedSecurity = true;
        }

        return builder.ConnectionString;
    }

    private void SaveConnection(
        string server,
        string database,
        bool sqlAuthentication)
    {
        var store = new ConnectionSettingsStore(AppPaths.ConnectionsFile);

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

    private static void ShowValidation(string message)
    {
        MessageBox.Show(
            message,
            "Login",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
    }
}
""", encoding="utf-8")

(root/"Presentation/Login.Designer.cs").write_text("""
namespace Presentation;

partial class Login
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        kryptonPictureBox1 = new Krypton.Toolkit.KryptonPictureBox();
        LblTitle = new Krypton.Toolkit.KryptonLabel();
        LblHint = new Krypton.Toolkit.KryptonLabel();
        LblServer = new Krypton.Toolkit.KryptonLabel();
        LblDatabase = new Krypton.Toolkit.KryptonLabel();
        LblAuthentication = new Krypton.Toolkit.KryptonLabel();
        LblUsername = new Krypton.Toolkit.KryptonLabel();
        LblPassword = new Krypton.Toolkit.KryptonLabel();

        CmBxServer = new Krypton.Toolkit.KryptonComboBox();
        CmBxDatabase = new Krypton.Toolkit.KryptonComboBox();
        CmbxAuthentication = new Krypton.Toolkit.KryptonComboBox();

        TxtUsername = new Krypton.Toolkit.KryptonTextBox();
        TxtPassword = new Krypton.Toolkit.KryptonTextBox();

        BtnLogin = new Krypton.Toolkit.KryptonButton();
        BtnCancel = new Krypton.Toolkit.KryptonButton();

        ((System.ComponentModel.ISupportInitialize)kryptonPictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)CmBxServer).BeginInit();
        ((System.ComponentModel.ISupportInitialize)CmBxDatabase).BeginInit();
        ((System.ComponentModel.ISupportInitialize)CmbxAuthentication).BeginInit();
        SuspendLayout();

        kryptonPictureBox1.Image = Properties.Resources.l;
        kryptonPictureBox1.Location = new Point(38, 16);
        kryptonPictureBox1.Name = "kryptonPictureBox1";
        kryptonPictureBox1.Size = new Size(306, 82);
        kryptonPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        kryptonPictureBox1.TabIndex = 0;
        kryptonPictureBox1.TabStop = false;

        LblTitle.Location = new Point(35, 104);
        LblTitle.Name = "LblTitle";
        LblTitle.Size = new Size(312, 30);
        LblTitle.StateCommon.ShortText.Font = new Font("Segoe UI Semibold", 16F);
        LblTitle.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
        LblTitle.Values.Text = "Database Login";

        LblHint.Location = new Point(35, 136);
        LblHint.Name = "LblHint";
        LblHint.Size = new Size(312, 22);
        LblHint.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
        LblHint.Values.Text = "Connect to your SQL Server database";

        LblServer.Location = new Point(35, 174);
        LblServer.Name = "LblServer";
        LblServer.Size = new Size(90, 22);
        LblServer.Values.Text = "Server";

        CmBxServer.DropDownWidth = 310;
        CmBxServer.IntegralHeight = false;
        CmBxServer.Location = new Point(35, 198);
        CmBxServer.Name = "CmBxServer";
        CmBxServer.Size = new Size(312, 29);
        CmBxServer.TabIndex = 1;

        LblDatabase.Location = new Point(35, 237);
        LblDatabase.Name = "LblDatabase";
        LblDatabase.Size = new Size(90, 22);
        LblDatabase.Values.Text = "Database";

        CmBxDatabase.DropDownWidth = 310;
        CmBxDatabase.IntegralHeight = false;
        CmBxDatabase.Location = new Point(35, 261);
        CmBxDatabase.Name = "CmBxDatabase";
        CmBxDatabase.Size = new Size(312, 29);
        CmBxDatabase.TabIndex = 2;

        LblAuthentication.Location = new Point(35, 300);
        LblAuthentication.Name = "LblAuthentication";
        LblAuthentication.Size = new Size(120, 22);
        LblAuthentication.Values.Text = "Authentication";

        CmbxAuthentication.DropDownStyle =
            Krypton.Toolkit.ComboBoxStyle.DropDownList;
        CmbxAuthentication.DropDownWidth = 310;
        CmbxAuthentication.IntegralHeight = false;
        CmbxAuthentication.Location = new Point(35, 324);
        CmbxAuthentication.Name = "CmbxAuthentication";
        CmbxAuthentication.Size = new Size(312, 29);
        CmbxAuthentication.TabIndex = 3;

        LblUsername.Location = new Point(35, 363);
        LblUsername.Name = "LblUsername";
        LblUsername.Size = new Size(90, 22);
        LblUsername.Values.Text = "Username";

        TxtUsername.Location = new Point(35, 387);
        TxtUsername.Name = "TxtUsername";
        TxtUsername.Size = new Size(312, 28);
        TxtUsername.TabIndex = 4;

        LblPassword.Location = new Point(35, 426);
        LblPassword.Name = "LblPassword";
        LblPassword.Size = new Size(90, 22);
        LblPassword.Values.Text = "Password";

        TxtPassword.Location = new Point(35, 450);
        TxtPassword.Name = "TxtPassword";
        TxtPassword.Size = new Size(312, 28);
        TxtPassword.TabIndex = 5;

        BtnLogin.Location = new Point(35, 495);
        BtnLogin.Name = "BtnLogin";
        BtnLogin.Size = new Size(150, 36);
        BtnLogin.TabIndex = 6;
        BtnLogin.Values.Text = "Connect";

        BtnCancel.DialogResult = DialogResult.Cancel;
        BtnCancel.Location = new Point(197, 495);
        BtnCancel.Name = "BtnCancel";
        BtnCancel.Size = new Size(150, 36);
        BtnCancel.TabIndex = 7;
        BtnCancel.Values.Text = "Cancel";

        AcceptButton = BtnLogin;
        CancelButton = BtnCancel;
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(382, 553);
        Controls.Add(BtnCancel);
        Controls.Add(BtnLogin);
        Controls.Add(TxtPassword);
        Controls.Add(LblPassword);
        Controls.Add(TxtUsername);
        Controls.Add(LblUsername);
        Controls.Add(CmbxAuthentication);
        Controls.Add(LblAuthentication);
        Controls.Add(CmBxDatabase);
        Controls.Add(LblDatabase);
        Controls.Add(CmBxServer);
        Controls.Add(LblServer);
        Controls.Add(LblHint);
        Controls.Add(LblTitle);
        Controls.Add(kryptonPictureBox1);

        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Login";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Business Intelligence - Login";

        ((System.ComponentModel.ISupportInitialize)kryptonPictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)CmBxServer).EndInit();
        ((System.ComponentModel.ISupportInitialize)CmBxDatabase).EndInit();
        ((System.ComponentModel.ISupportInitialize)CmbxAuthentication).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Krypton.Toolkit.KryptonPictureBox kryptonPictureBox1;
    private Krypton.Toolkit.KryptonLabel LblTitle;
    private Krypton.Toolkit.KryptonLabel LblHint;
    private Krypton.Toolkit.KryptonLabel LblServer;
    private Krypton.Toolkit.KryptonLabel LblDatabase;
    private Krypton.Toolkit.KryptonLabel LblAuthentication;
    private Krypton.Toolkit.KryptonLabel LblUsername;
    private Krypton.Toolkit.KryptonLabel LblPassword;

    private Krypton.Toolkit.KryptonComboBox CmBxServer;
    private Krypton.Toolkit.KryptonComboBox CmBxDatabase;
    private Krypton.Toolkit.KryptonComboBox CmbxAuthentication;

    private Krypton.Toolkit.KryptonTextBox TxtUsername;
    private Krypton.Toolkit.KryptonTextBox TxtPassword;

    private Krypton.Toolkit.KryptonButton BtnLogin;
    private Krypton.Toolkit.KryptonButton BtnCancel;
}
""", encoding="utf-8")

(root/"Presentation/Program.cs").write_text("""using Business.Metadata;
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
""", encoding="utf-8")

# Prevent the old Main from creating an unused Login form.
main_cs = root/"Presentation/Main.cs"
text = main_cs.read_text(encoding="utf-8-sig")
text = text.replace(
"""        private void Main_Load(object sender, EventArgs e)
        {
            Form fl = new Login();
            //fl.ShowDialog();
            LoadTables();
        }""",
"""        private void Main_Load(object sender, EventArgs e)
        {
            LoadTables();
        }"""
)
main_cs.write_text(text, encoding="utf-8")

out = Path("/mnt/data/BusinessIntelligence-with-login.zip")
if out.exists():
    out.unlink()

with zipfile.ZipFile(out, "w", zipfile.ZIP_DEFLATED) as zout:
    for p in root.rglob("*"):
        if p.is_file():
            zout.write(p, arcname=str(Path("BusinessIntelligence-master") / p.relative_to(root)))

print(out)
