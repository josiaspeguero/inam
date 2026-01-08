using unam.Domain.Entities;

namespace unam.Application.DTOs
{
    public class UsuarioDTO
    {

        public int Id { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public int SolicitudID { get; set; }
    }
}

