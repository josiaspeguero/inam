using unam.Domain.Interfaces;

namespace unam.Application.UseCases
{
    public class AprobarSolicitud
    {
        private readonly ISolicitudesRepository _solicitudes;
        private readonly AgregarEstudiante _agregarEstudiante;
        private readonly AgregarMaestro _agregarMaestro;

        public AprobarSolicitud(ISolicitudesRepository solicitudes, AgregarEstudiante agregarEstudiante,
            AgregarMaestro agregarMaestro)
        {
            _solicitudes = solicitudes;
            _agregarEstudiante = agregarEstudiante;
            _agregarMaestro = agregarMaestro;
        }
        public async Task<(bool status, string message)> AprobarSolicitudTask(string correo)
        {
            var solicitudExistente = await _solicitudes.ListarSolicitudes(correo);
            if (solicitudExistente == null)
            {
                return (false, "La solicitud no existe");
            }
            solicitudExistente.IsAprobada = true;
            var solicitudActualizada = await _solicitudes.GuardarSolicitud();
            if (!solicitudActualizada)
            {
                return (false, "Ha ocurrido un error");
            }

            //validar tipo de solicitud
            if (solicitudExistente.TipoSolicitud == "Estudiante")
            {
                await _agregarEstudiante.AgregarEstudianteTask(solicitudExistente);
            }
            else if (solicitudExistente.TipoSolicitud == "Maestro")
            {
                await _agregarMaestro.AgregarMaestroTask(solicitudExistente);
            }

            return (true, "Solicitud actualizada");
        }
    }
}
