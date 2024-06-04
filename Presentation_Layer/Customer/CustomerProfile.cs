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

namespace Presentation_Layer.Customer
{
    public partial class CustomerProfile : Form
    {
        CustomerDto customer;
        CustomerManager customerManager;
        public CustomerProfile(CustomerDto customer)
        {
            InitializeComponent();
            customerManager = new CustomerManager();
            this.customer = customer;
            CancelButton.Hide();
            SaveButton.Hide();

            NameTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
            PhoneTextBox.Enabled = false;
            PassTextBox.Hide();
            PassLabel.Hide();

            InitializeData();
        }

        public void InitializeData()
        {
            NameTextBox.Text = customer.Name;
            EmailTextBox.Text = customer.Email;
            PhoneTextBox.Text = customer.Phone;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SaveButton.Show();
            CancelButton.Show();
            PassTextBox.Show();
            EditButton.Hide();

            NameTextBox.Enabled = true;
            EmailTextBox.Enabled = true;
            PhoneTextBox.Enabled = true;
            PassTextBox.Enabled = true;
            PassLabel.Show();
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            EditButton.Show();
            CancelButton.Hide();
            SaveButton.Hide();
            PassTextBox.Hide() ;

            NameTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
            PhoneTextBox.Enabled = false;
            PassTextBox.Hide();
            PassLabel.Hide();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            CustomerDto customer = new CustomerDto();
            customer.Name = NameTextBox.Text;
            customer.Email = EmailTextBox.Text;
            customer.Phone = PhoneTextBox.Text;
            customer.Password = PassTextBox.Text;

            customerManager.UpdateCustomer(customer);

            MessageBox.Show("Saved Changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SaveButton.Hide();
            EditButton.Show();
            CancelButton.Show();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
            Billing.Products.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing(customer);
            billing.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerPage customerPage = new CustomerPage(customer);
            customerPage.Show();
            this.Hide();
        }
    }
}
