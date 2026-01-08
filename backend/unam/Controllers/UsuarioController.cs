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

        public UsuarioController(CrearCuenta crearCuenta)
        {
            _crearCuenta = crearCuenta;
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
    }
}
