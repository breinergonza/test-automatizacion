using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Models
{
    public class ProyectosMap : IEntityTypeConfiguration<Proyectos>
    {
        public void Configure(EntityTypeBuilder<Proyectos> builder)
        {
            builder.ToTable("Proyectos")
                .HasKey(c => c.idProyecto);
        }
    }
}
