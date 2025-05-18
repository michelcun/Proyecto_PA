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
                cmd.Parameters.AddWithValue("@hora", cita.Hora);
                cmd.Parameters.AddWithValue("@motivo", cita.Motivo);
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
                    var cmd = new MySqlCommand($@"SELECT c.id AS cita_id,
                            c.paciente_id,
                            p.nombre AS nombre_paciente,
                            c.medico_id,
                            c.fecha_cita,
                            c.hora,
                            c.motivo,
                            c.estado
                        FROM cita c
                        JOIN paciente p ON c.paciente_id = p.id", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cita = new Cita
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("cita_id")),
                                PacienteId = reader.GetInt32(reader.GetOrdinal("paciente_id")),
                                NombrePaciente = reader.GetString(reader.GetOrdinal("nombre_paciente")),
                                MedicoId = reader.GetInt32(reader.GetOrdinal("medico_id")),
                                Fecha = reader.GetDateTime(reader.GetOrdinal("fecha_cita")),
                                Hora = reader.IsDBNull(reader.GetOrdinal("hora"))
                                    ? "" : reader.GetTimeSpan(reader.GetOrdinal("hora")).ToString(@"hh\:mm"),
                                Motivo = reader.IsDBNull(reader.GetOrdinal("motivo"))
                                    ? "" : reader.GetString(reader.GetOrdinal("motivo")),
                                Estado = reader.IsDBNull(reader.GetOrdinal("estado"))
                                    ? "" : reader.GetString(reader.GetOrdinal("estado"))
                            };

                            lista.Add(cita);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al obtener las citas:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return lista;
        }
    }
}
