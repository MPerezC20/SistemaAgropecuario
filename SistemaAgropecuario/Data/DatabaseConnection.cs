using MySqlConnector;

namespace SistemaAgropecuario.Data
{
    public static class DatabaseConnection
    {
        private const string connectionString =
            "server=localhost;port=3306;database=gestion_agricola;user=root;password=1234;SslMode=None;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
