using Microsoft.EntityFrameworkCore;
using System.Reflection;
using unam.Domain.Entities;

namespace unam.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected ApplicationDbContext()
        {
        }
        public DbSet<Solicitud> Solicitudes => Set<Solicitud>();
        public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
        public DbSet<Maestro> Maestros => Set<Maestro>();
        public DbSet<Seccion> Secciones => Set<Seccion>();
    }
}
