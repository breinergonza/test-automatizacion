using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class TiposDocumento
    {

        [Key]
        public int idTipoDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string nombreTipo { get; set; }

        [Required]
        [StringLength(50)]
        public string acronimoTipo { get; set; }
    }
}
