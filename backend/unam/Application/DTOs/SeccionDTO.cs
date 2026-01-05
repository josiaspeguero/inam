using unam.Domain.Entities;

namespace unam.Application.DTOs
{
    public class SeccionDTO
    {
        public Guid Id { get; set; }

        public string NombreSeccion { get; set; } = string.Empty;

        public int CupoDisponible { get; set; }
    }
}
