﻿using BusinessLogicLayer.Dtos;
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
    public partial class RegisterPage : Form
    {
        CustomerManager customerManager;
        public RegisterPage()
        {
            InitializeComponent();
            customerManager = new CustomerManager();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CustomerDto customer = new CustomerDto();
            customer.Name = NameTextBox.Text.ToString();
            customer.Email = EmailTextBox.Text.ToString();
            customer.Phone = PhoneTextBox.Text.ToString();
            customer.Password = PasswordTextBox.Text.ToString();

            customerManager.AddCustomer(customer);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
