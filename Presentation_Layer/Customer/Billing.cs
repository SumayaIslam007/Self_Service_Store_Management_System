using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Customer
{
    public partial class Billing : Form
    {
        CustomerDto customer;
        TransactionManager transactionManager;

        public static List<ProductDto> Products = new List<ProductDto>();
        public double total = 0;
        public Billing(CustomerDto customer)
        {
            InitializeComponent();
            this.customer = customer;
            transactionManager = new TransactionManager();
            PopulateBillTable();
            CalculateTotalBill();
        }
        public void CalculateTotalBill()
        {
            foreach (ProductDto product in Products)
            {
                total += product.Price;
            }
            TotalBillTextBox.Text = total.ToString();
        }

        public void PopulateBillTable()
        {
            BillTable.Rows.Clear();
            List<ProductDto> productList = new List<ProductDto>();
            productList = Products;

            foreach (ProductDto product in productList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(BillTable);

                // Populate the cells of the row
                row.Cells[0].Value = product.Id;
                row.Cells[1].Value = product.Name;
                row.Cells[2].Value = product.Quantity;
                row.Cells[3].Value = product.Price;

                // Add the row to the DataGridView
                BillTable.Rows.Add(row);
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
            Billing.Products.Clear();
        }

        private void ProductPageButton_Click(object sender, EventArgs e)
        {
            CustomerPage customerPage = new CustomerPage(customer);
            customerPage.Show();
            this.Hide();
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            CustomerProfile customerProfile = new CustomerProfile(customer);
            customerProfile.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked ||  !checkBox2.Checked || !checkBox3.Checked)
            {
                MessageBox.Show("Select a payment method.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Payment successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
