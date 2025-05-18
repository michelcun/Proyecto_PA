using Avalonia.Controls;
using Avalonia.Interactivity;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Repositories;
using ProyectoProgramacionAvanzada.Data;
using System;
using System.Text;

namespace ProyectoProgramacionAvanzada.Views
{
    public partial class VentanaListaCitas : Window
    {
        public VentanaListaCitas()
        {
            InitializeComponent();
            CargarCitas();
        }

        private void CargarCitas()
        {
            try
            {
                var conexion = new ConexionMySQL();
                var repo = new CitaRepository(conexion);
                var citas = repo.ObtenerTodas();

                var sb = new StringBuilder();
                sb.AppendLine("📝 LISTA DE CITAS:\n");

                foreach (var cita in citas)
                {
                    sb.AppendLine($"📅 Cita ID: {cita.Id}");
                    sb.AppendLine($"👤 Paciente ID: {cita.PacienteId}");
                    sb.AppendLine($"👤 Paciente: {cita.NombrePaciente})");
                    sb.AppendLine($"🩺 Médico ID: {cita.MedicoId}");
                    sb.AppendLine($"🗓 Fecha: {cita.Fecha:dd/MM/yyyy}");
                    sb.AppendLine($"🕒 Hora: {cita.Hora}");
                    sb.AppendLine($"💬 Motivo: {cita.Motivo}");
                    sb.AppendLine($"📌 Estado: {cita.Estado}");
                    sb.AppendLine(new string('-', 40));
                }

                CitasTextBox.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Error al cargar citas:");
                Console.WriteLine(ex.Message);
            }
        }

        private void CerrarButton_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}