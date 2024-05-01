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
            btnRemove = new Button();
            btnSearch = new Button();
            tbxSearch = new TextBox();
            cbxSearchCriteria = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.FromArgb(255, 192, 128);
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(39, 121);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowTemplate.Height = 25;
            dgvBooks.Size = new Size(832, 465);
            dgvBooks.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1175, 681);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(144, 56);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = Color.FromArgb(255, 192, 128);
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(931, 12);
            dgvCart.Name = "dgvCart";
            dgvCart.RowTemplate.Height = 25;
            dgvCart.Size = new Size(359, 454);
            dgvCart.TabIndex = 3;
            // 
            // btnCheckout
            // 
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCheckout.Location = new Point(1006, 482);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(103, 48);
            btnCheckout.TabIndex = 4;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnRemove
            // 
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemove.Location = new Point(1115, 482);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(103, 48);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(437, 51);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(109, 36);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tbxSearch
            // 
            tbxSearch.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbxSearch.Location = new Point(155, 53);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.PlaceholderText = "SEARCH";
            tbxSearch.Size = new Size(276, 29);
            tbxSearch.TabIndex = 7;
            // 
            // cbxSearchCriteria
            // 
            cbxSearchCriteria.FormattingEnabled = true;
            cbxSearchCriteria.Items.AddRange(new object[] { "Title", "Author", "Genre(s)" });
            cbxSearchCriteria.Location = new Point(552, 59);
            cbxSearchCriteria.Name = "cbxSearchCriteria";
            cbxSearchCriteria.Size = new Size(121, 23);
            cbxSearchCriteria.TabIndex = 8;
            cbxSearchCriteria.Text = "Title";
            // 
            // storeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1370, 749);
            Controls.Add(cbxSearchCriteria);
            Controls.Add(tbxSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnRemove);
            Controls.Add(btnCheckout);
            Controls.Add(dgvCart);
            Controls.Add(btnLogout);
            Controls.Add(dgvBooks);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "storeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BUUKSTUR";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBooks;
        private Button btnLogout;
        private DataGridView dgvCart;
        private Button btnCheckout;
        private Button btnRemove;
        private Button btnSearch;
        private TextBox tbxSearch;
        private ComboBox cbxSearchCriteria;
    }
}