using System.Net;
using unam.Application.DTOs;
using unam.Domain.Entities;
using unam.Domain.Interfaces;
using unam.Services;

namespace unam.Application.UseCases
{
    public class SesionEstudiante
    {
        private readonly IEstudiantesRepository _estudiantes;
        private readonly IToken _token;
        private readonly ICookie _cookie;

        public SesionEstudiante(IEstudiantesRepository estudiantes, IToken token, ICookie cookie)
        {
            _estudiantes = estudiantes;
            _token = token;
            _cookie = cookie;
        }

        public async Task<(bool status, string message, object? usuario)> IniciarSesionTask(IniciarSesionDTO iniciarSesionDTO)
        {
            var usuarioExistente = await _estudiantes.AccederAsync(iniciarSesionDTO);
            if (usuarioExistente == null)
            {
                return (false, "Credenciales incorrectas", new
                {
                    mensaje = "No se encuentra el usuario"
                });
            }
            var accessCredentials = _token.GenerateToken(usuarioExistente.CorreoEstudiantil);
            _cookie.GenerateCookie(accessCredentials.accessToken);
            usuarioExistente.AccessToken = accessCredentials.accessToken;
            usuarioExistente.RefreshToken = accessCredentials.refreshToken;

            await _estudiantes.GuardarEstudiante();

            return (true, "Bienvenido", new Estudiante
            {
                Id = usuarioExistente.Id,
                CorreoEstudiantil = usuarioExistente.CorreoEstudiantil,
                AccessToken = accessCredentials.accessToken,
            });
        }
    }
}
