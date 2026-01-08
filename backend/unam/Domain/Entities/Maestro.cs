namespace unam.Domain.Entities
{
    public class Maestro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string CorreoInstitucional { get; set; } = string.Empty;
        public int Pin { get; set; }
        public string NoDocumento { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int Calificacion { get; set; } = 0; //puntuacion que le hayan dado los estudiantes
        public DateTime FechaIngreso { get; set; }
        public Seccion? Seccion { get; set; }
    }
}
