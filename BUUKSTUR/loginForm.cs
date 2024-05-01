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
        private bool isPasswordShown = false;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\source\repos\BUUKSTUR\BUUKSTUR\buuksturr.mdb"";";
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
                            Program.CurrentUserId = RetrieveUserId(tbxUsername.Text);

                            if (Program.CurrentUserId == 1)
                            {
                                this.Hide();
                                adminForm adminForm = new adminForm();
                                adminForm.Closed += (s, args) => this.Close();
                                adminForm.Show();
                            }
                            else
                            {
                                this.Hide();
                                storeForm storeForm = new storeForm();
                                storeForm.Closed += (s, args) => this.Close();
                                storeForm.Show();
                            }
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
            int userId = 0; 
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\source\repos\BUUKSTUR\BUUKSTUR\buuksturr.mdb"";";
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            isPasswordShown = !isPasswordShown;
            tbxPassword.UseSystemPasswordChar = !isPasswordShown;

            btnShow.Text = isPasswordShown ? "HIDE" : "SHOW";
        }
    }
}
