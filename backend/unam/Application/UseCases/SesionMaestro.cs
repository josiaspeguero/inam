using unam.Application.DTOs;
using unam.Domain.Entities;
using unam.Domain.Interfaces;
using unam.Services;

namespace unam.Application.UseCases
{
    public class SesionMaestro
    {
        private readonly IMaestrosRepository _maestro;
        private readonly IToken _token;
        private readonly ICookie _cookie;

        public SesionMaestro(IMaestrosRepository maestro, IToken token, ICookie cookie)
        {
            _maestro = maestro;
            _token = token;
            _cookie = cookie;
        }

        public async Task<(bool status, string message, object? usuario)> IniciarSesionTask(IniciarSesionDTO iniciarSesionDTO)
        {
            var usuarioExistente = await _maestro.AccederAsync(iniciarSesionDTO);
            if (usuarioExistente == null)
            {
                return (false, "Credenciales incorrectas", new
                {
                    mensaje = "No se encuentra el usuario"
                });
            }
            var accessCredentials = _token.GenerateToken(usuarioExistente.CorreoInstitucional);
            _cookie.GenerateCookie(accessCredentials.accessToken);
            usuarioExistente.AccessToken = accessCredentials.accessToken;
            usuarioExistente.RefreshToken = accessCredentials.refreshToken;

            await _maestro.GuardarMaestroAsync();

            return (true, "Bienvenido", new Maestro
            {
                Id = usuarioExistente.Id,
                CorreoInstitucional = usuarioExistente.CorreoInstitucional,
                AccessToken = accessCredentials.accessToken,
            });
        }
    }
}
