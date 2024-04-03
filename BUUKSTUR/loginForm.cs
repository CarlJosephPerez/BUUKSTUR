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
        public void ResetForm()
        {
            
            tbxUsername.Clear();
            tbxPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text; 

            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\Documents\OOP2\buuksturr.mdb"";";
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
                            this.Hide();
                            storeForm storeForm = new storeForm();
                            storeForm.Show();
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
            Program.CurrentUserId = RetrieveUserId(tbxUsername.Text);
        }
        private int RetrieveUserId(string username)
        {
            int userId = 0; // Default to 0 or an appropriate 'not found' value
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\Documents\OOP2\buuksturr.mdb"";";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sql = "SELECT UserID FROM Accounts WHERE Username = ?";
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("?", username);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            userId = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            return userId;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            registrationForm regForm = new registrationForm();
            regForm.Show();
        }

        
    }
}
