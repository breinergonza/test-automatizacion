using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Models
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
