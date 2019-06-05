using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProyectoApiCore.Web
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
