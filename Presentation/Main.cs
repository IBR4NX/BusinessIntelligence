using Business.Metadata;
using Business.Services;
using Domain.Definition;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Drawing.Printing;
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
        private int dgvAnimationSpeed = 20;
        private readonly bool _isConnected;
        public Main(MetadataService metadataService, QueryService queryService)
        {
            InitializeComponent();
            _metadataService = metadataService;
            _queryService = queryService;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            dgvOpenDistance = splitContainer1.SplitterDistance;
            ConfigureFilterControls();
            LoadTables();
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
        }
        private void LoadColumns(string tableName)
        {
            _filters.Clear();
            RefreshFiltersList();
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


        private void LstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstTables.SelectedItem is not string tableName)
                return;
            lblColumns.Text = tableName;

            LoadColumns(tableName);
            BtnStart.Focus();
        }

        private void ClbColumns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(UpdateSelectedColumnsStatus);
        }

        private void UpdateSelectedColumnsStatus()
        {
            var selectedColumns = ClbColumns.CheckedItems
                .Cast<object>()
                .ToArray();

            StatusLabelCountColumnsSelected.Text = selectedColumns.Length.ToString();

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (LstTables.SelectedItem is not string tableName)
            {
                Helper.Show("Choose a table.");
                return;
            }

            var selectedColumns = ClbColumns.CheckedItems
            .Cast<string>()
            .Select(x => x.Split(" - ")[0])
            .ToList();

            var query = new QueryDefinition
            {
                TableName = tableName,
                SelectedColumns = selectedColumns,
                Filters = _filters.ToList()
            };

            try
            {
                var result = _queryService.Execute(query);

                DgvData.DataSource = result;
                Opensplit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ConfigureFilterControls()
        {
            textBox1.TextChanged += (_, _) => LoadTables();

            cmbFilterOperator.Items.AddRange(Enum.GetNames<ComparisonOperator>());
            cmbFilterOperator.SelectedItem = nameof(ComparisonOperator.Equal);
        }

        private void BtnAddFilter_Click(object? sender, EventArgs e)
        {
            if ((CbColumnsFilter.SelectedItem ?? CbColumnsFilter.Text) is not string columnName)
            {
                Helper.Show("Choose a column to filter.");
                return;
            }

            if (!Enum.TryParse((cmbFilterOperator.SelectedItem?.ToString() ?? cmbFilterOperator.Text), out ComparisonOperator comparisonOperator))
            {
                Helper.Show("Choose a valid comparison operator.");
                return;
            }

            string valueText = txtFilterValue.Text.Trim();
            var filter = new FilterDefinition
            {
                ColumnName = columnName,
                Operator = comparisonOperator
            };

            if (comparisonOperator is ComparisonOperator.IsNull or ComparisonOperator.IsNotNull)
            {
                if (!string.IsNullOrEmpty(valueText))
                {
                    Helper.Show("IS NULL and IS NOT NULL do not accept a value.");
                    return;
                }
            }
            else if (comparisonOperator is ComparisonOperator.Between or ComparisonOperator.In)
            {
                filter.Values = valueText.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Cast<object>()
                    .ToList();

                int minimumValues = comparisonOperator == ComparisonOperator.Between ? 2 : 1;
                if (filter.Values.Count < minimumValues || (comparisonOperator == ComparisonOperator.Between && filter.Values.Count != 2))
                {
                    Helper.Show(comparisonOperator == ComparisonOperator.Between
                        ? "Between requires exactly two comma-separated values."
                        : "In requires at least one value.");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(valueText))
                {
                    Helper.Show("Enter a value for the filter.");
                    return;
                }

                filter.Value = comparisonOperator == ComparisonOperator.Like
                    ? $"%{valueText}%"
                    : valueText;
            }

            _filters.Add(filter);
            txtFilterValue.Clear();
            RefreshFiltersList();
        }

        private void RefreshFiltersList()
        {
            lstFilters.Items.Clear();
            foreach (var filter in _filters)
            {
                string value = filter.Operator is ComparisonOperator.IsNull or ComparisonOperator.IsNotNull
                    ? string.Empty
                    : filter.Value?.ToString() ?? string.Join(", ", filter.Values ?? new List<object>());
                lstFilters.Items.Add($"{filter.ColumnName} {filter.Operator} {value}".Trim());
            }
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            _filters.Clear();
            RefreshFiltersList();
        }


        private void lblColumns_Click(object sender, EventArgs e)
        {

        }

        private void pnlFilters_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnStart.Focus();
        }

        private void pnlFilters_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isDgvHidden)
            {
                if (splitContainer1.SplitterDistance < dgvOpenDistance)
                {
                    splitContainer1.SplitterDistance += dgvAnimationSpeed;
                }
                else
                {
                    splitContainer1.SplitterDistance = splitContainer1.Height - 10;

                    timer1.Stop();
                }
            }
            else
            {
                if (splitContainer1.SplitterDistance > _targetSplitterDistance)
                {
                    splitContainer1.SplitterDistance -= dgvAnimationSpeed;
                }
                else
                {
                    splitContainer1.SplitterDistance = dgvOpenDistance;
                    timer1.Stop();
                }
            }
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

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void extrnaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            Helper.Show("The editor will be available soon. ");

        }

        private void CbColumnsFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
        private int _currentRow;

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            using Font headerFont = new Font("Segoe UI Semibold", 9);
            using Font cellFont = new Font("Segoe UI", 8);

            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            float rowHeight = 30;
            float columnWidth = e.MarginBounds.Width / Math.Max(1, DgvData.Columns.Count);

            foreach (DataGridViewColumn column in DgvData.Columns)
            {
                e.Graphics.DrawString(
                    column.HeaderText,
                    headerFont,
                    Brushes.Black,
                    new RectangleF(x, y, columnWidth, rowHeight));

                e.Graphics.DrawRectangle(
                    Pens.Black,
                    x,
                    y,
                    columnWidth,
                    rowHeight);

                x += columnWidth;
            }

            y += rowHeight;

            while (_currentRow < DgvData.Rows.Count)
            {
                x = e.MarginBounds.Left;

                foreach (DataGridViewCell cell in DgvData.Rows[_currentRow].Cells)
                {
                    string value = cell.Value?.ToString() ?? string.Empty;

                    e.Graphics.DrawString(
                        value,
                        cellFont,
                        Brushes.Black,
                        new RectangleF(x, y, columnWidth, rowHeight));

                    e.Graphics.DrawRectangle(
                        Pens.Black,
                        x,
                        y,
                        columnWidth,
                        rowHeight);

                    x += columnWidth;
                }

                y += rowHeight;
                _currentRow++;

                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            _currentRow = 0;
            e.HasMorePages = false;
        }

        private void BtnExportPdf_Click(object? sender, EventArgs e)
        {
            if (DgvData.DataSource == null || DgvData.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There is no data to export.",
                    "Export PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Export Report to PDF",
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = $"BusinessIntelligence_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                DefaultExt = "pdf",
                AddExtension = true
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                string tableName = LstTables.SelectedItem?.ToString() ?? "Data Report";

                var columns = DgvData.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .ToList();

                var rows = DgvData.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .ToList();

                QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4.Landscape());
                        page.Margin(30);

                        page.DefaultTextStyle(x =>
                            x.FontFamily("Arial")
                             .FontSize(9)
                             .FontColor("#252525"));

                        page.Header()
                            .Element(header =>
                            {
                                header
                                    .Background("#18181C")
                                    .Padding(12)
                                    .Row(row =>
                                    {
                                        row.RelativeItem()
                                            .Column(column =>
                                            {
                                                column.Item()
                                                    .Text("BUSINESS INTELLIGENCE")
                                                    .FontSize(20)
                                                    .Bold()
                                                    .FontColor("#D4AF37");

                                                column.Item()
                                                    .PaddingTop(4)
                                                    .Text("Dynamic Data Report")
                                                    .FontSize(10)
                                                    .FontColor("#B0B0B8");
                                            });

                                        row.ConstantItem(180)
                                            .AlignRight()
                                            .Column(column =>
                                            {
                                                column.Item()
                                                    .Text("REPORT")
                                                    .FontSize(9)
                                                    .Bold()
                                                    .FontColor("#D4AF37");

                                                column.Item()
                                                    .PaddingTop(4)
                                                    .Text(DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                                                    .FontSize(9)
                                                    .FontColor("#E8E8ED");
                                            });
                                    });
                            });

                        page.Content()
                            .PaddingTop(20)
                            .Column(column =>
                            {
                                column.Item()
                                    .Text(tableName)
                                    .FontSize(16)
                                    .Bold()
                                    .FontColor("#252525");

                                column.Item()
                                    .PaddingTop(4)
                                    .Text($"Rows: {rows.Count}    |    Columns: {columns.Count}")
                                    .FontSize(9)
                                    .FontColor("#777777");

                                column.Item()
                                    .PaddingTop(15)
                                    .Table(table =>
                                    {
                                        table.ColumnsDefinition(columnDefinition =>
                                        {
                                            foreach (var _ in columns)
                                                columnDefinition.RelativeColumn();
                                        });

                                        foreach (var gridColumn in columns)
                                        {
                                            table.Cell()
                                                .Background("#D4AF37")
                                                .Border(0.5f)
                                                .BorderColor("#A88920")
                                                .Padding(7)
                                                .Text(gridColumn.HeaderText)
                                                .Bold()
                                                .FontSize(8)
                                                .FontColor("#18181C");

                                        }

                                        foreach (var row in rows)
                                        {
                                            foreach (var gridColumn in columns)
                                            {
                                                string value =
                                                    row.Cells[gridColumn.Index].Value?.ToString()
                                                    ?? string.Empty;

                                                table.Cell()
                                                    .Background(
                                                        row.Index % 2 == 0
                                                            ? "#F7F7F8"
                                                            : "#FFFFFF")
                                                    .Border(0.5f)
                                                    .BorderColor("#DDDDDD")
                                                    .Padding(6)
                                                    .Text(value)
                                                    .FontSize(8)
                                                    .FontColor("#252525");
                                            }
                                        }
                                    });
                            });

                        page.Footer()
                            .PaddingTop(10)
                            .Row(row =>
                            {
                                row.RelativeItem()
                                    .Text("Business Intelligence")
                                    .FontSize(8)
                                    .FontColor("#777777");

                                row.RelativeItem()
                                    .AlignRight()
                                    .Text(text =>
                                    {
                                        text.Span("Page ")
                                            .FontSize(8)
                                            .FontColor("#777777");

                                        text.CurrentPageNumber()
                                            .FontSize(8)
                                            .FontColor("#777777");

                                        text.Span(" of ")
                                            .FontSize(8)
                                            .FontColor("#777777");

                                        text.TotalPages()
                                            .FontSize(8)
                                            .FontColor("#777777");
                                    });
                            });
                    });
                })
                .GeneratePdf(dialog.FileName);

                MessageBox.Show(
                    $"PDF exported successfully.\n\n{dialog.FileName}",
                    "Export PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to export PDF.\n\n{ex.Message}",
                    "Export PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
