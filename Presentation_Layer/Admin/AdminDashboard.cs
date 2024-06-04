using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Presentation_Layer.Admin;
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
    public partial class AdminDashboard : Form
    {
        private AdminDto admin;
        ProductManager productManager;
        public AdminDashboard()
        {
            InitializeComponent();
            productManager = new ProductManager();

            PopulateProductTable();
        }

        public AdminDashboard(AdminDto admin)
        {
            InitializeComponent();
            productManager = new ProductManager();

            this.admin = admin;
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

                // Populate the cells of the row
                row.Cells[0].Value = product.Id;
                row.Cells[1].Value = product.ProductCode;
                row.Cells[2].Value = product.Name;
                row.Cells[3].Value = product.Description;
                row.Cells[4].Value = product.Category;
                row.Cells[5].Value = product.Quantity;
                row.Cells[6].Value = product.Price;

                // Add the row to the DataGridView
                ProductTable.Rows.Add(row);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
            Billing.Products.Clear();
        }

        private void ProductTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
/*            if (ProductTable.Columns[e.ColumnIndex].Name == "Edit")
            {
                ProductDto product = new ProductDto();
                product.Id = (int?)ProductTable.Rows[e.RowIndex].Cells[0].Value;
                product.ProductCode = ProductTable.Rows[e.RowIndex].Cells[1].Value.ToString();
                product.Name = ProductTable.Rows[e.RowIndex].Cells[2].Value.ToString();
                product.Description = ProductTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                product.Category = ProductTable.Rows[e.RowIndex].Cells[4].Value.ToString();
                product.Quantity = (int)ProductTable.Rows[e.RowIndex].Cells[5].Value;
                product.Price = (double)ProductTable.Rows[e.RowIndex].Cells[6].Value;

                productManager.UpdateProduct(product);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ProductId = Int32.Parse(ProductIdTextbox.Text.ToString());
            AddProducts addProducts = new AddProducts(ProductId);
            addProducts.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int productId = Int32.Parse(ProductIdTextbox.Text.ToString());

            ProductDto product = productManager.GetProductById(productId);
            if (product == null)
            {
                MessageBox.Show("Product with the given ID does not exist. Please enter a valid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this product?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                productManager.DeleteProduct(productId);
                MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            PopulateProductTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddProducts addProducts = new AddProducts();
            addProducts.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdminProfile profile = new AdminProfile(admin);
            profile.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomerDetails customerDetails = new CustomerDetails(admin);
            customerDetails.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions(admin);
            transactions.Show();
            this.Hide();
        }
    }
}
