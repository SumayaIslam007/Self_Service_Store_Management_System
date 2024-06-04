using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using MySqlConnector;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlConnection _connection;

        public ProductRepository()
        {
            DbConnection dbConnection = new DbConnection();
            _connection = dbConnection.GetConnection();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            _connection.Open();
            string query = "SELECT * FROM Product";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = reader.GetInt32("id"),
                    ProductCode = reader.GetString("productCode"),
                    Name = reader.GetString("name"),
                    Description = reader.GetString("description"),
                    Category = reader.GetString("category"),
                    Price = reader.GetDouble("price"),
                    Quantity = reader.GetDouble("quantity")
                });
            }

            _connection.Close();
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = null;
            _connection.Open();
            string query = "SELECT * FROM Product WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                product = new Product
                {
                    Id = reader.GetInt32("id"),
                    ProductCode = reader.GetString("productCode"),
                    Name = reader.GetString("name"),
                    Description = reader.GetString("description"),
                    Category = reader.GetString("category"),
                    Price = reader.GetDouble("price"),
                    Quantity = reader.GetDouble("quantity")
                };
            }

            _connection.Close();
            return product;
        }

        public void AddProduct(Product product)
        {
            _connection.Open();
            string query = "INSERT INTO Product (productCode, name, description, category, price, quantity) VALUES (@ProductCode, @Name, @Description, @Category, @Price, @Quantity)";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Category", product.Category);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void UpdateProduct(Product product)
        {
            _connection.Open();
            string query = "UPDATE Product SET productCode = @ProductCode, name = @Name, description = @Description, category = @Category, price = @Price, quantity = @Quantity WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Category", product.Category);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@Id", product.Id);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void DeleteProduct(int id)
        {
            _connection.Open();
            string query = "DELETE FROM Product WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
