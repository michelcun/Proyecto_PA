using MySql.Data.MySqlClient;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Data;

namespace ProyectoProgramacionAvanzada.Repositories
{
    public class PacienteRepository
    {
        private readonly ConexionMySQL conexion;

        public PacienteRepository()
        {
            conexion = new ConexionMySQL();
        }

        public void AgregarPaciente(Paciente paciente)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var query = "INSERT INTO paciente (nombre, apellido, documento, email, telefono, fecha_nacimiento) " +
                            "VALUES (@nombre, @apellido, @documento, @correo, @telefono, @fechaNacimiento)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", paciente.Apellido);
                    cmd.Parameters.AddWithValue("@documento", paciente.Documento);
                    cmd.Parameters.AddWithValue("@correo", paciente.Email);
                    cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaNacimiento);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}