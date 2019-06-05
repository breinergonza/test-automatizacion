using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProyectoApiCore.Web
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
