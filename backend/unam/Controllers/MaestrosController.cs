using Microsoft.AspNetCore.Mvc;
using unam.Application.DTOs;
using unam.Application.UseCases;

namespace unam.Controllers
{
    [ApiController]
    [Route("maestros/")]
    public class MaestrosController : ControllerBase
    {
        private readonly SesionMaestro _sesionMaestro;
        public MaestrosController(SesionMaestro sesionMaestro)
        {
            _sesionMaestro = sesionMaestro;
        }

        [HttpPost("iniciar-sesion")]
        public async Task<ActionResult> IniciarSesion(IniciarSesionDTO iniciarSesionDTO)
        {
            var res = await _sesionMaestro.IniciarSesionTask(iniciarSesionDTO);
            if (!res.status)
            {
                return BadRequest(res.message);
            }
            return Ok(res.message);
        }
    }
}
