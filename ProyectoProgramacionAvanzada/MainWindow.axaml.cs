using Avalonia.Controls;
using Avalonia.Interactivity;
using ProyectoProgramacionAvanzada.Views;

namespace ProyectoProgramacionAvanzada;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void AbrirVentanaPaciente_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var ventanaPaciente = new VentanaPaciente();
        ventanaPaciente.Show();
    }

    private void AbrirVentanaMedico_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var ventanaMedico = new VentanaMedico();
        ventanaMedico.Show();
    }
    private void AbrirListaPacientes_Click(object sender, RoutedEventArgs e)
    {
        var listaPacientes = new VentanaListaPacientes();
        listaPacientes.Show();
    }

}