using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Models
{
    public class IntegrantesEquipoMap : IEntityTypeConfiguration<IntegrantesEquipo>
    {
        public void Configure(EntityTypeBuilder<IntegrantesEquipo> builder)
        {
            builder.ToTable("IntegrantesEquipo")
                .HasKey(c => c.idIntegranteEquipo);
        }
    }
}
