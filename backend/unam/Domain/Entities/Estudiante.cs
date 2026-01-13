namespace unam.Domain.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }

        public string Matricula { get; set; } = string.Empty;

        public string CorreoEstudiantil { get; set; } = string.Empty;

        public int Pin { get; set; } 
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpireToken { get; set; }

        public DateTime FechaIngreso { get; set; }

    }
}
