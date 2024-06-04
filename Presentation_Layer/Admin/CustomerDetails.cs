using BusinessLogicLayer.Dtos;
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
    public partial class CustomerDetails : Form
    {
        AdminDto admin;
        CustomerManager customerManager;
        public CustomerDetails(AdminDto admin)
        {
            InitializeComponent();
            this.admin = admin;
            customerManager = new CustomerManager();
            PopulateCustomerListView();
        }

        private void PopulateCustomerListView()
        {
            List<CustomerDto> customers = new List<CustomerDto>();
            customers = customerManager.GetAllCustomers();

            dataGridViewCustomers.Rows.Clear();

            // Add columns to the DataGridView
            dataGridViewCustomers.Columns.Add("Id", "ID");
            dataGridViewCustomers.Columns.Add("Name", "Name");
            dataGridViewCustomers.Columns.Add("Email", "Email");
            dataGridViewCustomers.Columns.Add("Phone", "Phone");
            dataGridViewCustomers.Columns.Add("Password", "Password");

            // Populate the DataGridView with data from the list of CustomerDto objects
            foreach (CustomerDto customer in customers)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewCustomers);
                row.Cells[0].Value = customer.Id;
                row.Cells[1].Value = customer.Name;
                row.Cells[2].Value = customer.Email;
                row.Cells[3].Value = customer.Phone;
                row.Cells[4].Value = customer.Password;
                dataGridViewCustomers.Rows.Add(row);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
            Billing.Products.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(admin);
            adminDashboard.Show();
            this.Hide();
        }
    }
}
