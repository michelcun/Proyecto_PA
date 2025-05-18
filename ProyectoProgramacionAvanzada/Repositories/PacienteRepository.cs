using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Data;

namespace ProyectoProgramacionAvanzada.Repositories
{
    public class PacienteRepository
    {
        private readonly ConexionMySQL _conexion;

        public PacienteRepository(ConexionMySQL conexion)
        {
            _conexion = conexion;
        }

        public void AgregarPaciente(Paciente paciente)
        {
            using (var conn = _conexion.ObtenerConexion())
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

        public List<Paciente> ObtenerTodos()
        {
            var lista = new List<Paciente>();

            using (var conn = _conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("SELECT id, nombre, apellido, documento, email, telefono, fecha_nacimiento FROM paciente", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Paciente
                        {
                            Id = reader.GetInt32(0), // 👈 Importante para que se guarde el paciente_id
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Documento = reader.GetString(3),
                            Email = reader.GetString(4),
                            Telefono = reader.GetString(5),
                            FechaNacimiento = reader.GetDateTime(6)
                        });
                    }
                }
            }

            return lista;
        }

    }
}
