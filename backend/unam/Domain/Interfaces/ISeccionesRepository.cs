using unam.Domain.Entities;

namespace unam.Domain.Interfaces
{
    public interface ISeccionesRepository
    {
        Task AgregarSeccionAsync(Seccion seccion);
        Task<bool> GuardarSeccionAsync();
        Task<bool> ActualizarSeccionAsync(Seccion seccion);
    }
}
