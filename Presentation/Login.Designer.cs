namespace Presentation;

partial class Login
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        kryptonPictureBox1 = new Krypton.Toolkit.KryptonPictureBox();
        LblTitle = new Krypton.Toolkit.KryptonLabel();
        LblHint = new Krypton.Toolkit.KryptonLabel();
        LblServer = new Krypton.Toolkit.KryptonLabel();
        LblDatabase = new Krypton.Toolkit.KryptonLabel();
        LblAuthentication = new Krypton.Toolkit.KryptonLabel();
        LblUsername = new Krypton.Toolkit.KryptonLabel();
        LblPassword = new Krypton.Toolkit.KryptonLabel();
        CmBxServer = new Krypton.Toolkit.KryptonComboBox();
        CmBxDatabase = new Krypton.Toolkit.KryptonComboBox();
        CmbxAuthentication = new Krypton.Toolkit.KryptonComboBox();
        TxtUsername = new Krypton.Toolkit.KryptonTextBox();
        TxtPassword = new Krypton.Toolkit.KryptonTextBox();
        BtnLogin = new Krypton.Toolkit.KryptonButton();
        BtnCancel = new Krypton.Toolkit.KryptonButton();
        ((System.ComponentModel.ISupportInitialize)kryptonPictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)CmBxServer).BeginInit();
        ((System.ComponentModel.ISupportInitialize)CmBxDatabase).BeginInit();
        ((System.ComponentModel.ISupportInitialize)CmbxAuthentication).BeginInit();
        SuspendLayout();
        // 
        // kryptonPictureBox1
        // 
        kryptonPictureBox1.Image = Properties.Resources.l;
        kryptonPictureBox1.Location = new Point(38, 16);
        kryptonPictureBox1.Name = "kryptonPictureBox1";
        kryptonPictureBox1.Size = new Size(306, 82);
        kryptonPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        kryptonPictureBox1.TabIndex = 0;
        kryptonPictureBox1.TabStop = false;
        // 
        // LblTitle
        // 
        LblTitle.Location = new Point(35, 104);
        LblTitle.Name = "LblTitle";
        LblTitle.Size = new Size(208, 41);
        LblTitle.StateCommon.ShortText.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Regular, GraphicsUnit.Point);
        LblTitle.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
        LblTitle.TabIndex = 14;
        LblTitle.Values.Text = "Database Login";
        // 
        // LblHint
        // 
        LblHint.Location = new Point(35, 136);
        LblHint.Name = "LblHint";
        LblHint.Size = new Size(265, 24);
        LblHint.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
        LblHint.TabIndex = 13;
        LblHint.Values.Text = "Connect to your SQL Server database";
        // 
        // LblServer
        // 
        LblServer.Location = new Point(35, 174);
        LblServer.Name = "LblServer";
        LblServer.Size = new Size(54, 24);
        LblServer.TabIndex = 12;
        LblServer.Values.Text = "Server";
        // 
        // LblDatabase
        // 
        LblDatabase.Location = new Point(35, 237);
        LblDatabase.Name = "LblDatabase";
        LblDatabase.Size = new Size(75, 24);
        LblDatabase.TabIndex = 11;
        LblDatabase.Values.Text = "Database";
        // 
        // LblAuthentication
        // 
        LblAuthentication.Location = new Point(35, 300);
        LblAuthentication.Name = "LblAuthentication";
        LblAuthentication.Size = new Size(112, 24);
        LblAuthentication.TabIndex = 10;
        LblAuthentication.Values.Text = "Authentication";
        // 
        // LblUsername
        // 
        LblUsername.Location = new Point(35, 363);
        LblUsername.Name = "LblUsername";
        LblUsername.Size = new Size(80, 24);
        LblUsername.TabIndex = 9;
        LblUsername.Values.Text = "Username";
        // 
        // LblPassword
        // 
        LblPassword.Location = new Point(35, 426);
        LblPassword.Name = "LblPassword";
        LblPassword.Size = new Size(76, 24);
        LblPassword.TabIndex = 8;
        LblPassword.Values.Text = "Password";
        // 
        // CmBxServer
        // 
        CmBxServer.DropDownWidth = 310;
        CmBxServer.IntegralHeight = false;
        CmBxServer.Location = new Point(35, 198);
        CmBxServer.Name = "CmBxServer";
        CmBxServer.Size = new Size(312, 26);
        CmBxServer.TabIndex = 1;
        // 
        // CmBxDatabase
        // 
        CmBxDatabase.DropDownWidth = 310;
        CmBxDatabase.IntegralHeight = false;
        CmBxDatabase.Location = new Point(35, 261);
        CmBxDatabase.Name = "CmBxDatabase";
        CmBxDatabase.Size = new Size(312, 26);
        CmBxDatabase.TabIndex = 2;
        // 
        // CmbxAuthentication
        // 
        CmbxAuthentication.DropDownWidth = 310;
        CmbxAuthentication.IntegralHeight = false;
        CmbxAuthentication.Items.AddRange(new object[] { "Windows Authentication", "SQL Server Authentication" });
        CmbxAuthentication.Location = new Point(35, 324);
        CmbxAuthentication.Name = "CmbxAuthentication";
        CmbxAuthentication.Size = new Size(312, 26);
        CmbxAuthentication.TabIndex = 3;
        CmbxAuthentication.SelectedIndexChanged += CmbxAuthentication_SelectedIndexChanged;
        // 
        // TxtUsername
        // 
        TxtUsername.Location = new Point(35, 387);
        TxtUsername.Name = "TxtUsername";
        TxtUsername.Size = new Size(312, 27);
        TxtUsername.TabIndex = 4;
        // 
        // TxtPassword
        // 
        TxtPassword.Location = new Point(35, 450);
        TxtPassword.Name = "TxtPassword";
        TxtPassword.PasswordChar = '●';
        TxtPassword.Size = new Size(312, 27);
        TxtPassword.TabIndex = 5;
        TxtPassword.UseSystemPasswordChar = true;
        // 
        // BtnLogin
        // 
        BtnLogin.Location = new Point(35, 495);
        BtnLogin.Name = "BtnLogin";
        BtnLogin.Size = new Size(150, 36);
        BtnLogin.TabIndex = 6;
        BtnLogin.Values.Text = "Connect";
        BtnLogin.Click += BtnLogin_Click;
        // 
        // BtnCancel
        // 
        BtnCancel.DialogResult = DialogResult.Cancel;
        BtnCancel.Location = new Point(197, 495);
        BtnCancel.Name = "BtnCancel";
        BtnCancel.Size = new Size(150, 36);
        BtnCancel.TabIndex = 7;
        BtnCancel.Values.Text = "Cancel";
        // 
        // Connect
        // 
        AcceptButton = BtnLogin;
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = BtnCancel;
        ClientSize = new Size(382, 553);
        Controls.Add(BtnCancel);
        Controls.Add(BtnLogin);
        Controls.Add(TxtPassword);
        Controls.Add(LblPassword);
        Controls.Add(TxtUsername);
        Controls.Add(LblUsername);
        Controls.Add(CmbxAuthentication);
        Controls.Add(LblAuthentication);
        Controls.Add(CmBxDatabase);
        Controls.Add(LblDatabase);
        Controls.Add(CmBxServer);
        Controls.Add(LblServer);
        Controls.Add(LblHint);
        Controls.Add(LblTitle);
        Controls.Add(kryptonPictureBox1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Login";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Business Intelligence - Login";
        Load += Login_Load;
        ((System.ComponentModel.ISupportInitialize)kryptonPictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)CmBxServer).EndInit();
        ((System.ComponentModel.ISupportInitialize)CmBxDatabase).EndInit();
        ((System.ComponentModel.ISupportInitialize)CmbxAuthentication).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Krypton.Toolkit.KryptonPictureBox kryptonPictureBox1;
    private Krypton.Toolkit.KryptonLabel LblTitle;
    private Krypton.Toolkit.KryptonLabel LblHint;
    private Krypton.Toolkit.KryptonLabel LblServer;
    private Krypton.Toolkit.KryptonLabel LblDatabase;
    private Krypton.Toolkit.KryptonLabel LblAuthentication;
    private Krypton.Toolkit.KryptonLabel LblUsername;
    private Krypton.Toolkit.KryptonLabel LblPassword;
    private Krypton.Toolkit.KryptonComboBox CmBxServer;
    private Krypton.Toolkit.KryptonComboBox CmBxDatabase;
    private Krypton.Toolkit.KryptonComboBox CmbxAuthentication;
    private Krypton.Toolkit.KryptonTextBox TxtUsername;
    private Krypton.Toolkit.KryptonTextBox TxtPassword;
    private Krypton.Toolkit.KryptonButton BtnLogin;
    private Krypton.Toolkit.KryptonButton BtnCancel;
}