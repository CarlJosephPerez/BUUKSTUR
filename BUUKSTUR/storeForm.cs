using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
            //this.Bounds = Screen.PrimaryScreen.Bounds;

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
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"C:\\Users\\Administrator\\source\\repos\\BUUKSTUR\\BUUKSTUR\\buuksturr.mdb\";";
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
            LoadBooks();
        }
        public class CartItem : INotifyPropertyChanged
        {
            private string title;
            private int quantity;
            private decimal price;
            public int BookID;
            public string Title
            {
                get => title;
                set
                {
                    if (title != value)
                    {
                        title = value;
                        OnPropertyChanged(nameof(Title));
                    }
                }
            }

            public int Quantity
            {
                get => quantity;
                set
                {
                    if (quantity != value)
                    {
                        quantity = value;
                        OnPropertyChanged(nameof(Quantity));
                    }
                }
            }

            public decimal Price
            {
                get => price;
                set
                {
                    if (price != value)
                    {
                        price = value;
                        OnPropertyChanged(nameof(Price));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            return Program.CurrentUserId;
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
                        int userId = GetCurrentUserId();
                        string receipt = CompleteOrder(cartItems.ToList(), userId);


                        cartItems.Clear();
                        UpdateCartUI();
                        MessageBox.Show(receipt, "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private string CompleteOrder(List<CartItem> cartItems, int userId)
        {
            string username = GetUsernameByUserId(userId);
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"C:\\Users\\Administrator\\source\\repos\\BUUKSTUR\\BUUKSTUR\\buuksturr.mdb\";";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                OleDbTransaction transaction = connection.BeginTransaction();

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO Orders (USERID, [Username], OrderDate, TotalPrice ) VALUES (?, ?, ?, ?)";
                    command.Parameters.Add(new OleDbParameter("@UserID", OleDbType.Integer)).Value = userId;
                    command.Parameters.Add(new OleDbParameter("@Username", OleDbType.VarChar)).Value = username;
                    command.Parameters.Add(new OleDbParameter("@OrderDate", OleDbType.Date)).Value = DateTime.Now;
                    command.Parameters.Add(new OleDbParameter("@TotalPrice", OleDbType.Currency)).Value = cartItems.Sum(item => item.Price * item.Quantity);

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT @@IDENTITY";
                    int orderId = (int)command.ExecuteScalar();
                    foreach (var item in cartItems)
                    {
                        command.CommandText = "UPDATE Inventory SET Stock = Stock - ? WHERE BookID = ?";
                        command.Parameters.Clear();
                        command.Parameters.Add(new OleDbParameter("@Quantity", OleDbType.Integer)).Value = item.Quantity;
                        command.Parameters.Add(new OleDbParameter("@BookID", OleDbType.Integer)).Value = item.BookID;

                        // Execute the update command
                        command.ExecuteNonQuery();
                    }
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
                    throw;
                }
            }
            StringBuilder receiptBuilder = new StringBuilder();
            receiptBuilder.AppendLine("Receipt for Your Order:");
            receiptBuilder.AppendLine("--------------------------");

            foreach (var item in cartItems)
            {
                receiptBuilder.AppendLine($"Qty: {item.Quantity}");
                receiptBuilder.AppendLine($"Item: {item.Title}");
                receiptBuilder.AppendLine($"Price: {item.Price:C}");
                receiptBuilder.AppendLine("--------------------------");
            }

            decimal total = cartItems.Sum(item => item.Price * item.Quantity);
            receiptBuilder.AppendLine($"Total: {total:C}");
            receiptBuilder.AppendLine("Thank you for your purchase!");
            dgvBooks.Refresh();

            GeneratePdfReceipt(cartItems, userId);

            return receiptBuilder.ToString();
        }
        private void GeneratePdfReceipt(List<CartItem> cartItems, int userId)
        {
            string customPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyAppFiles");
            if (!Directory.Exists(customPath))
                Directory.CreateDirectory(customPath);
            string pdfPath = Path.Combine(customPath, $"Receipt_{DateTime.Now:yyyyMMddHHmmss}.pdf");
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
            document.Open();

            document.Add(new Paragraph("Receipt for Your Order"));
            document.Add(new Paragraph("--------------------------"));

            foreach (var item in cartItems)
            {
                document.Add(new Paragraph($"Qty: {item.Quantity} Item: {item.Title} Price: {item.Price:C}"));
                document.Add(new Paragraph("--------------------------"));
            }

            decimal total = cartItems.Sum(item => item.Price * item.Quantity);
            document.Add(new Paragraph($"Total: {total:C}"));
            document.Add(new Paragraph("Thank you for your purchase!"));

            document.Close();

        }
        private string GetUsernameByUserId(int userId)
        {
            string username = "";
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\source\repos\BUUKSTUR\BUUKSTUR\buuksturr.mdb"";";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT Username FROM Accounts WHERE UserID = ?";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add(new OleDbParameter("@UserID", OleDbType.Integer)).Value = userId;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            username = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            return username;
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
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                int selectedRowIndex = dgvCart.CurrentCell.RowIndex;
                cartItems.RemoveAt(selectedRowIndex);
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = tbxSearch.Text.ToLower();
            string searchType = cbxSearchCriteria.SelectedItem.ToString();
            LoadBooks(searchQuery, searchType);
        }
        private void LoadBooks(string searchQuery = "", string searchType = "Title")
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\source\repos\BUUKSTUR\BUUKSTUR\buuksturr.mdb"";";
            string query = $"SELECT * FROM Inventory WHERE [{searchType}] LIKE ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("?", "%" + searchQuery + "%");

                DataTable books = new DataTable();
                adapter.Fill(books);
                dgvBooks.DataSource = books;
            }
        }
    }
}