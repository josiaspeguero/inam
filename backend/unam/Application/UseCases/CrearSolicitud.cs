using AutoMapper;
using unam.Application.DTOs;
using unam.Domain.Entities;
using unam.Domain.Interfaces;

namespace unam.Application.UseCases
{
    public class CrearSolicitud
    {
        private readonly ISolicitudesRepository _solicitudes;
        private readonly IMapper _mapper;

        public CrearSolicitud(ISolicitudesRepository solicitudes, IMapper mapper)
        {
            _solicitudes = solicitudes;
            _mapper = mapper;
        }
        public async Task<(bool status, string message)> CreateAsync(SolicitudDTO solicitudDTO)
        {
            var nuevaSolicitud = _mapper.Map<Solicitud>(solicitudDTO);
            await _solicitudes.AgregarSolicitud(nuevaSolicitud);
            var estadoSolicitud = await _solicitudes.GuardarSolicitud();
            if (!estadoSolicitud)
            {
                return (false, "No se pudo crear la solicitud");
            }
            return (true, "Solicitud creada correctamente");
        }
    }
}
