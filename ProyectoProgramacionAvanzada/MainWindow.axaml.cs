using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ProyectoProgramacionAvanzada;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Saludar_Click(object? sender, RoutedEventArgs e)
    {
        var nombre = InputNombre.Text;
        var apellido = InputApellido.Text;
        MensajeBienvenida.Text = $"Hola, {nombre} {apellido}! Bienvenido a tu proyecto Avalonia.";
    }
}