using ProyectoProgramacionAvanzada.Data;
using ProyectoProgramacionAvanzada.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ProyectoProgramacionAvanzada.Repositories
{
    public class EspecialidadRepository
    {
        private readonly ConexionMySQL conexion;

        public EspecialidadRepository(ConexionMySQL conexion)
        {
            this.conexion = conexion;
        }

        public List<Especialidad> ObtenerTodas()
        {
            var lista = new List<Especialidad>();

            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("SELECT id, nombre FROM especialidad", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Especialidad
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        });
                    }
                }
            }

            return lista;
        }
    }
}