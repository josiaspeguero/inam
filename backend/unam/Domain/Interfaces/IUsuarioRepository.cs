using unam.Application.DTOs;
using unam.Domain.Entities;

namespace unam.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AgregarUsuarioAsync(Usuario usuario);
        Task<Usuario?> BuscarUsuarioAsync(string correo);
        Task<Usuario?> IniciarSesionAsync(IniciarSesionDTO iniciarSesionDTO);
        Task<bool> GuardarUsuarioAsync();
        Task ActualizarUsuarioAsync(Usuario usuario);
    }
}
