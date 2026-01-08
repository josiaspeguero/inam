using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using unam.Domain.Entities;

namespace unam.Domain.EntitiesConf
{
    public class SolicitudesConf : IEntityTypeConfiguration<Solicitud>
    {
        public void Configure(EntityTypeBuilder<Solicitud> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Apellido).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NoDocumento).HasMaxLength(30).IsRequired();
        }
    }
}
