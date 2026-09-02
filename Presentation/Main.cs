using Business.Metadata;
using Business.Services;
using Domain.Definition;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Text.Json;

namespace Presentation
{
    public partial class Main : Form
    {
        private readonly MetadataService _metadataService;
        private readonly QueryService _queryService;
        private readonly List<FilterDefinition> _filters = new();
        private int _targetSplitterDistance = 300;
        private bool isDgvHidden = false;
        private int dgvOpenDistance;
        private readonly bool _isConnected;
        private readonly List<JoinDefinition> _joins = new();

        public Main(MetadataService metadataService, QueryService queryService)
        {
            InitializeComponent();
            _metadataService = metadataService;
            _queryService = queryService;
            Debug.WriteLine("Main");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dgvOpenDistance = splitContainer1.SplitterDistance;
            ConfigureControls();
            LoadTables();
            Debug.WriteLine("Main load");
        }
        private void LoadTables()
        {
            LstTables.Items.Clear();

            foreach (var table in _metadataService.Metadata.Tables
                         .Where(table => table.Contains(textBox1.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                LstTables.Items.Add(table);
            }
            StatusLabelCountTables.Text = LstTables.Items.Count.ToString();
            LstTables.SelectedItem = 0;

        }
        private void LoadColumns(string tableName)
        {
            ClearFiltersList();
            ClbColumns.Items.Clear();
            CbColumnsFilter.Items.Clear();
            CbColumnsFilter.SelectedIndex = -1;

            var columns = _metadataService.GetColumns(tableName);

            foreach (var column in columns)
            {
                string text = string.IsNullOrWhiteSpace(column.ReferencedColumn)
                    ? column.Name
                    : $"{column.Name} - {column.ReferencedColumn}";

                ClbColumns.Items.Add(text);
                CbColumnsFilter.Items.Add(column.Name);
                txtFilterValue.AutoCompleteCustomSource.Add(column.Name);
            }
            UpdateSelectedColumnsStatus();
        }
        private void LoadJoinTables(string tableName)
        {
            cmbJoinTable.Items.Clear();

            var columns = _metadataService.GetColumns(tableName);

            foreach (var column in columns)
            {
                if (string.IsNullOrWhiteSpace(column.ReferencedTable))
                    continue;

                if (!cmbJoinTable.Items.Contains(column.ReferencedTable))
                    cmbJoinTable.Items.Add(column.ReferencedTable);
            }
        }


        private void LstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstTables.SelectedItem is not string tableName)
                return;

            lblColumns.Text = tableName;

            LoadColumns(tableName);
            LoadJoinTables(tableName);

            BtnStart.Focus();
        }

        private void ClbColumns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(UpdateSelectedColumnsStatus);
        }


        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (LstTables.SelectedItem is not string tableName)
            {
                Helper.Show("Choose a table.");
                return;
            }
            try
            {

                var selectedColumns = ClbColumns.CheckedItems
                .Cast<string>()
                .Select(x => x.Split(" - ")[0])
                .ToList();

                var query = new QueryDefinition
                {
                    TableName = tableName,
                    SelectedColumns = selectedColumns,
                    Filters = _filters.ToList(),
                    Joins = _joins.ToList()
                };


                var result = _queryService.Execute(query);


                DgvData.DataSource = result;
                Opensplit();

            }
            catch (Exception ex)
            {
                //Debug.WriteLine(JsonSerializer.Serialize(ex, new JsonSerializerOptions { WriteIndented = true }));
                MessageBox.Show(ex.Message);
            }
        }


        private FilterDefinition BuildFilter()
        {
            var filter = new FilterDefinition
            {
                ColumnName = CbColumnsFilter.Text,
                Operator = (ComparisonOperator)cmbFilterOperator.SelectedItem!,
                ValueType = (FilterValueType)cmbValueType.SelectedItem!,
                LogicalOperator = (LogicalOperator)CmbLogical.SelectedItem!
            };
            string valueText = txtFilterValue.Text.Trim();
            if (filter.Operator is ComparisonOperator.Between or ComparisonOperator.In)
            {
                filter.Values = valueText.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Cast<object>()
                    .ToList();
            }
            else
            {
                filter.Values.Add(filter.Operator == ComparisonOperator.Like ? $"'%'{valueText}'%'" : valueText);
            }

            return filter;
        }


        private void ConfigureControls()
        {
            textBox1.TextChanged += (_, _) => LoadTables();
            CmbLogical.DataSource = Enum.GetValues<LogicalOperator>();
            cmbValueType.DataSource = Enum.GetValues<FilterValueType>();
            CmbLogical.SelectedItem = 0;
            cmbFilterOperator.DataSource = Enum.GetValues<ComparisonOperator>();
            cmbFilterOperator.SelectedItem = nameof(ComparisonOperator.Equal);
        }

        private void BtnAddFilter_Click(object? sender, EventArgs e)
        {
            FilterDefinition filter = BuildFilter();
            _filters.Add(filter);
            lstFilters.Items.Add($"{filter.ColumnName} {filter.Operator} {filter.Values.ToString()}".Trim());
        }

        private void ClearFiltersList()
        {
            lstFilters.Items.Clear();
            _filters.Clear();
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            ClearFiltersList();
        }



        private void ClbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnStart.Focus();
        }


        private void UpdateSelectedColumnsStatus()
        {
            var selectedColumns = ClbColumns.CheckedItems
                .Cast<object>()
                .ToArray();

            StatusLabelCountColumnsSelected.Text = selectedColumns.Length.ToString();

        }

        private void toolStripSplitBtnHidden_ButtonClick(object sender, EventArgs e)
        {
            if (splitContainer1.SplitterDistance < dgvOpenDistance - 20)
            {
                Opensplit();
            }
            else
            {
                Closesplit();
            }
        }
        public void Opensplit()
        {
            splitContainer1.SplitterDistance = _targetSplitterDistance;
        }
        public void Closesplit()
        {
            splitContainer1.SplitterDistance = dgvOpenDistance;
        }

        private void extrnaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            Helper.Show("The editor will be available soon. ");

        }

        private void BtnPrint_Click(object? sender, EventArgs e)
        {
            if (DgvData.Rows.Count == 0)
            {
                MessageBox.Show("There is no data to print.");
                return;
            }

            printDialog1.Document = printDocument1;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }


    }
}
