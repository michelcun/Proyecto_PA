using Avalonia.Controls;
using Avalonia.Interactivity;
using ProyectoProgramacionAvanzada.Models;
using ProyectoProgramacionAvanzada.Repositories;
using ProyectoProgramacionAvanzada.Data;
using System;

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
            try
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

                var conexion = new ConexionMySQL();
                var repo = new MedicoRepository(conexion);
                repo.AgregarMedico(nuevoMedico);

                Console.WriteLine("✅ Médico guardado correctamente en la base de datos.");

                // Limpiar los campos
                ResetCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al guardar el médico: {ex.Message}");
            }
        }

        private void ResetCampos()
        {
            NombreTextBox.Text = "";
            CorreoTextBox.Text = "";
            ConsultorioTextBox.Text = "";
        }

        private void CerrarButton_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}