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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace BUUKSTUR
{
    public partial class adminForm : Form
    {
        private bool loggingOut = false;
        public adminForm()
        {
            InitializeComponent();
            LoadBooks();
        }
        private void GenerateAndDisplaySalesReport()
        {   
            StringBuilder reportBuilder = new StringBuilder();
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\source\repos\BUUKSTUR\BUUKSTUR\buuksturr.mdb"";";

            string query = @"
        SELECT Orders.OrderID, Orders.OrderDate, SUM(OrderDetails.Quantity * OrderDetails.PriceAtPurchase) AS TotalSaleAmount
        FROM Orders
        INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
        GROUP BY Orders.OrderID, Orders.OrderDate
        ORDER BY Orders.OrderDate DESC";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    reportBuilder.AppendLine("Sales Report:");
                    reportBuilder.AppendLine("-------------");

                    while (reader.Read())
                    {
                        DateTime orderDate = (DateTime)reader["OrderDate"];
                        decimal totalSaleAmount = (decimal)reader["TotalSaleAmount"];
                        reportBuilder.AppendLine($"Date: {orderDate.ToShortDateString()}, Total Sale Amount: {totalSaleAmount:C}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while generating the sales report: {ex.Message}");
                    return;
                }
            }
            GeneratePdfSalesReport();
            MessageBox.Show(reportBuilder.ToString(), "Sales Report");
        }
        private void GeneratePdfSalesReport()
        {
            (List<SaleRecord> salesData, decimal totalSales) = GetSalesData();
            string customPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyAppFiles");
            if (!Directory.Exists(customPath))
                Directory.CreateDirectory(customPath);
            string pdfPath = Path.Combine(customPath, $"SalesReport_{DateTime.Now:yyyyMMddHHmmss}.pdf");
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
            document.Open();

            PdfPTable table = new PdfPTable(3); 
            table.AddCell("Order ID");
            table.AddCell("Date");
            table.AddCell("Total Sale");

            foreach (var sale in salesData)
            {
                table.AddCell(sale.OrderId.ToString());
                table.AddCell(sale.Date.ToShortDateString());
                table.AddCell(sale.Total.ToString("C"));
            }

            document.Add(table);
            Paragraph totalParagraph = new Paragraph($"Total Sales: {totalSales:C}");
            totalParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(totalParagraph);

            document.Close();
        }

        private (List<SaleRecord>, decimal) GetSalesData()
        {
            List<SaleRecord> salesData = new List<SaleRecord>();
            decimal totalSales = 0;
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Users\Administrator\source\repos\BUUKSTUR\BUUKSTUR\buuksturr.mdb"";";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT OrderID, OrderDate, TotalPrice FROM Orders";
                string totalQuery = @"SELECT SUM(TotalPrice) AS TotalSales FROM Orders";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SaleRecord record = new SaleRecord
                        {
                            OrderId = reader.GetInt32(reader.GetOrdinal("OrderID")),
                            Date = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                            Total = reader.GetDecimal(reader.GetOrdinal("TotalPrice"))
                        };
                        salesData.Add(record);
                    }
                }

                using (OleDbCommand totalCommand = new OleDbCommand(totalQuery, connection))
                using (OleDbDataReader totalReader = totalCommand.ExecuteReader())
                {
                    if (totalReader.Read() && !totalReader.IsDBNull(totalReader.GetOrdinal("TotalSales")))
                    {
                        totalSales = totalReader.GetDecimal(totalReader.GetOrdinal("TotalSales"));
                    }
                }
            }
            return (salesData, totalSales);
        }


        public class SaleRecord
        {
            public int OrderId { get; set; }
            public DateTime Date { get; set; }
            public decimal Total { get; set; }
        }

        private void btnGenerateSalesReport_Click(object sender, EventArgs e)
        {
            GenerateAndDisplaySalesReport();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            loggingOut = true;
            this.Hide();
            Program.LoginForm.ResetForm();
            Program.LoginForm.Show();
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
        private void btnAddBooks_Click(object sender, EventArgs e)
        {
            addBooksForm addBooksForm = new addBooksForm();

            addBooksForm.ShowDialog();

            LoadBooks();
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
        private void adminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loggingOut)
            {
                Application.Exit();
            }
        }
    }
}
