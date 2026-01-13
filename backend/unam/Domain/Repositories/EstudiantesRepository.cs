using Microsoft.EntityFrameworkCore;
using unam.Application.DTOs;
using unam.Context;
using unam.Domain.Entities;
using unam.Domain.Interfaces;

namespace unam.Domain.Repositories
{
    public class EstudiantesRepository : IEstudiantesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EstudiantesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Estudiante?> AccederAsync(IniciarSesionDTO iniciarSesion)
        {
            var res = await _dbContext.Estudiantes.Where(e => e.CorreoEstudiantil == iniciarSesion.Correo
            && e.Pin.ToString() == iniciarSesion.Contrasena).FirstOrDefaultAsync();
            return res;
        }

        public Task<bool> ActualizarEstudiante(Estudiante estudiante)
        {
            throw new NotImplementedException();
        }

        public async Task AgregarEstudiante(Estudiante estudiante)
        {
            await _dbContext.AddAsync(estudiante);
        }

        public async Task<bool> GuardarEstudiante()
        {
            try
            {
                var res = await _dbContext.SaveChangesAsync();
                return res > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
