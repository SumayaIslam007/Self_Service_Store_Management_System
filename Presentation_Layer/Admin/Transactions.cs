using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services;
using Presentation_Layer.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Admin
{
    public partial class Transactions : Form
    {
        AdminDto admin;
        TransactionManager transactionManager;
        public Transactions(AdminDto admin)
        {
            InitializeComponent();
            transactionManager = new TransactionManager();
            PopulateTransactionListView();
        }

        private void PopulateTransactionListView()
        {
            List<TransactionDto> transactions = transactionManager.GetAllTransactions();

            TransactionTable.Rows.Clear();
            TransactionTable.Columns.Clear();

            // Add columns to the DataGridView
            TransactionTable.Columns.Add("Id", "ID");
            TransactionTable.Columns.Add("CustomerId", "Customer ID");
            TransactionTable.Columns.Add("ProductName", "Product Name");
            TransactionTable.Columns.Add("Amount", "Amount");
            TransactionTable.Columns.Add("Date", "Date");
            TransactionTable.Columns.Add("PaymentMethod", "Payment Method");

            // Populate the DataGridView with data from the list of TransactionDto objects
            foreach (TransactionDto transaction in transactions)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(TransactionTable);
                row.Cells[0].Value = transaction.Id;
                row.Cells[1].Value = transaction.CustomerId;
                row.Cells[2].Value = transaction.ProductName;
                row.Cells[3].Value = transaction.Amount;
                row.Cells[4].Value = transaction.Date;
                row.Cells[5].Value = transaction.PaymentMethod;
                TransactionTable.Rows.Add(row);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
            Billing.Products.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdminProfile adminProfile = new AdminProfile(admin);
            adminProfile.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomerDetails customerDetails = new CustomerDetails(admin);
            customerDetails.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(admin);
            adminDashboard.Show();
            this.Hide();
        }
    }
}
