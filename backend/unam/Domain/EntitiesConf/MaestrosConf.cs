using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using unam.Domain.Entities;

namespace unam.Domain.EntitiesConf
{
    public class MaestrosConf : IEntityTypeConfiguration<Maestro>
    {
        public void Configure(EntityTypeBuilder<Maestro> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.Seccion)
                .WithOne(s => s.Maestro)
                .IsRequired(false)
                .HasForeignKey<Seccion>(s => s.MaestroAsignadoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
