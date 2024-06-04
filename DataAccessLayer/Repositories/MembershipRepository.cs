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
    public class MembershipRepository : IMembershipRepository
    {
        private readonly MySqlConnection _connection;

        public MembershipRepository()
        {
            DbConnection dbConnection = new DbConnection();
            _connection = dbConnection.GetConnection();
        }

        public List<Membership> GetAllMemberships()
        {
            List<Membership> memberships = new List<Membership>();
            _connection.Open();
            string query = "SELECT * FROM Memberships";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                memberships.Add(new Membership
                {
                    Id = reader.GetInt32("id"),
                    CustomerId = reader.GetInt32("customer_id"),
                    MembershipType = reader.GetString("membership_type"),
                    DiscountRate = reader.GetDouble("discount_rate"),
                    StartDate = reader.GetDateTime("start_date"),
                    EndDate = reader.GetDateTime("end_date")
                });
            }

            _connection.Close();
            return memberships;
        }

        public Membership GetMembershipById(int id)
        {
            Membership membership = null;
            _connection.Open();
            string query = "SELECT * FROM Memberships WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                membership = new Membership
                {
                    Id = reader.GetInt32("id"),
                    CustomerId = reader.GetInt32("customer_id"),
                    MembershipType = reader.GetString("membership_type"),
                    DiscountRate = reader.GetDouble("discount_rate"),
                    StartDate = reader.GetDateTime("start_date"),
                    EndDate = reader.GetDateTime("end_date")
                };
            }

            _connection.Close();
            return membership;
        }

        public void AddMembership(Membership membership)
        {
            _connection.Open();
            string query = "INSERT INTO Memberships (customer_id, membership_type, discount_rate, start_date, end_date) VALUES (@CustomerId, @MembershipType, @DiscountRate, @StartDate, @EndDate)";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@CustomerId", membership.CustomerId);
            command.Parameters.AddWithValue("@MembershipType", membership.MembershipType);
            command.Parameters.AddWithValue("@DiscountRate", membership.DiscountRate);
            command.Parameters.AddWithValue("@StartDate", membership.StartDate);
            command.Parameters.AddWithValue("@EndDate", membership.EndDate);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void UpdateMembership(Membership membership)
        {
            _connection.Open();
            string query = "UPDATE Memberships SET customer_id = @CustomerId, membership_type = @MembershipType, discount_rate = @DiscountRate, start_date = @StartDate, end_date = @EndDate WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@CustomerId", membership.CustomerId);
            command.Parameters.AddWithValue("@MembershipType", membership.MembershipType);
            command.Parameters.AddWithValue("@DiscountRate", membership.DiscountRate);
            command.Parameters.AddWithValue("@StartDate", membership.StartDate);
            command.Parameters.AddWithValue("@EndDate", membership.EndDate);
            command.Parameters.AddWithValue("@Id", membership.Id);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void DeleteMembership(int id)
        {
            _connection.Open();
            string query = "DELETE FROM Memberships WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
