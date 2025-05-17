namespace ProyectoProgramacionAvanzada.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
    }
}