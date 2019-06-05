using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Models
{
    public class EstadoActividadMap : IEntityTypeConfiguration<EstadoActividad>
    {
        public void Configure(EntityTypeBuilder<EstadoActividad> builder)
        {
            builder.ToTable("EstadoActividad")
                .HasKey(c => c.idEstadoActividad);
        }
    }
}
