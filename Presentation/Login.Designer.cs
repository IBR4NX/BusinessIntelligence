namespace Presentation
{
    partial class Login
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
            CmBxServer = new Krypton.Toolkit.KryptonComboBox();
            CmbxDatabase = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)CmBxServer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CmbxDatabase).BeginInit();
            SuspendLayout();
            // 
            // CmBxServer
            // 
            CmBxServer.DropDownWidth = 210;
            CmBxServer.IntegralHeight = false;
            CmBxServer.Location = new Point(72, 89);
            CmBxServer.Name = "CmBxServer";
            CmBxServer.Size = new Size(210, 26);
            CmBxServer.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            CmBxServer.TabIndex = 1;
            CmBxServer.Text = "kryptonComboBox1";
            // 
            // CmbxDatabase
            // 
            CmbxDatabase.DropDownWidth = 210;
            CmbxDatabase.IntegralHeight = false;
            CmbxDatabase.Location = new Point(72, 150);
            CmbxDatabase.Name = "CmbxDatabase";
            CmbxDatabase.Size = new Size(210, 26);
            CmbxDatabase.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            CmbxDatabase.TabIndex = 2;
            CmbxDatabase.Text = "kryptonComboBox2";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 553);
            Controls.Add(CmbxDatabase);
            Controls.Add(CmBxServer);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)CmBxServer).EndInit();
            ((System.ComponentModel.ISupportInitialize)CmbxDatabase).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonThemeComboBox kryptonThemeComboBox1;
        private Krypton.Toolkit.KryptonComboBox CmBxServer;
        private Krypton.Toolkit.KryptonComboBox CmbxDatabase;
    }
}