using unam.Domain.Interfaces;

namespace unam.Application.UseCases
{
    public class AgregarSecciones
    {
        private readonly ISeccionesRepository _secciones;

        public AgregarSecciones(ISeccionesRepository secciones)
        {
            _secciones = secciones;
        }
    }
}
