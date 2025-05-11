using MySql.Data.MySqlClient;

namespace ProyectoProgramacionAvanzada.Data
{
    public class ConexionMySQL
    {
        private string connectionString = "server=localhost;database=gestion_reservas;user=cliente_clinica;password=TeX2UkC!;";

        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }
    }
}