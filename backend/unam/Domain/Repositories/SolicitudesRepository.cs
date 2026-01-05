using unam.Context;
using unam.Domain.Entities;
using unam.Domain.Interfaces;

namespace unam.Domain.Repositories
{
    public class SolicitudesRepository : ISolicitudesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SolicitudesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> ActualizarSolicitud(Solicitud solicitud)
        {
            throw new NotImplementedException();
        }

        public async Task AgregarSolicitud(Solicitud solicitud)
        {
            await _dbContext.AddAsync(solicitud);
        }

        public async Task<bool> GuardarSolicitud()
        {
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
