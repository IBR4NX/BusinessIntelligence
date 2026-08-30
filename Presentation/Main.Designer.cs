namespace Presentation
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Container = new SplitContainer();
            pnlSidebar = new Panel();
            lstTables = new Krypton.Toolkit.KryptonListBox();
            panel2 = new Panel();
            textBox1 = new TextBox();
            lblTables = new Label();
            splitContainer2 = new SplitContainer();
            BtnStart = new Krypton.Toolkit.KryptonButton();
            pnlContent = new Panel();
            kryptonThemeListBox1 = new Krypton.Toolkit.KryptonThemeListBox();
            clbColumns = new Krypton.Toolkit.KryptonCheckedListBox();
            lblQueryBuilder = new Label();
            CbColumns = new Krypton.Toolkit.KryptonComboBox();
            buttonSpecAny1 = new Krypton.Toolkit.ButtonSpecAny();
            buttonSpecAny2 = new Krypton.Toolkit.ButtonSpecAny();
            lblColumns = new Label();
            DgvData = new Krypton.Toolkit.KryptonDataGridView();
            pnlHeader = new Panel();
            lblTitle = new Label();
            StatusStrip = new Krypton.Toolkit.KryptonStatusStrip();
            StatusLabelCountTables = new ToolStripStatusLabel();
            StatusLabelCountColumnsSelected = new ToolStripStatusLabel();
            ContextMenu = new Krypton.Toolkit.KryptonContextMenu();
            ((System.ComponentModel.ISupportInitialize)Container).BeginInit();
            Container.Panel1.SuspendLayout();
            Container.Panel2.SuspendLayout();
            Container.SuspendLayout();
            pnlSidebar.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CbColumns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvData).BeginInit();
            pnlHeader.SuspendLayout();
            StatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // Container
            // 
            Container.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(Container, "Container");
            Container.Name = "Container";
            // 
            // Container.Panel1
            // 
            Container.Panel1.AccessibleRole = AccessibleRole.ScrollBar;
            Container.Panel1.Controls.Add(pnlSidebar);
            Container.Panel1.Controls.Add(panel2);
            resources.ApplyResources(Container.Panel1, "Container.Panel1");
            // 
            // Container.Panel2
            // 
            Container.Panel2.Controls.Add(splitContainer2);
            // 
            // pnlSidebar
            // 
            resources.ApplyResources(pnlSidebar, "pnlSidebar");
            pnlSidebar.Controls.Add(lstTables);
            pnlSidebar.Name = "pnlSidebar";
            // 
            // lstTables
            // 
            lstTables.BackStyle = Krypton.Toolkit.PaletteBackStyle.ControlClient;
            lstTables.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.FormMain;
            resources.ApplyResources(lstTables, "lstTables");
            lstTables.FormattingEnabled = true;
            lstTables.Name = "lstTables";
            lstTables.SelectedIndexChanged += LstTables_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(lblTables);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Gray;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Cursor = Cursors.Cross;
            textBox1.ForeColor = SystemColors.Window;
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.Name = "textBox1";
            // 
            // lblTables
            // 
            resources.ApplyResources(lblTables, "lblTables");
            lblTables.Name = "lblTables";
            // 
            // splitContainer2
            // 
            resources.ApplyResources(splitContainer2, "splitContainer2");
            splitContainer2.ForeColor = Color.Coral;
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(BtnStart);
            splitContainer2.Panel1.Controls.Add(pnlContent);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(DgvData);
            // 
            // BtnStart
            // 
            resources.ApplyResources(BtnStart, "BtnStart");
            BtnStart.Name = "BtnStart";
            BtnStart.Values.Text = resources.GetString("BtnStart.Values.Text");
            BtnStart.Click += BtnStart_Click;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(kryptonThemeListBox1);
            pnlContent.Controls.Add(clbColumns);
            pnlContent.Controls.Add(lblQueryBuilder);
            pnlContent.Controls.Add(CbColumns);
            pnlContent.Controls.Add(lblColumns);
            resources.ApplyResources(pnlContent, "pnlContent");
            pnlContent.Name = "pnlContent";
            pnlContent.Paint += panel1_Paint;
            pnlContent.Enter += BtnStart_Click;
            // 
            // kryptonThemeListBox1
            // 
            resources.ApplyResources(kryptonThemeListBox1, "kryptonThemeListBox1");
            kryptonThemeListBox1.Name = "kryptonThemeListBox1";
            kryptonThemeListBox1.ThemeSelectedIndex = -1;
            // 
            // clbColumns
            // 
            resources.ApplyResources(clbColumns, "clbColumns");
            clbColumns.Name = "clbColumns";
            // 
            // lblQueryBuilder
            // 
            resources.ApplyResources(lblQueryBuilder, "lblQueryBuilder");
            lblQueryBuilder.Name = "lblQueryBuilder";
            // 
            // CbColumns
            // 
            CbColumns.ButtonSpecs.Add(buttonSpecAny1);
            CbColumns.ButtonSpecs.Add(buttonSpecAny2);
            CbColumns.DropDownWidth = 151;
            CbColumns.IntegralHeight = false;
            resources.ApplyResources(CbColumns, "CbColumns");
            CbColumns.Name = "CbColumns";
            CbColumns.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            // 
            // buttonSpecAny1
            // 
            buttonSpecAny1.UniqueName = "41beac874f7b4c26b564e98331f20d46";
            // 
            // buttonSpecAny2
            // 
            buttonSpecAny2.UniqueName = "0a402407c24441a58e3c17d10e5ba6a6";
            // 
            // lblColumns
            // 
            resources.ApplyResources(lblColumns, "lblColumns");
            lblColumns.Name = "lblColumns";
            // 
            // DgvData
            // 
            DgvData.BorderStyle = BorderStyle.None;
            resources.ApplyResources(DgvData, "DgvData");
            DgvData.Name = "DgvData";
            DgvData.RowTemplate.Height = 32;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            resources.ApplyResources(pnlHeader, "pnlHeader");
            pnlHeader.Name = "pnlHeader";
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.Name = "lblTitle";
            // 
            // StatusStrip
            // 
            resources.ApplyResources(StatusStrip, "StatusStrip");
            StatusStrip.ImageScalingSize = new Size(20, 20);
            StatusStrip.Items.AddRange(new ToolStripItem[] { StatusLabelCountTables, StatusLabelCountColumnsSelected });
            StatusStrip.Name = "StatusStrip";
            StatusStrip.ProgressBars = null;
            StatusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            // 
            // StatusLabelCountTables
            // 
            StatusLabelCountTables.Name = "StatusLabelCountTables";
            resources.ApplyResources(StatusLabelCountTables, "StatusLabelCountTables");
            // 
            // StatusLabelCountColumnsSelected
            // 
            StatusLabelCountColumnsSelected.Name = "StatusLabelCountColumnsSelected";
            resources.ApplyResources(StatusLabelCountColumnsSelected, "StatusLabelCountColumnsSelected");
            // 
            // Main
            // 
            AccessibleRole = AccessibleRole.Window;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            Controls.Add(StatusStrip);
            Controls.Add(Container);
            Controls.Add(pnlHeader);
            ForeColor = SystemColors.ButtonFace;
            HelpButton = true;
            Name = "Main";
            Load += Main_Load;
            Container.Panel1.ResumeLayout(false);
            Container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Container).EndInit();
            Container.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CbColumns).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvData).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnlHeader;
        private Label lblTitle;
        //private Panel pnlSidebar;
        private Panel panel2;
        private Label lblTables;
        private Label lblQueryBuilder;
        private Label lblColumns;
        private Krypton.Toolkit.KryptonListBox lstTables;
        private Krypton.Toolkit.KryptonStatusStrip StatusStrip;
        private ToolStripStatusLabel StatusLabelCountTables;
        private ToolStripStatusLabel StatusLabelCountColumnsSelected;
        private Krypton.Toolkit.KryptonComboBox CbColumns;
        private Krypton.Toolkit.KryptonButton BtnStart;
        private Krypton.Toolkit.KryptonDataGridView DgvData;
        private SplitContainer Container;
        private SplitContainer splitContainer2;
        private Panel pnlSidebar;
        private Krypton.Toolkit.KryptonContextMenu ContextMenu;
        private TextBox textBox1;
        private Panel pnlContent;
        private Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private Krypton.Toolkit.KryptonThemeListBox kryptonThemeListBox1;
        private Krypton.Toolkit.KryptonCheckedListBox clbColumns;
    }
}