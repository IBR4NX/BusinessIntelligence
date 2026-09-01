using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    partial class Main
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            toolStripContainer1 = new ToolStripContainer();
            panelContent = new Panel();
            pnlContent = new Panel();
            pnlClbColomns = new Panel();
            ClbColumns = new CheckedListBox();
            lblColumns = new Label();
            pnlFilters = new Panel();
            lblFilter = new Label();
            lblOperator = new Label();
            lblValue = new Label();
            CbColumnsFilter = new ComboBox();
            cmbFilterOperator = new ComboBox();
            txtFilterValue = new TextBox();
            BtnAddFilter = new Button();
            lstFilters = new ListBox();
            BtnClearFilters = new Button();
            BtnStart = new Button();
            pnlTop = new Panel();
            lblTitle = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            printToolStripMenuItem = new ToolStripMenuItem();
            printPreviewToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            contentsToolStripMenuItem = new ToolStripMenuItem();
            indexToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            contextDgvData = new ContextMenuStrip(components);
            EditItem = new ToolStripMenuItem();
            deleteTheItemToolStripMenuItem = new ToolStripMenuItem();
            extrnaToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            BottomToolStripPanel = new ToolStripPanel();
            miniToolStrip = new StatusStrip();
            toolStripStatusLabelTables = new ToolStripStatusLabel();
            StatusLabelCountTables = new ToolStripStatusLabel();
            toolStripStatusLabelColumns = new ToolStripStatusLabel();
            StatusLabelCountColumnsSelected = new ToolStripStatusLabel();
            toolStripSplitBtnHidden = new ToolStripSplitButton();
            TopToolStripPanel = new ToolStripPanel();
            RightToolStripPanel = new ToolStripPanel();
            LeftToolStripPanel = new ToolStripPanel();
            ContentPanel = new ToolStripContentPanel();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            panel2 = new Panel();
            LstTables = new ListBox();
            pnlSidebar = new Panel();
            textBox1 = new TextBox();
            lblTables = new Label();
            DgvData = new DataGridView();
            statusStripButtom = new StatusStrip();
            toolStripStatusLabelConnection = new ToolStripStatusLabel();
            StatusLabelConnection = new ToolStripStatusLabel();
            printDialog1 = new PrintDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            panelContent.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlClbColomns.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlTop.SuspendLayout();
            menuStrip1.SuspendLayout();
            contextDgvData.SuspendLayout();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel2.SuspendLayout();
            pnlSidebar.SuspendLayout();
            ((ISupportInitialize)DgvData).BeginInit();
            statusStripButtom.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(panelContent);
            resources.ApplyResources(toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(toolStripContainer1, "toolStripContainer1");
            toolStripContainer1.LeftToolStripPanelVisible = false;
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.RightToolStripPanelVisible = false;
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip1);
            // 
            // panelContent
            // 
            resources.ApplyResources(panelContent, "panelContent");
            panelContent.Controls.Add(pnlContent);
            panelContent.Controls.Add(pnlTop);
            panelContent.Name = "panelContent";
            // 
            // pnlContent
            // 
            resources.ApplyResources(pnlContent, "pnlContent");
            pnlContent.BackColor = Color.FromArgb(18, 18, 20);
            pnlContent.Controls.Add(pnlClbColomns);
            pnlContent.Controls.Add(lblColumns);
            pnlContent.Controls.Add(pnlFilters);
            pnlContent.Name = "pnlContent";
            // 
            // pnlClbColomns
            // 
            pnlClbColomns.Controls.Add(ClbColumns);
            resources.ApplyResources(pnlClbColomns, "pnlClbColomns");
            pnlClbColomns.Name = "pnlClbColomns";
            // 
            // ClbColumns
            // 
            ClbColumns.BackColor = Color.FromArgb(36, 38, 44);
            ClbColumns.BorderStyle = BorderStyle.FixedSingle;
            ClbColumns.CheckOnClick = true;
            resources.ApplyResources(ClbColumns, "ClbColumns");
            ClbColumns.ForeColor = Color.FromArgb(235, 235, 240);
            ClbColumns.FormattingEnabled = true;
            ClbColumns.Name = "ClbColumns";
            ClbColumns.ItemCheck += ClbColumns_ItemCheck;
            ClbColumns.SelectedIndexChanged += ClbColumns_SelectedIndexChanged;
            // 
            // lblColumns
            // 
            resources.ApplyResources(lblColumns, "lblColumns");
            lblColumns.ForeColor = Color.FromArgb(235, 235, 240);
            lblColumns.Name = "lblColumns";
            lblColumns.Click += lblColumns_Click;
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.FromArgb(28, 30, 35);
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblFilter);
            pnlFilters.Controls.Add(lblOperator);
            pnlFilters.Controls.Add(lblValue);
            pnlFilters.Controls.Add(CbColumnsFilter);
            pnlFilters.Controls.Add(cmbFilterOperator);
            pnlFilters.Controls.Add(txtFilterValue);
            pnlFilters.Controls.Add(BtnAddFilter);
            pnlFilters.Controls.Add(lstFilters);
            pnlFilters.Controls.Add(BtnClearFilters);
            pnlFilters.Controls.Add(BtnStart);
            resources.ApplyResources(pnlFilters, "pnlFilters");
            pnlFilters.Name = "pnlFilters";
            // 
            // lblFilter
            // 
            resources.ApplyResources(lblFilter, "lblFilter");
            lblFilter.ForeColor = Color.FromArgb(160, 163, 175);
            lblFilter.Name = "lblFilter";
            // 
            // lblOperator
            // 
            resources.ApplyResources(lblOperator, "lblOperator");
            lblOperator.ForeColor = Color.FromArgb(160, 163, 175);
            lblOperator.Name = "lblOperator";
            // 
            // lblValue
            // 
            resources.ApplyResources(lblValue, "lblValue");
            lblValue.ForeColor = Color.FromArgb(160, 163, 175);
            lblValue.Name = "lblValue";
            // 
            // CbColumnsFilter
            // 
            CbColumnsFilter.BackColor = Color.FromArgb(36, 38, 44);
            CbColumnsFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(CbColumnsFilter, "CbColumnsFilter");
            CbColumnsFilter.ForeColor = Color.FromArgb(235, 235, 240);
            CbColumnsFilter.Name = "CbColumnsFilter";
            CbColumnsFilter.SelectedIndexChanged += CbColumnsFilter_SelectedIndexChanged;
            // 
            // cmbFilterOperator
            // 
            cmbFilterOperator.BackColor = Color.FromArgb(36, 38, 44);
            cmbFilterOperator.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(cmbFilterOperator, "cmbFilterOperator");
            cmbFilterOperator.ForeColor = Color.FromArgb(235, 235, 240);
            cmbFilterOperator.Name = "cmbFilterOperator";
            // 
            // txtFilterValue
            // 
            txtFilterValue.AcceptsReturn = true;
            txtFilterValue.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFilterValue.BackColor = Color.FromArgb(36, 38, 44);
            txtFilterValue.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtFilterValue, "txtFilterValue");
            txtFilterValue.ForeColor = Color.FromArgb(235, 235, 240);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Enter += BtnAddFilter_Click;
            // 
            // BtnAddFilter
            // 
            BtnAddFilter.BackColor = Color.FromArgb(99, 102, 241);
            BtnAddFilter.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnAddFilter, "BtnAddFilter");
            BtnAddFilter.ForeColor = Color.White;
            BtnAddFilter.Name = "BtnAddFilter";
            BtnAddFilter.UseVisualStyleBackColor = false;
            BtnAddFilter.Click += BtnAddFilter_Click;
            // 
            // lstFilters
            // 
            lstFilters.BackColor = Color.FromArgb(36, 38, 44);
            lstFilters.BorderStyle = BorderStyle.None;
            resources.ApplyResources(lstFilters, "lstFilters");
            lstFilters.ForeColor = Color.FromArgb(235, 235, 240);
            lstFilters.FormattingEnabled = true;
            lstFilters.Name = "lstFilters";
            // 
            // BtnClearFilters
            // 
            BtnClearFilters.BackColor = Color.FromArgb(36, 38, 44);
            BtnClearFilters.FlatAppearance.BorderColor = Color.FromArgb(55, 58, 66);
            resources.ApplyResources(BtnClearFilters, "BtnClearFilters");
            BtnClearFilters.ForeColor = Color.FromArgb(160, 163, 175);
            BtnClearFilters.Name = "BtnClearFilters";
            BtnClearFilters.UseVisualStyleBackColor = false;
            BtnClearFilters.Click += BtnClearFilters_Click;
            // 
            // BtnStart
            // 
            BtnStart.BackColor = Color.OrangeRed;
            BtnStart.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnStart, "BtnStart");
            BtnStart.ForeColor = Color.White;
            BtnStart.Name = "BtnStart";
            BtnStart.UseVisualStyleBackColor = false;
            BtnStart.Click += BtnStart_Click;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(18, 18, 20);
            pnlTop.Controls.Add(lblTitle);
            resources.ApplyResources(pnlTop, "pnlTop");
            pnlTop.Name = "pnlTop";
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.ForeColor = Color.FromArgb(235, 235, 240);
            lblTitle.Name = "lblTitle";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(23, 24, 28);
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.ForeColor = Color.White;
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, printToolStripMenuItem, printPreviewToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            resources.ApplyResources(newToolStripMenuItem, "newToolStripMenuItem");
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(openToolStripMenuItem, "openToolStripMenuItem");
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(toolStripSeparator, "toolStripSeparator");
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(saveToolStripMenuItem, "saveToolStripMenuItem");
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // printToolStripMenuItem
            // 
            resources.ApplyResources(printToolStripMenuItem, "printToolStripMenuItem");
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Click += BtnPrint_Click;
            // 
            // printPreviewToolStripMenuItem
            // 
            resources.ApplyResources(printPreviewToolStripMenuItem, "printPreviewToolStripMenuItem");
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Click += BtnExportPdf_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator4, selectAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            resources.ApplyResources(undoToolStripMenuItem, "undoToolStripMenuItem");
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            resources.ApplyResources(redoToolStripMenuItem, "redoToolStripMenuItem");
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // cutToolStripMenuItem
            // 
            resources.ApplyResources(cutToolStripMenuItem, "cutToolStripMenuItem");
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            // 
            // copyToolStripMenuItem
            // 
            resources.ApplyResources(copyToolStripMenuItem, "copyToolStripMenuItem");
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            // 
            // pasteToolStripMenuItem
            // 
            resources.ApplyResources(pasteToolStripMenuItem, "pasteToolStripMenuItem");
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            resources.ApplyResources(customizeToolStripMenuItem, "customizeToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator5, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            resources.ApplyResources(contentsToolStripMenuItem, "contentsToolStripMenuItem");
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            resources.ApplyResources(indexToolStripMenuItem, "indexToolStripMenuItem");
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            resources.ApplyResources(searchToolStripMenuItem, "searchToolStripMenuItem");
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(toolStripSeparator5, "toolStripSeparator5");
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // contextDgvData
            // 
            resources.ApplyResources(contextDgvData, "contextDgvData");
            contextDgvData.ImageScalingSize = new Size(20, 20);
            contextDgvData.Items.AddRange(new ToolStripItem[] { EditItem, deleteTheItemToolStripMenuItem, extrnaToolStripMenuItem });
            contextDgvData.Name = "contextMenuStrip1";
            // 
            // EditItem
            // 
            EditItem.Name = "EditItem";
            resources.ApplyResources(EditItem, "EditItem");
            EditItem.Click += EditItem_Click;
            // 
            // deleteTheItemToolStripMenuItem
            // 
            deleteTheItemToolStripMenuItem.Name = "deleteTheItemToolStripMenuItem";
            resources.ApplyResources(deleteTheItemToolStripMenuItem, "deleteTheItemToolStripMenuItem");
            // 
            // extrnaToolStripMenuItem
            // 
            extrnaToolStripMenuItem.Name = "extrnaToolStripMenuItem";
            resources.ApplyResources(extrnaToolStripMenuItem, "extrnaToolStripMenuItem");
            extrnaToolStripMenuItem.Click += extrnaToolStripMenuItem_Click;
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // BottomToolStripPanel
            // 
            resources.ApplyResources(BottomToolStripPanel, "BottomToolStripPanel");
            BottomToolStripPanel.Name = "BottomToolStripPanel";
            BottomToolStripPanel.Orientation = Orientation.Horizontal;
            BottomToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleRole = AccessibleRole.ButtonDropDown;
            miniToolStrip.BackColor = Color.FromArgb(23, 24, 28);
            resources.ApplyResources(miniToolStrip, "miniToolStrip");
            miniToolStrip.ForeColor = Color.FromArgb(160, 163, 175);
            miniToolStrip.ImageScalingSize = new Size(20, 20);
            miniToolStrip.Name = "miniToolStrip";
            // 
            // toolStripStatusLabelTables
            // 
            toolStripStatusLabelTables.Name = "toolStripStatusLabelTables";
            resources.ApplyResources(toolStripStatusLabelTables, "toolStripStatusLabelTables");
            // 
            // StatusLabelCountTables
            // 
            StatusLabelCountTables.Name = "StatusLabelCountTables";
            resources.ApplyResources(StatusLabelCountTables, "StatusLabelCountTables");
            // 
            // toolStripStatusLabelColumns
            // 
            toolStripStatusLabelColumns.Name = "toolStripStatusLabelColumns";
            resources.ApplyResources(toolStripStatusLabelColumns, "toolStripStatusLabelColumns");
            // 
            // StatusLabelCountColumnsSelected
            // 
            StatusLabelCountColumnsSelected.Name = "StatusLabelCountColumnsSelected";
            resources.ApplyResources(StatusLabelCountColumnsSelected, "StatusLabelCountColumnsSelected");
            // 
            // toolStripSplitBtnHidden
            // 
            toolStripSplitBtnHidden.BackColor = Color.Silver;
            toolStripSplitBtnHidden.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripSplitBtnHidden.DoubleClickEnabled = true;
            toolStripSplitBtnHidden.Image = Properties.Resources.icons8_website_64;
            resources.ApplyResources(toolStripSplitBtnHidden, "toolStripSplitBtnHidden");
            toolStripSplitBtnHidden.Name = "toolStripSplitBtnHidden";
            toolStripSplitBtnHidden.ButtonClick += toolStripSplitBtnHidden_ButtonClick;
            // 
            // TopToolStripPanel
            // 
            resources.ApplyResources(TopToolStripPanel, "TopToolStripPanel");
            TopToolStripPanel.Name = "TopToolStripPanel";
            TopToolStripPanel.Orientation = Orientation.Horizontal;
            TopToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            // 
            // RightToolStripPanel
            // 
            resources.ApplyResources(RightToolStripPanel, "RightToolStripPanel");
            RightToolStripPanel.Name = "RightToolStripPanel";
            RightToolStripPanel.Orientation = Orientation.Horizontal;
            RightToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            // 
            // LeftToolStripPanel
            // 
            resources.ApplyResources(LeftToolStripPanel, "LeftToolStripPanel");
            LeftToolStripPanel.Name = "LeftToolStripPanel";
            LeftToolStripPanel.Orientation = Orientation.Horizontal;
            LeftToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            // 
            // ContentPanel
            // 
            resources.ApplyResources(ContentPanel, "ContentPanel");
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.ControlDarkDark;
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(DgvData);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(splitContainer2, "splitContainer2");
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(panel2);
            splitContainer2.Panel1.Controls.Add(pnlSidebar);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(toolStripContainer1);
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(23, 24, 28);
            panel2.Controls.Add(LstTables);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // LstTables
            // 
            LstTables.BackColor = Color.FromArgb(36, 38, 44);
            LstTables.BorderStyle = BorderStyle.None;
            resources.ApplyResources(LstTables, "LstTables");
            LstTables.ForeColor = Color.FromArgb(235, 235, 240);
            LstTables.FormattingEnabled = true;
            LstTables.Name = "LstTables";
            LstTables.SelectedIndexChanged += LstTables_SelectedIndexChanged;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(23, 24, 28);
            pnlSidebar.Controls.Add(textBox1);
            pnlSidebar.Controls.Add(lblTables);
            resources.ApplyResources(pnlSidebar, "pnlSidebar");
            pnlSidebar.Name = "pnlSidebar";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(36, 38, 44);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.ForeColor = Color.FromArgb(235, 235, 240);
            textBox1.Name = "textBox1";
            // 
            // lblTables
            // 
            resources.ApplyResources(lblTables, "lblTables");
            lblTables.ForeColor = Color.FromArgb(235, 235, 240);
            lblTables.Name = "lblTables";
            // 
            // DgvData
            // 
            DgvData.AllowUserToAddRows = false;
            DgvData.AllowUserToDeleteRows = false;
            DgvData.AllowUserToResizeRows = false;
            DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvData.BackgroundColor = Color.FromArgb(36, 38, 44);
            DgvData.BorderStyle = BorderStyle.None;
            DgvData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(38, 40, 47);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(235, 235, 240);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(DgvData, "DgvData");
            DgvData.ContextMenuStrip = contextDgvData;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(36, 38, 44);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(235, 235, 240);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(55, 58, 70);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DgvData.DefaultCellStyle = dataGridViewCellStyle2;
            DgvData.EnableHeadersVisualStyles = false;
            DgvData.GridColor = Color.FromArgb(55, 58, 66);
            DgvData.Name = "DgvData";
            DgvData.ReadOnly = true;
            DgvData.RowHeadersVisible = false;
            DgvData.RowTemplate.Height = 32;
            DgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvData.CellContentClick += DgvData_CellContentClick;
            // 
            // statusStripButtom
            // 
            statusStripButtom.BackColor = Color.FromArgb(23, 24, 28);
            statusStripButtom.ForeColor = Color.FromArgb(160, 163, 175);
            statusStripButtom.ImageScalingSize = new Size(20, 20);
            statusStripButtom.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelTables, StatusLabelCountTables, toolStripStatusLabelColumns, StatusLabelCountColumnsSelected, toolStripSplitBtnHidden, toolStripStatusLabelConnection, StatusLabelConnection });
            resources.ApplyResources(statusStripButtom, "statusStripButtom");
            statusStripButtom.Name = "statusStripButtom";
            // 
            // toolStripStatusLabelConnection
            // 
            toolStripStatusLabelConnection.Name = "toolStripStatusLabelConnection";
            resources.ApplyResources(toolStripStatusLabelConnection, "toolStripStatusLabelConnection");
            // 
            // StatusLabelConnection
            // 
            StatusLabelConnection.Name = "StatusLabelConnection";
            resources.ApplyResources(StatusLabelConnection, "StatusLabelConnection");
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument_PrintPage;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 20);
            Controls.Add(splitContainer1);
            Controls.Add(statusStripButtom);
            ForeColor = Color.FromArgb(235, 235, 240);
            Name = "Main";
            Load += Main_Load;
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            panelContent.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlClbColomns.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextDgvData.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ((ISupportInitialize)DgvData).EndInit();
            statusStripButtom.ResumeLayout(false);
            statusStripButtom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Timer timer1;
        private ContextMenuStrip contextDgvData;
        private ToolStripMenuItem EditItem;
        private ToolStripMenuItem deleteTheItemToolStripMenuItem;
        private ToolStripMenuItem extrnaToolStripMenuItem;
        private ToolStripPanel BottomToolStripPanel;
        private StatusStrip miniToolStrip;
        private ToolStripStatusLabel toolStripStatusLabelTables;
        private ToolStripStatusLabel StatusLabelCountTables;
        private ToolStripStatusLabel toolStripStatusLabelColumns;
        private ToolStripStatusLabel StatusLabelCountColumnsSelected;
        private ToolStripSplitButton toolStripSplitBtnHidden;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel toolstrContentPanel;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Panel panel2;
        private ListBox LstTables;
        private Panel pnlSidebar;
        private TextBox textBox1;
        private Label lblTables;
        private Panel panelContent;
        private Panel pnlContent;
        private Panel pnlClbColomns;
        private CheckedListBox ClbColumns;
        private Label lblColumns;
        private Panel pnlFilters;
        private Label lblFilter;
        private Label lblOperator;
        private Label lblValue;
        private ComboBox CbColumnsFilter;
        private ComboBox cmbFilterOperator;
        private TextBox txtFilterValue;
        private Button BtnAddFilter;
        private ListBox lstFilters;
        private Button BtnClearFilters;
        private Button BtnStart;
        private Panel pnlTop;
        private Label lblTitle;
        private DataGridView DgvData;
        private StatusStrip statusStripButtom;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripContainer toolStripContainer1;
        private ToolStripContentPanel ContentPanel;
        private ToolStripStatusLabel toolStripStatusLabelConnection;
        private ToolStripStatusLabel StatusLabelConnection;
        private PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}