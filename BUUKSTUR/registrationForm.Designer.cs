namespace BUUKSTUR
{
    partial class registrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registrationForm));
            tbxUsername = new TextBox();
            tbxPassword = new TextBox();
            btnRegister = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // tbxUsername
            // 
            tbxUsername.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbxUsername.Location = new Point(97, 42);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.PlaceholderText = "USERNAME";
            tbxUsername.Size = new Size(220, 29);
            tbxUsername.TabIndex = 2;
            tbxUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // tbxPassword
            // 
            tbxPassword.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbxPassword.Location = new Point(97, 89);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.PlaceholderText = "PASSWORD";
            tbxPassword.Size = new Size(220, 29);
            tbxPassword.TabIndex = 3;
            tbxPassword.TextAlign = HorizontalAlignment.Center;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.FromArgb(255, 192, 128);
            btnRegister.Location = new Point(155, 137);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(102, 29);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.FromArgb(255, 128, 128);
            btnCancel.Location = new Point(155, 172);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "CANCEL";
            btnCancel.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // registrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(417, 231);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(tbxUsername);
            Controls.Add(tbxPassword);
            MaximizeBox = false;
            Name = "registrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxUsername;
        private TextBox tbxPassword;
        private Button btnRegister;
        private Button btnCancel;
    }
}