using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProyectoApiCore.Web
{
    public class EquiposProyectoMap : IEntityTypeConfiguration<EquiposProyecto>
    {
        public void Configure(EntityTypeBuilder<EquiposProyecto> builder)
        {
            builder.ToTable("EquiposProyecto")
                .HasKey(c => c.idEquipoProyecto);
        }
    }
}
