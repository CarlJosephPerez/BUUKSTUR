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
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.BackgroundColor = Color.FromArgb(255, 192, 128);
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(277, 33);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowTemplate.Height = 25;
            dgvBooks.Size = new Size(349, 316);
            dgvBooks.TabIndex = 0;
            // 
            // storeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(894, 511);
            Controls.Add(dgvBooks);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "storeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BUUKSTUR";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBooks;
    }
}