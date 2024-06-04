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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MySqlConnection _connection;

        public TransactionRepository()
        {
            DbConnection dbConnection = new DbConnection();
            _connection = dbConnection.GetConnection();
        }

        public List<Transaction> GetAllTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            _connection.Open();
            string query = "SELECT * FROM Transaction";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                transactions.Add(new Transaction
                {
                    Id = reader.GetInt32("id"),
                    CustomerId = reader.GetInt32("customer_id"),
                    ProductName = reader.GetString("product_name"),
                    Date = reader.GetDateTime("date"),
                    Amount = reader.GetDouble("amount"),
                    PaymentMethod = reader.GetString("payment_method")
                });
            }

            _connection.Close();
            return transactions;
        }

        public Transaction GetTransactionById(int id)
        {
            Transaction transaction = null;
            _connection.Open();
            string query = "SELECT * FROM Transaction WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                transaction = new Transaction
                {
                    Id = reader.GetInt32("id"),
                    CustomerId = reader.GetInt32("customer_id"),
                    ProductName = reader.GetString("product_name"),
                    Date = reader.GetDateTime("date"),
                    Amount = reader.GetDouble("amount"),
                    PaymentMethod = reader.GetString("payment_method")
                };
            }

            _connection.Close();
            return transaction;
        }

        public void AddTransaction(Transaction transaction)
        {
            _connection.Open();
            string query = "INSERT INTO Transaction (customer_id, product_name, date, amount, payment_method) VALUES (@CustomerId, @ProductName, @Date, @Amount, @PaymentMethod)";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@CustomerId", transaction.CustomerId);
            command.Parameters.AddWithValue("@ProductName", transaction.ProductName);
            command.Parameters.AddWithValue("@Date", transaction.Date);
            command.Parameters.AddWithValue("@Amount", transaction.Amount);
            command.Parameters.AddWithValue("@PaymentMethod", transaction.PaymentMethod);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _connection.Open();
            string query = "UPDATE Transaction SET customer_id = @CustomerId, date = @Date, product_name = @ProductName, amount = @Amount, payment_method = @PaymentMethod WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@CustomerId", transaction.CustomerId);
            command.Parameters.AddWithValue("@ProductName", transaction.ProductName);
            command.Parameters.AddWithValue("@Date", transaction.Date);
            command.Parameters.AddWithValue("@Amount", transaction.Amount);
            command.Parameters.AddWithValue("@PaymentMethod", transaction.PaymentMethod);
            command.Parameters.AddWithValue("@Id", transaction.Id);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void DeleteTransaction(int id)
        {
            _connection.Open();
            string query = "DELETE FROM Transaction WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
