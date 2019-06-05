using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Models
{
    public class EquiposMap : IEntityTypeConfiguration<Equipos>
    {
        public void Configure(EntityTypeBuilder<Equipos> builder)
        {
            builder.ToTable("Equipos")
                .HasKey(c => c.idEquipo);
        }
    }
}
