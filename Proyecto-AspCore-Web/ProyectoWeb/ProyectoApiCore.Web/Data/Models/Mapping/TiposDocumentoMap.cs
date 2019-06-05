using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProyectoApiCore.Web
{
    public class TiposDocumentoMap : IEntityTypeConfiguration<TiposDocumento>
    {
        public void Configure(EntityTypeBuilder<TiposDocumento> builder)
        {
            builder.ToTable("TiposDocumento")
                .HasKey(c => c.idTipoDocumento);
        }
    }
}
