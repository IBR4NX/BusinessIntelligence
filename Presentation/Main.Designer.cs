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
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripSplitButton1 = new ToolStripSplitButton();
            pnlSidebar = new Panel();
            lstTables = new Krypton.Toolkit.KryptonListBox();
            txtSearchTable = new TextBox();
            lblTables = new Label();
            lblColumns = new Label();
            lblQueryBuilder = new Label();
            pnlContent = new Krypton.Toolkit.KryptonPanel();
            clbColumn = new Krypton.Toolkit.KryptonCheckedListBox();
            pnlHeader.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlContent).BeginInit();
            pnlContent.SuspendLayout();
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
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripSplitButton1 });
            statusStrip1.Location = new Point(6, 418);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(788, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 20);
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(39, 24);
            toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(lstTables);
            pnlSidebar.Controls.Add(txtSearchTable);
            pnlSidebar.Controls.Add(lblTables);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(6, 70);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 348);
            pnlSidebar.TabIndex = 3;
            // 
            // lstTables
            // 
            lstTables.Location = new Point(20, 120);
            lstTables.Name = "lstTables";
            lstTables.Size = new Size(220, 500);
            lstTables.TabIndex = 6;
            lstTables.SelectedIndexChanged += lstTables_SelectedIndexChanged;
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
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(266, 70);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(528, 348);
            pnlContent.TabIndex = 9;
            // 
            // clbColumn
            // 
            clbColumn.Location = new Point(95, 120);
            clbColumn.Name = "clbColumn";
            clbColumn.Size = new Size(150, 120);
            clbColumn.TabIndex = 7;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(statusStrip1);
            Controls.Add(pnlHeader);
            Name = "Main";
            Padding = new Padding(6);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            WindowState = FormWindowState.Maximized;
            Load += Main_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlContent).EndInit();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox clbColumns;
        private Panel pnlHeader;
        private Label lblTitle;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Panel pnlSidebar;
        private TextBox txtSearchTable;
        private Label lblTables;
        private Label lblQueryBuilder;
        private ToolStripSplitButton toolStripSplitButton1;
        private Label lblColumns;
        private Krypton.Toolkit.KryptonListBox lstTables;
        private Krypton.Toolkit.KryptonPanel pnlContent;
        private Krypton.Toolkit.KryptonCheckedListBox clbColumn;
    }
}