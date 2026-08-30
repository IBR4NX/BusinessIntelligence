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
            components = new System.ComponentModel.Container();
            CmBxServer = new Krypton.Toolkit.KryptonComboBox();
            CmbxDatabase = new Krypton.Toolkit.KryptonComboBox();
            kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            kryptonPictureBox1 = new Krypton.Toolkit.KryptonPictureBox();
            kryptonSeparator1 = new Krypton.Toolkit.KryptonSeparator();
            kryptonScrollBar1 = new Krypton.Toolkit.KryptonScrollBar();
            ((System.ComponentModel.ISupportInitialize)CmBxServer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CmbxDatabase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kryptonPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kryptonSeparator1).BeginInit();
            SuspendLayout();
            // 
            // CmBxServer
            // 
            CmBxServer.DropDownWidth = 210;
            CmBxServer.IntegralHeight = false;
            CmBxServer.Location = new Point(102, 304);
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
            // kryptonButton1
            // 
            kryptonButton1.Location = new Point(72, 371);
            kryptonButton1.Name = "kryptonButton1";
            kryptonButton1.Size = new Size(112, 31);
            kryptonButton1.TabIndex = 3;
            kryptonButton1.Values.Text = "kryptonButton1";
            // 
            // kryptonPictureBox1
            // 
            kryptonPictureBox1.ErrorImage = Properties.Resources.logo_2;
            kryptonPictureBox1.Image = Properties.Resources.l;
            kryptonPictureBox1.InitialImage = Properties.Resources.logo_2;
            kryptonPictureBox1.Location = new Point(12, 12);
            kryptonPictureBox1.Name = "kryptonPictureBox1";
            kryptonPictureBox1.Size = new Size(358, 103);
            kryptonPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            kryptonPictureBox1.TabIndex = 4;
            kryptonPictureBox1.TabStop = false;
            // 
            // kryptonSeparator1
            // 
            kryptonSeparator1.Location = new Point(72, 106);
            kryptonSeparator1.Name = "kryptonSeparator1";
            kryptonSeparator1.Size = new Size(10, 315);
            kryptonSeparator1.TabIndex = 5;
            // 
            // kryptonScrollBar1
            // 
            kryptonScrollBar1.BorderColor = Color.FromArgb(93, 140, 201);
            kryptonScrollBar1.DisabledBorderColor = Color.Gray;
            kryptonScrollBar1.Location = new Point(351, 138);
            kryptonScrollBar1.Name = "kryptonScrollBar1";
            kryptonScrollBar1.Opacity = 1D;
            kryptonScrollBar1.Size = new Size(19, 250);
            kryptonScrollBar1.TabIndex = 6;
            kryptonScrollBar1.Text = "kryptonScrollBar1";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 553);
            Controls.Add(kryptonScrollBar1);
            Controls.Add(kryptonSeparator1);
            Controls.Add(kryptonPictureBox1);
            Controls.Add(kryptonButton1);
            Controls.Add(CmbxDatabase);
            Controls.Add(CmBxServer);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)CmBxServer).EndInit();
            ((System.ComponentModel.ISupportInitialize)CmbxDatabase).EndInit();
            ((System.ComponentModel.ISupportInitialize)kryptonPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)kryptonSeparator1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonThemeComboBox kryptonThemeComboBox1;
        private Krypton.Toolkit.KryptonComboBox CmBxServer;
        private Krypton.Toolkit.KryptonComboBox CmbxDatabase;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonPictureBox kryptonPictureBox1;
        private Krypton.Toolkit.KryptonSeparator kryptonSeparator1;
        private Krypton.Toolkit.KryptonScrollBar kryptonScrollBar1;
    }
}