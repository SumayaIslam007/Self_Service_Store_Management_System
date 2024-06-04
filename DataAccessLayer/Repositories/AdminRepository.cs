using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MySqlConnection _connection;

        public AdminRepository()
        {
            DbConnection dbConnection = new DbConnection();
            _connection = dbConnection.GetConnection();
        }

        public List<Admin> GetAllAdmins()
        {
            List<Admin> admins = new List<Admin>();

            _connection.Open();
            string query = "SELECT * FROM Admin";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                admins.Add(new Admin
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Email = reader.GetString("email"),
                    Phone = reader.GetString("phone"),
                    Type = reader.GetString("type"),
                    Password = reader.GetString("password")
                });
            }

            _connection.Close();
            return admins;
        }

        public Admin GetAdminById(int id)
        {
            Admin admin = null;

            _connection.Open();
            string query = "SELECT * FROM Admin WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                admin = new Admin
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Email = reader.GetString("email"),
                    Phone = reader.GetString("phone"),
                    Type = reader.GetString("type"),
                    Password = reader.GetString("password")
                };
            }

            _connection.Close();
            return admin;
        }
        public Admin GetAdminByEmail(string email)
        {
            Admin admin = null;

            _connection.Open();
            string query = "SELECT * FROM Admin WHERE email = @Email";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Email", email);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                admin = new Admin
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Email = reader.GetString("email"),
                    Phone = reader.GetString("phone"),
                    Type = reader.GetString("type"),
                    Password = reader.GetString("password")
                };
            }

            _connection.Close();
            return admin;
        }


        public void AddAdmin(Admin admin)
        {
            _connection.Open();
            string query = "INSERT INTO Admin (name, email, phone, type, password) VALUES (@Name, @Email, @Phone, @Type, @Password)";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Name", admin.Name);
            command.Parameters.AddWithValue("@Email", admin.Email);
            command.Parameters.AddWithValue("@Phone", admin.Phone);
            command.Parameters.AddWithValue("@Type", admin.Type);
            command.Parameters.AddWithValue("@Password", admin.Password);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void UpdateAdmin(Admin admin)
        {
            _connection.Open();
            string query = "UPDATE Admin SET name = @Name, email = @Email, phone = @Phone, type = @Type, password = @Password WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Name", admin.Name);
            command.Parameters.AddWithValue("@Email", admin.Email);
            command.Parameters.AddWithValue("@Phone", admin.Phone);
            command.Parameters.AddWithValue("@Type", admin.Type);
            command.Parameters.AddWithValue("@Password", admin.Password);
            command.Parameters.AddWithValue("@Id", admin.Id);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void DeleteAdmin(int id)
        {
            _connection.Open();
            string query = "DELETE FROM Admin WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
