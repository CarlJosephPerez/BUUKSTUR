using System.Data.OleDb;
using System.Data.SqlClient;
namespace BUUKSTUR
{
    public partial class BUUKSTUR : Form
    {
        public BUUKSTUR()
        {
            InitializeComponent();

            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text; 

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\Administrator\Documents\OOP2\buuksturr.mdb"";";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sql = "SELECT COUNT(1) FROM Accounts WHERE Username = ? AND Password = ?";
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("?", username);
                    command.Parameters.AddWithValue("?", password);

                    try
                    {
                        connection.Open();
                        int userCount = (int)command.ExecuteScalar();
                        if (userCount > 0)
                        {
                            MessageBox.Show("Login successful.");

                            storeForm storeForm = new storeForm();
                            storeForm.Show();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Login failed. Please check your username and password.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            registrationForm regForm = new registrationForm();
            regForm.Show();
        }

        
    }
}
