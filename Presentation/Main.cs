using Business.Metadata;
using Business.Services;

namespace Presentation
{
    public partial class Main : Form
    {
        private readonly MetadataService _metadataService;
        private readonly QueryService _queryService;
        public Main(MetadataService metadataService,
            QueryService queryService)
        {
            InitializeComponent();
            _metadataService = metadataService;
            _queryService = queryService;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadTables();
        }
        private void LoadTables()
        {
            lstTables.Items.Clear();

            foreach (var table in _metadataService.Metadata.Tables)
            {
                lstTables.Items.Add(table);
            }
        }
        private void LoadColumns(string tableName)
        {
            clbColumn.Items.Clear();

            var columns =
                _metadataService.GetColumns(tableName);

            foreach (var column in columns)
            {
                clbColumn.Items.Add(column);
            }

            //clbColumn.DisplayRect;
        }


        private void lstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem is not string tableName)
                return;

            LoadColumns(tableName);
        }

    }
}
