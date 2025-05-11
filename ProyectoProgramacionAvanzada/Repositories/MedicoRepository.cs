using MySql.Data.MySqlClient;
using ProyectoProgramacionAvanzada.Data;
using ProyectoProgramacionAvanzada.Models;

namespace ProyectoProgramacionAvanzada.Repositories
{
    public class MedicoRepository
    {
        private readonly ConexionMySQL conexion;

        public MedicoRepository()
        {
            conexion = new ConexionMySQL();
        }

        public void AgregarMedico(Medico medico)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var query = "INSERT INTO medico (nombre, especialidad_id, correo, telefono) " +
                            "VALUES (@nombre, @especialidad_id, @correo, @telefono)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", medico.Nombre);
                    cmd.Parameters.AddWithValue("@especialidad_id", medico.EspecialidadId);
                    cmd.Parameters.AddWithValue("@correo", medico.Correo);
                    cmd.Parameters.AddWithValue("@telefono", medico.Telefono);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}