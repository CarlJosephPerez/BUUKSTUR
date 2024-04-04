using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BUUKSTUR
{
    public partial class registrationForm : Form
    {
        public registrationForm()
        {
            InitializeComponent();

            this.AcceptButton = btnRegister;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            

            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\source\repos\BUUKSTUR\BUUKSTUR\buuksturr.mdb"";";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sql = "INSERT INTO Accounts ([Username], [Password]) VALUES (?, ?)";
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.Add("?", OleDbType.VarChar).Value = tbxUsername.Text;
                    command.Parameters.Add("?", OleDbType.VarChar).Value = tbxPassword.Text;


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Registration successful.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                        this.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
