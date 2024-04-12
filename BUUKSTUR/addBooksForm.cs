using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUUKSTUR
{
    public partial class addBooksForm : Form
    {
        public addBooksForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxBookTitle.Clear();
            tbxAuthor.Clear();
            tbxYear.Clear();
            tbxGenre.Clear();
            tbxPrice.Clear();
            tbxStock.Clear();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxBookTitle.Text) ||
        string.IsNullOrWhiteSpace(tbxAuthor.Text) ||
        string.IsNullOrWhiteSpace(tbxPrice.Text) ||
        string.IsNullOrWhiteSpace(tbxStock.Text) ||
        string.IsNullOrWhiteSpace(tbxYear.Text) ||
        string.IsNullOrWhiteSpace(tbxGenre.Text))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            // Additional validation for price and stock to ensure they are numeric
            if (!decimal.TryParse(tbxPrice.Text, out decimal price) || !int.TryParse(tbxStock.Text, out int stock))
            {
                MessageBox.Show("Price and Stock must be numeric.");
                return;
            }

            // Save the book information to the database
            try
            {
                string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\source\repos\BUUKSTUR\BUUKSTUR\buuksturr.mdb"";";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Inventory ([Title], [Author], [Year Published], [Genre(s)], [Price($)], [Stock]) VALUES (?, ?, ?, ?, ?, ?)";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", tbxBookTitle.Text);
                        command.Parameters.AddWithValue("?", tbxAuthor.Text);
                        command.Parameters.AddWithValue("?", tbxYear.Text);
                        command.Parameters.AddWithValue("?", tbxGenre.Text);
                        command.Parameters.AddWithValue("?", price);
                        command.Parameters.AddWithValue("?", stock);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Book added successfully!");
                        this.DialogResult = DialogResult.OK;
                        btnClear.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add the book: " + ex.Message);
            }
        }
    }

}
