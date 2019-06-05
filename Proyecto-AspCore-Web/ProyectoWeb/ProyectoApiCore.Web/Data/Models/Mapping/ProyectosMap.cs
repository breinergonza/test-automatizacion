using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProyectoApiCore.Web
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
