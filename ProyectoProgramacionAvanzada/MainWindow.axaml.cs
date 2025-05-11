using Avalonia.Controls;
using Avalonia.Interactivity;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Repositories;
using System;

namespace ProyectoProgramacionAvanzada
{
    public partial class MainWindow : Window
    {
        public MainWindow()
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
            DateTime fechaNacimiento;
            DateTime.TryParse(FechaNacimientoTextBox.Text, out fechaNacimiento);


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
            var repo = new PacienteRepository();
            repo.AgregarPaciente(nuevoPaciente);

            // Confirmación por consola
            Console.WriteLine("Paciente guardado correctamente.");
        }
    }
}