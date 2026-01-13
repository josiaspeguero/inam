using unam.Domain.Entities;
using unam.Domain.Interfaces;

namespace unam.Application.UseCases
{
    public class AgregarEstudiante
    {
        private readonly IEstudiantesRepository _estudiantes;
        private readonly Random _random = new();

        public AgregarEstudiante(IEstudiantesRepository estudiantes)
        {
            _estudiantes = estudiantes;
        }
        public async Task<string> AgregarEstudianteTask(Solicitud solicitud)
        {
            var matricula = _random.Next(100000, 999999).ToString();
            var pin = _random.Next(10000, 99999).ToString();
            var nuevoEstudiante = new Estudiante
            {
                FechaIngreso = DateTime.UtcNow,
                Matricula = matricula,
                CorreoEstudiantil = matricula + "@unad.com.do",
                Pin = pin
            };
            await _estudiantes.AgregarEstudiante(nuevoEstudiante);
            var estudianteAgregado = await _estudiantes.GuardarEstudiante();
            if (!estudianteAgregado)
            {
                return "No se puedo agregar el estudiante";
            }
            return "Estudiante creado";
        }
    }
}
