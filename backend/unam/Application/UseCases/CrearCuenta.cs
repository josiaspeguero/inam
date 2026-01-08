using AutoMapper;
using unam.Application.DTOs;
using unam.Domain.Entities;
using unam.Domain.Interfaces;

namespace unam.Application.UseCases
{
    public class CrearCuenta
    {
        private readonly IUsuarioRepository _usuario;
        private readonly IMapper _mapper;

        public CrearCuenta(IUsuarioRepository usuario, IMapper mapper)
        {
            _usuario = usuario;
            _mapper = mapper;
        }
        public async Task<(bool status, string message)> CrearUsuarioTask(UsuarioDTO usuarioDTO)
        {
            var usuarioExistente = await _usuario.BuscarUsuarioAsync(usuarioDTO.Correo);
            if (usuarioExistente != null)
            {
                return (false, "Ya existe un usuario con esa cuenta");
            }
            var nuevoUsuario = _mapper.Map<Usuario>(usuarioDTO);
            await _usuario.AgregarUsuarioAsync(nuevoUsuario);
            var usuarioGuardado = await _usuario.GuardarUsuarioAsync();
            if (!usuarioGuardado)
            {
                return (false, "Ha ocurrido un error");
            }
            return (true, "Usuario creado correctamente");
        }
    }
}
