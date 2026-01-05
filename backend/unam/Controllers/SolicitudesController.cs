using Microsoft.AspNetCore.Mvc;
using unam.Application.DTOs;
using unam.Application.UseCases;

namespace unam.Controllers
{
    [ApiController]
    [Route("solicitudes/")]
    public class SolicitudesController : ControllerBase
    {
        private readonly CrearSolicitud _crearSolicitud;

        public SolicitudesController(CrearSolicitud crearSolicitud)
        {
            _crearSolicitud = crearSolicitud;
        }
        [HttpPost("crear-solicitud")]
        public async Task<ActionResult> CrearSolicitud(SolicitudDTO solicitud)
        {
            var res = await _crearSolicitud.CreateAsync(solicitud);
            if (!res.status)
            {
                return BadRequest(res.message);
            }
            return Ok(res.message);
        }
    }
}
