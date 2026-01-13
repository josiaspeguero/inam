using Microsoft.EntityFrameworkCore;
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
            try
            {
                var result = await _dbContext.SaveChangesAsync();
                if (result <= 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Solicitud?> ListarSolicitudes(string correo)
        {
            return await _dbContext.Solicitudes.Where(s => s.Correo == correo && s.IsAprobada == false).FirstOrDefaultAsync();
        }
    }
}
