using System;
using System.Windows.Forms;
namespace PresentationLayer
{
    public partial class Login : Form
    {
        string connectionString = @"Server=IBOVSPC;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;";
        DbConnection dbConnection = new DbConnection(connectionString);
        DatabaseRepository dataBaseRepository = new DatabaseRepository(dbConnection);

        MetadataService metaDataService = new MetadataService(dataBaseRepository);
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

    }
}
