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

namespace Presentation_Layer
{
    public partial class CustomerPage : Form
    {

        CustomerDto customer;
        ProductManager productManager;
        public CustomerPage(CustomerDto customer)
        {
            InitializeComponent();
            productManager = new ProductManager();
            this.customer = customer;
            PopulateProductTable();
        }

        private void PopulateProductTable()
        {
            ProductTable.Rows.Clear();
            List<ProductDto> productList = new List<ProductDto>();
            productList = productManager.GetAllProducts();

            foreach (ProductDto product in productList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(ProductTable);

                row.Cells[0].Value = product.Id;
                row.Cells[1].Value = product.ProductCode;
                row.Cells[2].Value = product.Name;
                row.Cells[3].Value = product.Description;
                row.Cells[4].Value = product.Category;
                row.Cells[5].Value = product.Quantity;
                row.Cells[6].Value = product.Price;

                ProductTable.Rows.Add(row);
            }
        }
        private void AddToBillButton_Click(object sender, EventArgs e)
        {
            int productId = Int32.Parse(IdTextBox.Text.ToString());
            int quantity = Int32.Parse(QuantityBox.Text.ToString());

            ProductDto product = productManager.GetProductById(productId);
            product.Quantity = quantity;
            product.Price = product.Price * quantity;
            if (product != null)
            {
                Billing.Products.Add(product);

                MessageBox.Show("Bill Added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
            Billing.Products.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void BillingPageButton_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing(customer);
            billing.Show();
            this.Hide();
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            CustomerProfile customerProfile = new CustomerProfile(customer);
            customerProfile.Show();
            this.Hide();
        }
    }
}
