using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApiCore.Web
{
    public class EstadoActividad
    {
        [Key]
        public int idEstadoActividad { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string nombreEstado { get; set; }
    }
}
