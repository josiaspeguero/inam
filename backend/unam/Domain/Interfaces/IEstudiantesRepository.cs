using unam.Domain.Entities;

namespace unam.Domain.Interfaces
{
    public interface IEstudiantesRepository
    {
        Task AgregarEstudiante(Estudiante estudiante);
        Task<bool> GuardarEstudiante();
        Task<bool> ActualizarEstudiante(Estudiante estudiante);
    }
}
