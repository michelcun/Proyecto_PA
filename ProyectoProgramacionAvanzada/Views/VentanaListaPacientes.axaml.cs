using Avalonia.Controls;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Data;
using ProyectoProgramacionAvanzada.Repositories;
using System.Collections.Generic;
using System;

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
            try
            {
                var conexion = new ConexionMySQL();
                var repo = new PacienteRepository(conexion);
                List<Paciente> pacientes = repo.ObtenerTodos();

                PacientesTextBox.Text = "Pacientes encontrados: " + pacientes.Count + Environment.NewLine;
                foreach (var paciente in pacientes)
                {
                    PacientesTextBox.Text += $"{paciente.Nombre} {paciente.Apellido}\n";
                }
            }
            catch (Exception ex)
            {
                PacientesTextBox.Text = "Error al cargar pacientes: " + ex.Message;
            }
        }

        private void CerrarButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}