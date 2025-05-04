using System.Data;
using MySql.Data.MySqlClient;

namespace StitchMaster
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        private DatabaseHelper()
        {
            var config = LoadConfiguration();
            connectionString = config.GetConnectionString("MyDbConnection");
        }
        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // For console/WinForms apps
                .AddJsonFile("appsettings.development.json", optional: false, reloadOnChange: true);
            return builder.Build();
        }
        private static DatabaseHelper _instance;
        public static DatabaseHelper Instance
        {
            get
            {
                if (_instance == null) _instance = new DatabaseHelper();
                return _instance;
            }
        }
        public MySqlConnection getConnection()
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            return connection;
        }
        public MySqlDataReader getDataReader(string query)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    return command.ExecuteReader();
                }
            }

        }

        public DataTable GetDataTable(string query)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public int ExecuteQuery(string query)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, getConnection()))
                {
                    return command.ExecuteNonQuery();
                }
            }

        }
    }
}