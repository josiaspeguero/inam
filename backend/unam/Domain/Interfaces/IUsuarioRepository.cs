using unam.Domain.Entities;

namespace unam.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AgregarUsuarioAsync(Usuario usuario);
        Task<Usuario?> BuscarUsuarioAsync(string correo);
        Task<bool> GuardarUsuarioAsync();
        Task<Usuario?> ActualizarUsuarioAsync(Usuario usuario);
    }
}
