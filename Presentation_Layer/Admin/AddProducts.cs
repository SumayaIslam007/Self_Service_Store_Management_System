using BusinessLogicLayer.Dtos;
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

namespace Presentation_Layer.Admin
{
    public partial class AddProducts : Form
    {
        int? ProductId = null;
        ProductManager productManager;
        public AddProducts()
        {
            InitializeComponent();
            productManager = new ProductManager();
        }

        public AddProducts(int id)
        {
            InitializeComponent();
            this.ProductId = id;
            productManager = new ProductManager();
            
            ProductDto productDto = productManager.GetProductById(id);
            ProductNameTextBox.Text = productDto.Name;
            ProductCodeTextBox.Text = productDto.ProductCode;
            ProductDescTextBox.Text = productDto.Description;
            ProductCategoryBox.Text = productDto.Category;
            ProductPriceBox.Text = productDto.Price.ToString();
            ProductQuantityBox.Text = productDto.Quantity.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ProductId == null)
            {
                ProductDto product = new ProductDto();
                product.Name = ProductNameTextBox.Text.ToString();
                product.ProductCode = ProductCodeTextBox.Text.ToString();
                product.Description = ProductDescTextBox.Text.ToString();
                product.Category = ProductCategoryBox.Text.ToString();
                product.Price = Double.Parse(ProductPriceBox.Text.ToString());
                product.Quantity = Int32.Parse(ProductQuantityBox.Text.ToString());
                productManager.AddProduct(product);
                MessageBox.Show("Product Added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

            }
            if (ProductId != null)
            {
                ProductDto product = new ProductDto();
                product.Id = ProductId;
                product.Name = ProductNameTextBox.Text.ToString();
                product.ProductCode = ProductCodeTextBox.Text.ToString();
                product.Description = ProductDescTextBox.Text.ToString();
                product.Category = ProductCategoryBox.Text.ToString();
                product.Price = Double.Parse(ProductPriceBox.Text.ToString());
                product.Quantity = Int32.Parse(ProductQuantityBox.Text.ToString());
                productManager.UpdateProduct(product);
                MessageBox.Show("Product Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
