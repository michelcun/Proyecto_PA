using Avalonia.Controls;
using Avalonia.Interactivity;
using ProyectoProgramacionAvanzada.Data;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Repositories;
using System;


namespace ProyectoProgramacionAvanzada.Views
{
    public partial class VentanaCita : Window
    {
        public VentanaCita()
        {
            InitializeComponent();
            CargarListas();
        }

        private void CargarListas()
        {
            var conexion = new ConexionMySQL();

            var pacienteRepo = new PacienteRepository(conexion);
            var pacientes = pacienteRepo.ObtenerTodos();
            PacientesComboBox.ItemsSource = pacientes;

            var medicoRepo = new MedicoRepository(conexion);
            var medicos = medicoRepo.ObtenerTodos();
            MedicosComboBox.ItemsSource = medicos;
        }

        private void GuardarButton_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                var paciente = (Paciente?)PacientesComboBox.SelectedItem;
              
                var medico = (Medico?)MedicosComboBox.SelectedItem;
                if (medico == null)
                {
                    Console.WriteLine("❌ No se ha seleccionado un médico válido.");
                    return;
                }
                Console.WriteLine($"🩺 Médico seleccionado: {medico.Nombre}, ID: {medico.Id}");

                var fechaOffset = FechaDatePicker.SelectedDate;

                if (paciente == null || medico == null || fechaOffset == null)
                {
                    Console.WriteLine("Error: Debes seleccionar un paciente, un médico y una fecha.");
                    return;
                }

                var cita = new Cita
                {
                    PacienteId = paciente.Id,
                    MedicoId = medico.Id,
                    Fecha = fechaOffset.Value.DateTime, // conversión segura
                    Hora = HoraTextBox.Text,
                    Motivo = MotivoTextBox.Text,
                    Estado = EstadoTextBox.Text
                };

                var conexion = new ConexionMySQL();
                var repo = new CitaRepository(conexion);
                repo.AgregarCita(cita);

                Console.WriteLine("Ok: Cita guardada correctamente.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Error al guardar la cita:");
                Console.WriteLine(ex);
            }
        }

        private void LimpiarCampos()
        {
            PacientesComboBox.SelectedIndex = -1;
            MedicosComboBox.SelectedIndex = -1;
            FechaDatePicker.SelectedDate = null;
            HoraTextBox.Text = string.Empty;
            MotivoTextBox.Text = string.Empty;
            EstadoTextBox.Text = string.Empty;
        }

        private void CerrarButton_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
