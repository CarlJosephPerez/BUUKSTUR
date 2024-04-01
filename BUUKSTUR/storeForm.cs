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
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Administrator\\Documents\\OOP2\\buuksturr.mdb\"";
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
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                AddToCart(bookId, title, price);
            }
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
                    cartItems.Clear();
                    UpdateCartUI();

                    MessageBox.Show("Checkout successful.");
                }
            }
            else
            {
                MessageBox.Show("Your cart is empty.");
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
