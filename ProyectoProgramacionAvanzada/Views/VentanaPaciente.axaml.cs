using Avalonia.Controls;
using Avalonia.Interactivity;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Data;
using ProyectoProgramacionAvanzada.Repositories;
using System;



namespace ProyectoProgramacionAvanzada.Views
{
    public partial class VentanaPaciente : Window
    {
        public VentanaPaciente()
        {
            InitializeComponent();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtener datos de los campos
            var nombre = NombreTextBox.Text;
            var apellido = ApellidoTextBox.Text;
            var documento = DocumentoTextBox.Text;
            var email = EmailTextBox.Text;
            var telefono = TelefonoTextBox.Text;
            DateTime.TryParse(FechaNacimientoTextBox.Text, out var fechaNacimiento);

            // Crear objeto Paciente
            var nuevoPaciente = new Paciente
            {
                Nombre = nombre,
                Apellido = apellido,
                Documento = documento,
                Email = email,
                Telefono = telefono,
                FechaNacimiento = fechaNacimiento
            };

            // Guardar en la base de datos
            var conexion = new ConexionMySQL();
            var repo = new PacienteRepository(conexion);
            repo.AgregarPaciente(nuevoPaciente);

            // Limpiar campos
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            DocumentoTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";
            FechaNacimientoTextBox.Text = "";

            // Confirmación
            Console.WriteLine("Paciente guardado correctamente.");
        }
        private void CerrarButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}