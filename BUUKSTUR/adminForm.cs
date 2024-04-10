﻿using System;
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
    public partial class adminForm : Form
    {
        private bool loggingOut = false;
        public adminForm()
        {
            InitializeComponent();
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

            MessageBox.Show(reportBuilder.ToString(), "Sales Report");
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

        
    }
}