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

namespace Presentation_Layer
{
    public partial class LoginPage : Form
    {
        AdminManager adminManager;
        CustomerManager customerManager;
        public LoginPage()
        {
            InitializeComponent();
            adminManager = new AdminManager();
            customerManager = new CustomerManager();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.ToString();
            string password = PasswordTextBox.Text.ToString();
            if(RoleSelectBox.Text.ToString() == "Admin")
            {
                AdminDto admin = adminManager.GetAdminByEmail(email);
                if(adminManager.ValidateAdmin(admin, password))
                {
                    DialogResult dr = MessageBox.Show("\"Login successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminDashboard adminDashboard = new AdminDashboard(admin);
                    this.Hide();
                    adminDashboard.Show();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Invalid credentials", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            if(RoleSelectBox.Text.ToString() == "Customer")
            {
                CustomerDto customer = customerManager.GetCustomerByEmail(email);
                if (customerManager.ValidateCustomer(customer, password))
                {
                    DialogResult dr = MessageBox.Show("Login successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CustomerPage customerPage = new CustomerPage(customer);
                    this.Hide();
                    customerPage.Show();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Invalid credentials", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterPage registerPage =  new RegisterPage();
            registerPage.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
