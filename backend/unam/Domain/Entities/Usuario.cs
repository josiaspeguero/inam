namespace unam.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public int SolicitudID { get; set; }
        public ICollection<Solicitud> Solicitudes { get; set; } = new HashSet<Solicitud>();
    }
}
