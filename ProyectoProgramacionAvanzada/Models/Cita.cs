using System;

namespace ProyectoProgramacionAvanzada.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public object PacienteId { get; set; }
        public int MedicoId { get; set; }
        public object Hora { get; set; }
        public string? Estado { get; set; }
    }
}