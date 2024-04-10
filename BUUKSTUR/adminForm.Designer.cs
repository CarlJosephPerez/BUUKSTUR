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
            dataGridView1 = new DataGridView();
            btnGenerateSalesReport = new Button();
            btnEditInventory = new Button();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 23);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(951, 714);
            dataGridView1.TabIndex = 0;
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
            // btnEditInventory
            // 
            btnEditInventory.FlatStyle = FlatStyle.Flat;
            btnEditInventory.Location = new Point(1171, 23);
            btnEditInventory.Name = "btnEditInventory";
            btnEditInventory.Size = new Size(103, 48);
            btnEditInventory.TabIndex = 6;
            btnEditInventory.Text = "Inventory";
            btnEditInventory.UseVisualStyleBackColor = true;
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
            Controls.Add(btnEditInventory);
            Controls.Add(btnGenerateSalesReport);
            Controls.Add(dataGridView1);
            Name = "adminForm";
            Text = "adminForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnGenerateSalesReport;
        private Button btnEditInventory;
        private Button btnLogout;
    }
}