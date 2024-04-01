namespace BUUKSTUR
{
    partial class storeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(storeForm));
            dgvBooks = new DataGridView();
            btnLogout = new Button();
            dgvCart = new DataGridView();
            btnCheckout = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.BackgroundColor = Color.FromArgb(255, 192, 128);
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(61, 35);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowTemplate.Height = 25;
            dgvBooks.Size = new Size(585, 330);
            dgvBooks.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(848, 501);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 33);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = Color.FromArgb(255, 192, 128);
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(699, 35);
            dgvCart.Name = "dgvCart";
            dgvCart.RowTemplate.Height = 25;
            dgvCart.Size = new Size(206, 330);
            dgvCart.TabIndex = 3;
            // 
            // btnCheckout
            // 
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Location = new Point(761, 383);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(85, 33);
            btnCheckout.TabIndex = 4;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            // 
            // storeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(935, 546);
            Controls.Add(btnCheckout);
            Controls.Add(dgvCart);
            Controls.Add(btnLogout);
            Controls.Add(dgvBooks);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "storeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BUUKSTUR";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBooks;
        private Button btnLogout;
        private DataGridView dgvCart;
        private Button btnCheckout;
    }
}