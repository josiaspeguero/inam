namespace unam.Domain.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }

        public string Matricula { get; set; } = string.Empty;

        public string CorreoEstudiantil { get; set; } = string.Empty;

        public string Pin { get; set; } = string.Empty;

        public DateTime FechaIngreso { get; set; }

    }
}
