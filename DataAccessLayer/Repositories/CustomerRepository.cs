using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MySqlConnection _connection;
        public CustomerRepository()
        {
            DbConnection dbConnection = new DbConnection();
            _connection = dbConnection.GetConnection();
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            _connection.Open();
            string query = "SELECT * FROM Customer";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new Customer
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Email = reader.GetString("email"),
                    Phone = reader.GetString("phone")
                });
            }

            _connection.Close();
            return customers;
        }
        public Customer GetCustomerById(int id)
        {
            Customer customer = null;
            _connection.Open();
            string query = "SELECT * FROM Customer WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                customer = new Customer
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Email = reader.GetString("email"),
                    Phone = reader.GetString("phone"),
                    Password = reader.GetString("password")
                };
            }

            _connection.Close();
            return customer;
        }
        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = null;

            _connection.Open();
            string query = "SELECT * FROM Customer WHERE email = @Email";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Email", email);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                customer = new Customer
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Email = reader.GetString("email"),
                    Phone = reader.GetString("phone"),
                    Password = reader.GetString("password")
                };
            }

            _connection.Close();
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            _connection.Open();
            string query = "INSERT INTO Customer (name, email, phone, password) VALUES (@Name, @Email, @Phone, @Password)";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Phone", customer.Phone);
            command.Parameters.AddWithValue("@Password", customer.Password);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void UpdateCustomer(Customer customer)
        {
            _connection.Open();
            string query = "UPDATE Customer SET name = @Name, email = @Email, phone = @Phone, password = @Password WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Phone", customer.Phone);
            command.Parameters.AddWithValue("@Password", customer.Password);
            command.Parameters.AddWithValue("@Id", customer.Id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void DeleteCustomer(int id)
        {
            _connection.Open();
            string query = "DELETE FROM Customer WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
