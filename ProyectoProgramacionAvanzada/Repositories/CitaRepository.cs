using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Data;
using MySql.Data.MySqlClient;

namespace ProyectoProgramacionAvanzada.Repositories
{
    public class CitaRepository
    {
        private readonly ConexionMySQL _conexion;

        public CitaRepository(ConexionMySQL conexion)
        {
            _conexion = conexion;
        }

        public void AgregarCita(Cita cita)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand(
                    "INSERT INTO cita (paciente_id, medico_id, fecha_cita, hora, motivo, estado) " +
                    "VALUES (@paciente, @medico, @fecha, @hora, @motivo, @estado)", conn);

                cmd.Parameters.AddWithValue("@paciente", cita.PacienteId);
                cmd.Parameters.AddWithValue("@medico", cita.MedicoId);
                cmd.Parameters.AddWithValue("@fecha", cita.Fecha);
                cmd.Parameters.AddWithValue("@hora", cita.Hora ?? string.Empty);      // Previene null
                cmd.Parameters.AddWithValue("@motivo", cita.Motivo ?? string.Empty);  // Previene null
                cmd.Parameters.AddWithValue("@estado", cita.Estado ?? string.Empty);  // ✅ Este parámetro era el que faltaba

                cmd.ExecuteNonQuery();
            }
        }
    }
}