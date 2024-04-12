namespace BUUKSTUR
{
    partial class adminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminForm));
            dgvBooks = new DataGridView();
            btnGenerateSalesReport = new Button();
            btnAddBooks = new Button();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.FromArgb(255, 192, 128);
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(12, 23);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowTemplate.Height = 25;
            dgvBooks.Size = new Size(951, 714);
            dgvBooks.TabIndex = 0;
            // 
            // btnGenerateSalesReport
            // 
            btnGenerateSalesReport.FlatStyle = FlatStyle.Flat;
            btnGenerateSalesReport.Location = new Point(1011, 23);
            btnGenerateSalesReport.Name = "btnGenerateSalesReport";
            btnGenerateSalesReport.Size = new Size(103, 48);
            btnGenerateSalesReport.TabIndex = 5;
            btnGenerateSalesReport.Text = "Sales Report";
            btnGenerateSalesReport.UseVisualStyleBackColor = true;
            btnGenerateSalesReport.Click += btnGenerateSalesReport_Click;
            // 
            // btnAddBooks
            // 
            btnAddBooks.FlatStyle = FlatStyle.Flat;
            btnAddBooks.Location = new Point(1171, 23);
            btnAddBooks.Name = "btnAddBooks";
            btnAddBooks.Size = new Size(103, 48);
            btnAddBooks.TabIndex = 6;
            btnAddBooks.Text = "Add Books";
            btnAddBooks.UseVisualStyleBackColor = true;
            btnAddBooks.Click += btnAddBooks_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1214, 681);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(144, 56);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // adminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1370, 749);
            Controls.Add(btnLogout);
            Controls.Add(btnAddBooks);
            Controls.Add(btnGenerateSalesReport);
            Controls.Add(dgvBooks);
            Name = "adminForm";
            Text = "adminForm";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBooks;
        private Button btnGenerateSalesReport;
        private Button btnAddBooks;
        private Button btnLogout;
    }
}