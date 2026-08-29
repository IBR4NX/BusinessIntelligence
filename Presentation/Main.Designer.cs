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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlSidebar = new Panel();
            lstTables = new Krypton.Toolkit.KryptonListBox();
            txtSearchTable = new TextBox();
            lblTables = new Label();
            lblColumns = new Label();
            lblQueryBuilder = new Label();
            pnlContent = new Krypton.Toolkit.KryptonPanel();
            clbColumn = new Krypton.Toolkit.KryptonCheckedListBox();
            kryptonStatusStrip1 = new Krypton.Toolkit.KryptonStatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlContent).BeginInit();
            pnlContent.SuspendLayout();
            kryptonStatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(6, 6);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(788, 64);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(25, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(224, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dynamic Data Management";
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(lstTables);
            pnlSidebar.Controls.Add(txtSearchTable);
            pnlSidebar.Controls.Add(lblTables);
            pnlSidebar.Location = new Point(6, 70);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 374);
            pnlSidebar.TabIndex = 3;
            // 
            // lstTables
            // 
            lstTables.Location = new Point(20, 120);
            lstTables.Name = "lstTables";
            lstTables.Size = new Size(220, 500);
            lstTables.TabIndex = 6;
            lstTables.SelectedIndexChanged += LstTables_SelectedIndexChanged;
            // 
            // txtSearchTable
            // 
            txtSearchTable.Location = new Point(20, 55);
            txtSearchTable.Name = "txtSearchTable";
            txtSearchTable.PlaceholderText = "Search tables...";
            txtSearchTable.Size = new Size(220, 30);
            txtSearchTable.TabIndex = 4;
            // 
            // lblTables
            // 
            lblTables.AutoSize = true;
            lblTables.Location = new Point(20, 25);
            lblTables.Name = "lblTables";
            lblTables.Size = new Size(65, 23);
            lblTables.TabIndex = 0;
            lblTables.Text = "TABLES";
            // 
            // lblColumns
            // 
            lblColumns.AutoSize = true;
            lblColumns.Location = new Point(17, 62);
            lblColumns.Name = "lblColumns";
            lblColumns.Size = new Size(91, 23);
            lblColumns.TabIndex = 6;
            lblColumns.Text = "COLUMNS";
            // 
            // lblQueryBuilder
            // 
            lblQueryBuilder.AutoSize = true;
            lblQueryBuilder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblQueryBuilder.Location = new Point(17, 20);
            lblQueryBuilder.Name = "lblQueryBuilder";
            lblQueryBuilder.Size = new Size(131, 28);
            lblQueryBuilder.TabIndex = 6;
            lblQueryBuilder.Text = "Query Builder";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(clbColumn);
            pnlContent.Controls.Add(lblQueryBuilder);
            pnlContent.Controls.Add(lblColumns);
            pnlContent.Location = new Point(266, 70);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(528, 348);
            pnlContent.TabIndex = 9;
            // 
            // clbColumn
            // 
            clbColumn.ImeMode = ImeMode.Hangul;
            clbColumn.Items.AddRange(new object[] { "ibefsd dsf", "sdfsdf kelwk fwlkef", "welkfnewlkfwlekf wlekf " });
            clbColumn.ItemStyle = Krypton.Toolkit.ButtonStyle.Custom1;
            clbColumn.Location = new Point(17, 88);
            clbColumn.Name = "clbColumn";
            clbColumn.Size = new Size(273, 228);
            clbColumn.TabIndex = 7;
            // 
            // kryptonStatusStrip1
            // 
            kryptonStatusStrip1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            kryptonStatusStrip1.ImageScalingSize = new Size(20, 20);
            kryptonStatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripDropDownButton1 });
            kryptonStatusStrip1.Location = new Point(6, 415);
            kryptonStatusStrip1.Name = "kryptonStatusStrip1";
            kryptonStatusStrip1.ProgressBars = null;
            kryptonStatusStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            kryptonStatusStrip1.Size = new Size(788, 29);
            kryptonStatusStrip1.TabIndex = 10;
            kryptonStatusStrip1.Text = "kryptonStatusStrip1";
            kryptonStatusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.RightToLeftAutoMirrorImage = true;
            toolStripStatusLabel1.Size = new Size(121, 23);
            toolStripStatusLabel1.Text = "\U0001f7e2 Connected";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(34, 27);
            toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(800, 450);
            Controls.Add(kryptonStatusStrip1);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            Name = "Main";
            Padding = new Padding(6);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            WindowState = FormWindowState.Maximized;
            Load += Main_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlContent).EndInit();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            kryptonStatusStrip1.ResumeLayout(false);
            kryptonStatusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox clbColumns;
        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlSidebar;
        private TextBox txtSearchTable;
        private Label lblTables;
        private Label lblQueryBuilder;
        private Label lblColumns;
        private Krypton.Toolkit.KryptonListBox lstTables;
        private Krypton.Toolkit.KryptonPanel pnlContent;
        private Krypton.Toolkit.KryptonCheckedListBox clbColumn;
        private Krypton.Toolkit.KryptonStatusStrip kryptonStatusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripDropDownButton toolStripDropDownButton1;
    }
}