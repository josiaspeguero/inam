using unam.Domain.Entities;

namespace unam.Domain.Interfaces
{
    public interface IEstudiantesRepository
    {
        Task AgregarEstudiante(Estudiante estudiante);
        Task<bool> AgregarEstudiante();
        Task<bool> ActualizarEstudiante(Estudiante estudiante);
    }
}
