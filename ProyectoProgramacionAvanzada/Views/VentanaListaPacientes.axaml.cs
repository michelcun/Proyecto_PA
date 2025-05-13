using Avalonia.Controls;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Data;
using ProyectoProgramacionAvanzada.Repositories;
using System.Collections.Generic;

namespace ProyectoProgramacionAvanzada.Views
{
    public partial class VentanaListaPacientes : Window
    {
        public VentanaListaPacientes()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            var conexion = new ConexionMySQL();
            var repo = new PacienteRepository(conexion);
            List<Paciente> pacientes = repo.ObtenerTodos();

            PacientesGrid.ItemsSource = pacientes;
        }

        private void CerrarButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}