using Microsoft.EntityFrameworkCore;
using unam.Application.DTOs;
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
        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
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

        public async Task<Usuario?> IniciarSesionAsync(IniciarSesionDTO iniciarSesionDTO)
        {

            return await _dbContext.Usuarios
                .Where(u => u.Correo == iniciarSesionDTO.Correo && u.Contrasena == iniciarSesionDTO.Contrasena)
                .FirstOrDefaultAsync();
        }
    }
}
