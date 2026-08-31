namespace ControlLibrary
{
    partial class Input
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputControl = new System.Windows.Forms.TextBox();
            this.labelControl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputControl
            // 
            this.InputControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InputControl.Location = new System.Drawing.Point(0, 30);
            this.InputControl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.InputControl.Name = "InputControl";
            this.InputControl.Size = new System.Drawing.Size(230, 30);
            this.InputControl.TabIndex = 0;
            this.InputControl.TextChanged += new System.EventHandler(this.InputControl_TextChanged);
            // 
            // labelControl
            // 
            this.labelControl.AutoSize = true;
            this.labelControl.Location = new System.Drawing.Point(5, 0);
            this.labelControl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(56, 22);
            this.labelControl.TabIndex = 1;
            this.labelControl.Text = "Name";
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl);
            this.Controls.Add(this.InputControl);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Input";
            this.Size = new System.Drawing.Size(230, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputControl;
        private System.Windows.Forms.Label labelControl;
    }
}
