using System.ComponentModel.DataAnnotations;

namespace ProyectoApiCore.Web
{
    public class Proyectos
    {
        [Key]
        public int idProyecto { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombreProyecto { get; set; }

        [StringLength(200)]
        [Display(Name = "Descripcion")]
        public string descripcionProyecto { get; set; }

        [Display(Name = "Logo")]
        public string logoProyecto { get; set; }
    }
}
