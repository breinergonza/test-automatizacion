using System.ComponentModel.DataAnnotations;

namespace ProyectoApiCore.Web
{
    public class Equipos
    {
        [Key]
        public int idEquipo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre del Equipo")]
        public string nombreEquipo { get; set; }

        [Display(Name = "Descripción")]
        public string descripcionEquipo { get; set; }

        [Display(Name = "Logo")]
        public string logoEquipo { get; set; }
    }
}
