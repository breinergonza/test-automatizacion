using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class Equipos
    {
        [Key]
        public int idEquipo { get; set; }

        [Required]
        [StringLength(50)]
        public string nombreEquipo { get; set; }

        public string descripcionEquipo { get; set; }

        public string logoEquipo { get; set; }
    }
}
