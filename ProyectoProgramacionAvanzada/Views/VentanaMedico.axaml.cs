using Avalonia.Controls;
using Avalonia.Interactivity;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Repositories;
using ProyectoProgramacionAvanzada.Data;
using System;
using MySql.Data.MySqlClient;

namespace ProyectoProgramacionAvanzada.Views
{
    public partial class VentanaMedico : Window
    {
        public VentanaMedico()
        {
            InitializeComponent();
        }

        private void GuardarButton_Click(object? sender, RoutedEventArgs e)
        {
            var nombre = NombreTextBox.Text;
            var correo = CorreoTextBox.Text;
            var consultorio = ConsultorioTextBox.Text;

            var nuevoMedico = new Medico
            {
                Nombre = nombre,
                Correo = correo,
                Consultorio = consultorio
            };

            var conexion = new MySqlConnection();
            var repo = new MedicoRepository(conexion);
            repo.AgregarMedico(nuevoMedico);

            Console.WriteLine("Médico guardado correctamente.");
        }
        private void CerrarButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}