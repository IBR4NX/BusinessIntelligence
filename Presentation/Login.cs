using Domain.Settings;
using Infrastructure.Configuration;
using Infrastructure.Settings;

namespace Presentation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ConnectionSettingsStore store = new ConnectionSettingsStore(AppPaths.ConnectionsFile);
            ConnectionSettingsCollection s = store.Load();
            foreach (ConnectionSettings c in s.Connections)
            {
                CmBxServer.Items.Add(c.Server);
                CmbxDatabase.Items.Add(c.Database);
                if (string.Equals(s.Connections[s.Connections.Count - 1], c))
                {

                    CmBxServer.Text = c.Server;
                    CmbxDatabase.Text = c.Database;
                }

            }

        }
    }
}
