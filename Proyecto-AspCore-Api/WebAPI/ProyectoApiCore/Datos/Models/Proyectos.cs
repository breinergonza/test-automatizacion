using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class Proyectos
    {
        [Key]
        public int idProyecto { get; set; }

        [Required]
        [StringLength(50)]
        public string nombreProyecto { get; set; }

        [StringLength(200)]
        public string descripcionProyecto { get; set; }

        public string logoProyecto { get; set; }
    }
}
