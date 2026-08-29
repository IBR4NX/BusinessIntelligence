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
            clbColumns = new ListBox();
            pnlHeader = new Panel();
            lblTitle = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripSplitButton1 = new ToolStripSplitButton();
            pnlSidebar = new Panel();
            lstTables = new ListBox();
            txtSearchTable = new TextBox();
            lblTables = new Label();
            pnlContent = new Panel();
            lblColumns = new Label();
            lblQueryBuilder = new Label();
            checkedListBox1 = new CheckedListBox();
            pnlHeader.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlSidebar.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // clbColumns
            // 
            clbColumns.FormattingEnabled = true;
            clbColumns.ItemHeight = 23;
            clbColumns.Location = new Point(121, 160);
            clbColumns.Margin = new Padding(6);
            clbColumns.Name = "clbColumns";
            clbColumns.Size = new Size(150, 119);
            clbColumns.TabIndex = 1;
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
            lstTables.BorderStyle = BorderStyle.None;
            lstTables.FormattingEnabled = true;
            lstTables.ItemHeight = 23;
            lstTables.Location = new Point(20, 120);
            lstTables.Name = "lstTables";
            lstTables.Size = new Size(220, 483);
            lstTables.TabIndex = 5;
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
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(224, 224, 224);
            pnlContent.Controls.Add(checkedListBox1);
            pnlContent.Controls.Add(lblColumns);
            pnlContent.Controls.Add(lblQueryBuilder);
            pnlContent.Controls.Add(clbColumns);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(266, 70);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(528, 348);
            pnlContent.TabIndex = 4;
            // 
            // lblColumns
            // 
            lblColumns.AutoSize = true;
            lblColumns.Location = new Point(66, 120);
            lblColumns.Name = "lblColumns";
            lblColumns.Size = new Size(91, 23);
            lblColumns.TabIndex = 6;
            lblColumns.Text = "COLUMNS";
            // 
            // lblQueryBuilder
            // 
            lblQueryBuilder.AutoSize = true;
            lblQueryBuilder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblQueryBuilder.Location = new Point(30, 25);
            lblQueryBuilder.Name = "lblQueryBuilder";
            lblQueryBuilder.Size = new Size(131, 28);
            lblQueryBuilder.TabIndex = 6;
            lblQueryBuilder.Text = "Query Builder";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(281, 96);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(150, 104);
            checkedListBox1.TabIndex = 7;
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
        private ListBox lstTables;
        private TextBox txtSearchTable;
        private Label lblTables;
        private Panel pnlContent;
        private Label lblQueryBuilder;
        private ToolStripSplitButton toolStripSplitButton1;
        private Label lblColumns;
        private CheckedListBox checkedListBox1;
    }
}