using Microsoft.EntityFrameworkCore;
using unam.Application.DTOs;
using unam.Context;
using unam.Domain.Entities;
using unam.Domain.Interfaces;

namespace unam.Domain.Repositories
{
    public class MaestroRepository : IMaestrosRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MaestroRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Maestro?> AccederAsync(IniciarSesionDTO iniciarSesion)
        {
            var res = await _dbContext.Maestros.Where(e => e.CorreoInstitucional == iniciarSesion.Correo
            && e.Pin.ToString() == iniciarSesion.Contrasena).FirstOrDefaultAsync();
            return res;
        }

        public Task<bool> ActualizarMaestroAsync(Maestro maestro)
        {
            throw new NotImplementedException();
        }

        public async Task AgregarMaestroAsync(Maestro maestro)
        {
            await _dbContext.AddAsync(maestro);
        }

        public async Task<bool> GuardarMaestroAsync()
        {
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;
        }
    }
}
