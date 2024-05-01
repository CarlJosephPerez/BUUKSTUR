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
            btnShow = new Button();
            SuspendLayout();
            // 
            // tbxUsername
            // 
            tbxUsername.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbxUsername.Location = new Point(346, 190);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.PlaceholderText = "USERNAME";
            tbxUsername.Size = new Size(220, 29);
            tbxUsername.TabIndex = 0;
            tbxUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // tbxPassword
            // 
            tbxPassword.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbxPassword.Location = new Point(345, 239);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.PlaceholderText = "PASSWORD";
            tbxPassword.Size = new Size(220, 29);
            tbxPassword.TabIndex = 1;
            tbxPassword.TextAlign = HorizontalAlignment.Center;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = SystemColors.ActiveCaption;
            btnLogin.Location = new Point(416, 274);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.FromArgb(255, 192, 128);
            btnRegister.Location = new Point(404, 309);
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
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Lucida Calligraphy", 39.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(29, 70);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(823, 68);
            label1.TabIndex = 4;
            label1.Text = "WELCOME TO BUUKSTUR";
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.Transparent;
            btnShow.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnShow.ForeColor = Color.DimGray;
            btnShow.Location = new Point(571, 238);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(68, 29);
            btnShow.TabIndex = 5;
            btnShow.Text = "SHOW";
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click;
            // 
            // BUUKSTUR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(894, 511);
            Controls.Add(btnShow);
            Controls.Add(tbxUsername);
            Controls.Add(tbxPassword);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "BUUKSTUR";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button btnShow;
    }
}
