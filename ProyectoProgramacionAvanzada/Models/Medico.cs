namespace ProyectoProgramacionAvanzada.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public  string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; }
        public string Consultorio { get; set; }
        public int EspecialidadId { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
      
      


    }
    
}