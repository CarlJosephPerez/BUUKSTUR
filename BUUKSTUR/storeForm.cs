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
    public partial class storeForm : Form
    {
        private bool loggingOut = false;
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        private BindingList<CartItem> cartItems = new BindingList<CartItem>();
        public storeForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(storeForm_Load);
            SetupBooksDataGridView();
            dgvCart.AutoGenerateColumns = true;
            dgvCart.DataSource = cartItems;
            this.dgvBooks.CellContentClick += new DataGridViewCellEventHandler(this.dgvBooks_CellContentClick);
            this.btnCheckout.Click += new EventHandler(this.btnCheckout_Click);

        }
        private void SetupBooksDataGridView()
        {
            DataGridViewButtonColumn addToCartButton = new DataGridViewButtonColumn
            {
                Name = "addToCartButton",
                HeaderText = "Add to Cart",
                Text = "Add",
                UseColumnTextForButtonValue = true
            };
            dgvBooks.Columns.Add(addToCartButton);
        }
        private void LoadBooks()
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"C:\\Users\\Administrator\\Documents\\OOP2\\buuksturr.mdb\"";
            string query = "SELECT * FROM Inventory";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
            {
                DataTable books = new DataTable();
                adapter.Fill(books);
                dgvBooks.DataSource = books;
            }
        }

        private void storeForm_Load(object sender, EventArgs e)
        {
            LoadBooks(); // Call a method to load the books
        }

        public class CartItem
        {
            public int BookID { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
        

        private void AddToCart(int bookId, string title, decimal price)
        {
            var item = cartItems.FirstOrDefault(i => i.BookID == bookId);
            if (item != null)
            {
                item.Quantity += 1;
            }
            else
            {
                cartItems.Add(new CartItem { BookID = bookId, Title = title, Price = price, Quantity = 1 });
            }
        }

        private void UpdateCartUI()
        {
            //dgvCart.DataSource = typeof(List<>);
            dgvCart.DataSource = cartItems;
            dgvCart.Refresh();
        }
        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBooks.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var row = dgvBooks.Rows[e.RowIndex];
                int bookId = Convert.ToInt32(row.Cells["BOOKID"].Value);
                string title = row.Cells["Title"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Price($)"].Value);
                AddToCart(bookId, title, price);
            }
        }
        private int GetCurrentUserId()
        {
            return Program.CurrentUserId; // This will now return the ID of the currently logged-in user
        }


        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to checkout these items?",
                                                     "Confirm Checkout",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Assuming you have a method to get the current logged-in user's ID
                        int userId = GetCurrentUserId();
                        CompleteOrder(cartItems.ToList(), userId);

                        cartItems.Clear();
                        UpdateCartUI();
                        MessageBox.Show("Checkout successful. Your order has been placed.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while processing your order: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Your cart is empty.");
            }
        }
        private void CompleteOrder(List<CartItem> cartItems, int userId)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"C:\\Users\\Administrator\\Documents\\OOP2\\buuksturr.mdb\"";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                OleDbTransaction transaction = connection.BeginTransaction();   

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    // Insert into Orders table
                    command.CommandText = "INSERT INTO Orders (USERID, OrderDate, TotalPrice) VALUES (?, ?, ?)";
                    command.Parameters.Add(new OleDbParameter("@UserID", OleDbType.Integer)).Value = userId;
                    command.Parameters.Add(new OleDbParameter("@OrderDate", OleDbType.Date)).Value = DateTime.Now;
                    command.Parameters.Add(new OleDbParameter("@TotalPrice", OleDbType.Currency)).Value = cartItems.Sum(item => item.Price * item.Quantity);
                    command.ExecuteNonQuery();

                    // Get the last inserted order's ID
                    command.CommandText = "SELECT @@IDENTITY";
                    int orderId = (int)command.ExecuteScalar();

                    // Insert each cart item into OrderDetails table
                    foreach (var item in cartItems)
                    {
                        command.CommandText = "INSERT INTO OrderDetails (OrderID, BOOKID, Quantity, PriceAtPurchase) VALUES (?, ?, ?, ?)";
                        command.Parameters.Clear();
                        command.Parameters.Add(new OleDbParameter("@OrderID", OleDbType.Integer)).Value = orderId;
                        command.Parameters.Add(new OleDbParameter("@BookID", OleDbType.Integer)).Value = item.BookID;
                        command.Parameters.Add(new OleDbParameter("@Quantity", OleDbType.Integer)).Value = item.Quantity;
                        command.Parameters.Add(new OleDbParameter("@PriceAtPurchase", OleDbType.Currency)).Value = item.Price;
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        MessageBox.Show("A severe error occurred during transaction rollback. Please contact support.");
                    }
                    MessageBox.Show("An error occurred while processing your order: " + ex.Message);
                    throw; // Rethrow the original exception to be caught by the outer try-catch
                }
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            loggingOut = true;
            this.Hide();
            Program.LoginForm.ResetForm();
            Program.LoginForm.Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (loggingOut)
            {
                e.Cancel = true;
                this.Hide();
                loggingOut = false;
                Program.LoginForm.Show();
            }
            else
            {
                base.OnFormClosing(e);
                Application.Exit();
            }
        }
        private void StoreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loggingOut)
            {
                Application.Exit();
            }
        }
        


    }
}
