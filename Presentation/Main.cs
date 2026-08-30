using Business.Metadata;
using Business.Services;
using Domain.Definition;

namespace Presentation
{
    public partial class Main : Form
    {
        private readonly MetadataService _metadataService;
        private readonly QueryService _queryService;
        private readonly bool _ProgressSave;
        public Main(MetadataService metadataService,
            QueryService queryService)
        {
            InitializeComponent();
            _metadataService = metadataService;
            _queryService = queryService;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Form fl = new Login();
            //fl.ShowDialog();
            LoadTables();
        }
        private void LoadTables()
        {
            lstTables.Items.Clear();

            foreach (var table in _metadataService.Metadata.Tables)
            {
                lstTables.Items.Add(table);
            }
            StatusLabelCountTables.Text = lstTables.Items.Count.ToString();
        }
        private void LoadColumns(string tableName)
        {
            clbColumns.Items.Clear();

            var columns = _metadataService.GetColumns(tableName);

            foreach (var column in columns)
            {
                string text = string.IsNullOrWhiteSpace(column.ReferencedColumn)
                    ? column.Name
                    : $"{column.Name} - {column.ReferencedColumn}";

                clbColumns.Items.Add(text);
            }
        }


        private void LstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem is not string tableName)
                return;
            lblColumns.Text = tableName;


            LoadColumns(tableName);
            pnlContent.Focus();
        }

        private void clbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblColumns.Text = clbColumns.CheckedItems.Count.ToString();




        }

        private void clbColumns_MouseLeave(object sender, EventArgs e)
        {
            CbColumns.DataSource = null;
            CbColumns.DataSource = clbColumns.CheckedItems;
            CbColumns.Text = "Choose Filter";
            //foreach (var item in clbColumns.CheckedItems)
            //{
            //    CbColumns.Items.Add(item);
            //}
        }

        private void BtnStart_Click(
    object sender,
    EventArgs e)
        {
            if (lstTables.SelectedItem is not string tableName)
            {
                MessageBox.Show("Choose a table.");
                return;
            }

            var selectedColumns = clbColumns.CheckedItems
            .Cast<string>()
            .Select(x => x.Split(" - ")[0])
            .ToList();

            //if (selectedColumns.Count == 0)
            //{
            //    MessageBox.Show("Choose at least one column.");
            //    return;
            //}

            var query = new QueryDefinition
            {
                TableName = tableName,
                SelectedColumns = selectedColumns
            };

            try
            {
                var result = _queryService.Execute(query);

                DgvData.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
