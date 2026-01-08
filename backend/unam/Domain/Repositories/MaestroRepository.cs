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
