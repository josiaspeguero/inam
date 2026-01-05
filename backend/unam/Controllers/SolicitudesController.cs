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
        private readonly VerSolicitudes _verSolicitudes;

        public SolicitudesController(CrearSolicitud crearSolicitud, VerSolicitudes verSolicitudes)
        {
            _crearSolicitud = crearSolicitud;
            _verSolicitudes = verSolicitudes;
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

        [HttpGet("mis-solicitudes/{correo}")]
        public async Task<ActionResult> ListarSolicitudes(string correo)
        {
            var res = await _verSolicitudes.ViewAsync(correo);
            return Ok(res);
        }
    }
}
