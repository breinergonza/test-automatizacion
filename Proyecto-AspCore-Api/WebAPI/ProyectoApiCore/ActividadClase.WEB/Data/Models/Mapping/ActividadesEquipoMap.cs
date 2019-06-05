using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Models
{
    public class ActividadesEquipoMap : IEntityTypeConfiguration<ActividadesEquipo>
    {
        public void Configure(EntityTypeBuilder<ActividadesEquipo> builder)
        {
            builder.ToTable("ActividadesEquipo")
                .HasKey(c => c.idActividadEquipo);
        }
    }
}
