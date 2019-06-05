using System.ComponentModel.DataAnnotations;

namespace ProyectoApiCore.Web
{
    public class TiposDocumento
    {

        [Key]
        public int idTipoDocumento { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombreTipo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Acronimo")]
        public string acronimoTipo { get; set; }
    }
}
