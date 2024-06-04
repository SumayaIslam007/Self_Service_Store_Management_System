using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbConnection
    {
        private readonly string _server = "localhost";
        private readonly string _port = "3306";
        private readonly string _database = "my_store";
        private readonly string _user = "root";
        private readonly string _password = "password";

        private readonly MySqlConnection _connection;

        public DbConnection()
        {
            _connection = new MySqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            string connString = $"server={_server};port={_port};database={_database};uid={_user};password={_password};";
            return connString;
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
