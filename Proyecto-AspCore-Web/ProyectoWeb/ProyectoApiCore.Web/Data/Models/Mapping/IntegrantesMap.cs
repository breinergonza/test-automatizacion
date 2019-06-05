using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProyectoApiCore.Web
{
    public class IntegrantesMap : IEntityTypeConfiguration<Integrantes>
    {
        public void Configure(EntityTypeBuilder<Integrantes> builder)
        {
            builder.ToTable("Integrantes")
                .HasKey(c => c.idIntegrante);
        }
    }
}
