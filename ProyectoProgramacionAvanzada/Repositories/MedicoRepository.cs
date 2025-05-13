using ProyectoProgramacionAvanzada.Data;
using ProyectoProgramacionAvanzada.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ProyectoProgramacionAvanzada.Repositories
{
    public class MedicoRepository
    {
        private readonly MySqlConnection conexion;

        public MedicoRepository(MySqlConnection conexion)
        {
            this.conexion = conexion;
        }

        public void AgregarMedico(Medico medico)
        {
            var query = @"INSERT INTO medico (nombre, correo, consultorio, especialidad_id)
                          VALUES (@nombre, @correo, @consultorio, @especialidad_id)";

            using (var cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@correo", medico.Correo);
                cmd.Parameters.AddWithValue("@consultorio", medico.Consultorio);
                cmd.Parameters.AddWithValue("@especialidad_id", medico.EspecialidadId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}