namespace BUUKSTUR
{
    partial class addBooksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addBooksForm));
            tbxBookTitle = new TextBox();
            tbxAuthor = new TextBox();
            lblInfo = new Label();
            tbxYear = new TextBox();
            tbxGenre = new TextBox();
            tbxPrice = new TextBox();
            tbxStock = new TextBox();
            btnClear = new Button();
            btnSubmit = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // tbxBookTitle
            // 
            tbxBookTitle.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbxBookTitle.Location = new Point(115, 30);
            tbxBookTitle.Name = "tbxBookTitle";
            tbxBookTitle.PlaceholderText = "TITLE";
            tbxBookTitle.Size = new Size(188, 26);
            tbxBookTitle.TabIndex = 0;
            // 
            // tbxAuthor
            // 
            tbxAuthor.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbxAuthor.Location = new Point(115, 72);
            tbxAuthor.Name = "tbxAuthor";
            tbxAuthor.PlaceholderText = "AUTHOR";
            tbxAuthor.Size = new Size(188, 26);
            tbxAuthor.TabIndex = 1;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblInfo.ForeColor = Color.Black;
            lblInfo.Location = new Point(21, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(88, 18);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "Book Info:";
            // 
            // tbxYear
            // 
            tbxYear.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbxYear.Location = new Point(115, 115);
            tbxYear.Name = "tbxYear";
            tbxYear.PlaceholderText = "YEAR PUBLISHED";
            tbxYear.Size = new Size(188, 26);
            tbxYear.TabIndex = 3;
            // 
            // tbxGenre
            // 
            tbxGenre.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbxGenre.Location = new Point(115, 160);
            tbxGenre.Name = "tbxGenre";
            tbxGenre.PlaceholderText = "GENRE(S)";
            tbxGenre.Size = new Size(188, 26);
            tbxGenre.TabIndex = 4;
            // 
            // tbxPrice
            // 
            tbxPrice.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbxPrice.Location = new Point(115, 205);
            tbxPrice.Name = "tbxPrice";
            tbxPrice.PlaceholderText = "PRICE($)";
            tbxPrice.Size = new Size(188, 26);
            tbxPrice.TabIndex = 5;
            // 
            // tbxStock
            // 
            tbxStock.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbxStock.Location = new Point(112, 252);
            tbxStock.Name = "tbxStock";
            tbxStock.PlaceholderText = "AMMOUNT";
            tbxStock.Size = new Size(188, 26);
            tbxStock.TabIndex = 6;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(37, 305);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(98, 39);
            btnClear.TabIndex = 7;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSubmit.Location = new Point(156, 305);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(98, 39);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "SUBMIT";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(277, 305);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 39);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // addBooksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(413, 368);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(btnClear);
            Controls.Add(tbxStock);
            Controls.Add(tbxPrice);
            Controls.Add(tbxGenre);
            Controls.Add(tbxYear);
            Controls.Add(lblInfo);
            Controls.Add(tbxAuthor);
            Controls.Add(tbxBookTitle);
            Name = "addBooksForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add A Book";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxBookTitle;
        private TextBox tbxAuthor;
        private Label lblInfo;
        private TextBox tbxYear;
        private TextBox tbxGenre;
        private TextBox tbxPrice;
        private TextBox tbxStock;
        private Button btnClear;
        private Button btnSubmit;
        private Button btnCancel;
    }
}