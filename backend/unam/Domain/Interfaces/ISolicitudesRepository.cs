using unam.Domain.Entities;

namespace unam.Domain.Interfaces
{
    public interface ISolicitudesRepository
    {
        Task AgregarSolicitud(Solicitud solicitud);
        Task<bool> GuardarSolicitud();
        Task<bool> ActualizarSolicitud(Solicitud solicitud);
    }
}
