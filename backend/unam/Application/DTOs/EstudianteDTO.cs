using unam.Domain.Entities;

namespace unam.Application.DTOs
{
    public class EstudianteDTO
    {
        public Guid Id { get; set; }

        public string Matricula { get; set; } = string.Empty;

        public string CorreoEstudiantil { get; set; } = string.Empty;

        public string Pin { get; set; } = string.Empty;

        public ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();

        public DateTime FechaIngreso { get; set; }

    }
}
