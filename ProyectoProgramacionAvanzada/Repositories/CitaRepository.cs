using System;
using System.Collections.Generic;
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
                cmd.Parameters.AddWithValue("@estado", cita.Estado ?? string.Empty);  

                cmd.ExecuteNonQuery();
            }
        }
        public List<Cita> ObtenerTodas()
        {
            var lista = new List<Cita>();

            try
            {
                using (var conn = _conexion.ObtenerConexion())
                {
                    var cmd = new MySqlCommand("SELECT id, paciente_id, medico_id, fecha_cita, hora, motivo, estado FROM cita", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cita = new Cita
                            {
                                Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                PacienteId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                                MedicoId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                                Fecha = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                                Hora = reader.IsDBNull(4) ? "" : reader.GetTimeSpan(4).ToString(@"hh\:mm"),
                                Motivo = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                Estado = reader.IsDBNull(6) ? "" : reader.GetString(6)
                            };

                            lista.Add(cita);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las citas:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return lista;
        }


    }
}