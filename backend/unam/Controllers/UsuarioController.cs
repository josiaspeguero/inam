using Microsoft.AspNetCore.Mvc;
using unam.Application.DTOs;
using unam.Application.UseCases;

namespace unam.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly CrearCuenta _crearCuenta;
        private readonly IniciarSesion _iniciarSesion;

        public UsuarioController(CrearCuenta crearCuenta, IniciarSesion iniciarSesion)
        {
            _crearCuenta = crearCuenta;
            _iniciarSesion = iniciarSesion;
        }
        [HttpPost("crear-cuenta")]
        public async Task<ActionResult> CrearCuenta(UsuarioDTO usuario)
        {
            var res = await _crearCuenta.CrearUsuarioTask(usuario);
            if (!res.status)
            {
                return BadRequest(res.message);
            }
            return Ok(res.message);
        }

        [HttpPost("iniciar-sesion")]
        public async Task<ActionResult> IniciarSesion(IniciarSesionDTO iniciarSesionDTO)
        {
            var res = await _iniciarSesion.IniciarSesionTask(iniciarSesionDTO);
            if (!res.status)
            {
                return BadRequest(res.message);
            }
            return Ok(res.usuario);
        }
    }
}
