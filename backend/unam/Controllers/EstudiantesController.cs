using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unam.Application.DTOs;
using unam.Application.UseCases;

namespace unam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly SesionEstudiante _sesionEstudiante;

        public EstudiantesController(SesionEstudiante sesionEstudiante)
        {
            _sesionEstudiante = sesionEstudiante;
        }
        [HttpPost("iniciar-sesion")]
        public async Task<ActionResult> IniciarSesion(IniciarSesionDTO iniciarSesionDTO)
        {
            var res = await _sesionEstudiante.IniciarSesionTask(iniciarSesionDTO);
            if (!res.status)
            {
                return BadRequest(res.message);
            }
            return Ok(res.message);
        }
    }
}
