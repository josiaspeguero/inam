using Microsoft.EntityFrameworkCore;
using unam.Context;
using unam.Domain.Entities;
using unam.Domain.Interfaces;

namespace unam.Domain.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario?> ActualizarUsuarioAsync(Usuario usuario)
        {
            var res = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Correo == usuario.Correo);
            if (res != null)
            {
                throw new Exception("No se ha encontrado el usuario");
            }
            return res;
        }

        public async Task AgregarUsuarioAsync(Usuario usuario)
        {
            await _dbContext.AddAsync(usuario);
        }

        public async Task<Usuario?> BuscarUsuarioAsync(string correo)
        {
            return await _dbContext.Usuarios
                .Where(u => u.Correo == correo)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> GuardarUsuarioAsync()
        {
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;
        }
    }
}
