using ProyectoProgramacionAvanzada.Data;
using ProyectoProgramacionAvanzada.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ProyectoProgramacionAvanzada.Repositories
{
    public class MedicoRepository
    {
        private readonly ConexionMySQL _conexion;

        public MedicoRepository(ConexionMySQL conexion)
        {
            _conexion = conexion;
        }

        public void AgregarMedico(Medico medico)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                var query = "INSERT INTO medico (nombre, email, consultorio) " +
                            "VALUES (@nombre, @email, @consultorio)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", medico.Nombre);
                    cmd.Parameters.AddWithValue("@email", medico.Correo);
                    cmd.Parameters.AddWithValue("@consultorio", medico.Consultorio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Medico> ObtenerTodos()
        {
            var lista = new List<Medico>();

            using (var conn = _conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("SELECT id, nombre, email, consultorio FROM medico", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Medico
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Correo = reader.GetString(2),
                            Consultorio = reader.GetString(3)
                        });
                    }
                }
            }

            return lista;
        }
    }
}