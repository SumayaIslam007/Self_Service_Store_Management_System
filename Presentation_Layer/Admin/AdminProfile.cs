using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
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
    public partial class AdminProfile : Form
    {
        AdminDto admin;
        AdminManager adminManager;
        public AdminProfile(AdminDto admin)
        {
            InitializeComponent();
            this.admin = admin;
            adminManager = new AdminManager();

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
            NameTextBox.Text = admin.Name;
            EmailTextBox.Text = admin.Email;
            PhoneTextBox.Text = admin.Phone;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminDto admin = new AdminDto();
            admin.Name = NameTextBox.Text;
            admin.Email = EmailTextBox.Text;
            admin.Phone = PhoneTextBox.Text;
            admin.Password = PassTextBox.Text;

            adminManager.UpdateAdmin(admin);

            MessageBox.Show("Saved Changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SaveButton.Hide();
            EditButton.Show();
            CancelButton.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
            Billing.Products.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions(admin);
            transactions.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(admin);
            adminDashboard.Show();
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            EditButton.Show();
            CancelButton.Hide();
            SaveButton.Hide();
            PassTextBox.Hide();

            NameTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
            PhoneTextBox.Enabled = false;
            PassTextBox.Hide();
            PassLabel.Hide();
        }
    }
}
