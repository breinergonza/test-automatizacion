using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Models
{
    public class ActividadesMap : IEntityTypeConfiguration<Actividades>
    {
        public void Configure(EntityTypeBuilder<Actividades> builder)
        {
            builder.ToTable("Actividades")
                .HasKey(c => c.idActividad);
        }
    }
}
