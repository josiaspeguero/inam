using unam.Domain.Entities;
using unam.Domain.Interfaces;

namespace unam.Application.UseCases
{
    public class VerSolicitudes
    {
        private readonly ISolicitudesRepository _solicitudes;

        public VerSolicitudes(ISolicitudesRepository solicitudes)
        {
            _solicitudes = solicitudes;
        }
        public async Task<IEnumerable<Solicitud?>> ViewAsync(string correo)
        {
            var res = await _solicitudes.ListarSolicitudes(correo);
            return res;
        }
    }
}
