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
                var cmd = new MySqlCommand("SELECT nombre, apellido, documento, email, telefono, fecha_nacimiento FROM paciente", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Paciente
                        {
                            Nombre = reader.GetString(0),
                            Apellido = reader.GetString(1),
                            Documento = reader.GetString(2),
                            Email = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            FechaNacimiento = reader.GetDateTime(5)
                        });
                    }
                }
            }

            return lista;
        }
    }
}
