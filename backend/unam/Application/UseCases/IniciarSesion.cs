using unam.Application.DTOs;
using unam.Domain.Entities;
using unam.Domain.Interfaces;
using unam.Services;

namespace unam.Application.UseCases
{
    public class IniciarSesion
    {
        private readonly IUsuarioRepository _usuario;
        private readonly IToken _token;
        private readonly ICookie _cookie;

        public IniciarSesion(IUsuarioRepository usuario, IToken token, ICookie cookie)
        {
            _usuario = usuario;
            _token = token;
            _cookie = cookie;
        }
        public async Task<(bool status, string message, object? usuario)> IniciarSesionTask(IniciarSesionDTO iniciarSesionDTO)
        {
            var usuarioExistente = await _usuario.IniciarSesionAsync(iniciarSesionDTO);
            if (usuarioExistente == null)
            {
                return (false, "Credenciales incorrectas", new
                {
                    mensaje = "No se encuentra el usuario"
                });
            }
            var accessCredentials = _token.GenerateToken(usuarioExistente.Correo);
            _cookie.GenerateCookie(accessCredentials.accessToken);
            usuarioExistente.AccessToken = accessCredentials.accessToken;
            usuarioExistente.RefreshToken = accessCredentials.refreshToken;

            await _usuario.GuardarUsuarioAsync();

            return (true, "Bienvenido", new Usuario
            {
                Id = usuarioExistente.Id,
                Correo = usuarioExistente.Correo,
                AccessToken = accessCredentials.accessToken,
            });
        }
    }
}
