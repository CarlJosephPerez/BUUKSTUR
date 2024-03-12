namespace BUUKSTUR
{
    partial class BUUKSTUR
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BUUKSTUR));
            tbxUsername = new TextBox();
            tbxPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // tbxUsername
            // 
            tbxUsername.Font = new Font("Tw Cen MT Condensed", 14.25F, FontStyle.Bold);
            tbxUsername.Location = new Point(355, 173);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.PlaceholderText = "USERNAME";
            tbxUsername.Size = new Size(220, 28);
            tbxUsername.TabIndex = 0;
            // 
            // tbxPassword
            // 
            tbxPassword.Font = new Font("Tw Cen MT Condensed", 14.25F, FontStyle.Bold);
            tbxPassword.Location = new Point(355, 220);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.PlaceholderText = "PASSWORD";
            tbxPassword.Size = new Size(220, 28);
            tbxPassword.TabIndex = 1;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Bold);
            btnLogin.ForeColor = SystemColors.ActiveCaption;
            btnLogin.Location = new Point(426, 274);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.FromArgb(255, 192, 128);
            btnRegister.Location = new Point(413, 309);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(102, 29);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Bisque;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Tw Cen MT Condensed Extra Bold", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(183, 60);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(545, 65);
            label1.TabIndex = 4;
            label1.Text = "WELCOME TO BUUKSTUR";
            label1.Click += label1_Click;
            // 
            // BUUKSTUR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(894, 511);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(tbxPassword);
            Controls.Add(tbxUsername);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BUUKSTUR";
            Text = "BUUKSTUR";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxUsername;
        private TextBox tbxPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Label label1;
    }
}
