using unam.Domain.Entities;

namespace unam.Domain.Interfaces
{
    public interface IMaestrosRepository
    {
        Task AgregarMaestroAsync(Maestro maestro);
        Task<bool> GuardarMaestroAsync();
        Task<bool> ActualizarMaestroAsync(Maestro maestro);
    }
}
