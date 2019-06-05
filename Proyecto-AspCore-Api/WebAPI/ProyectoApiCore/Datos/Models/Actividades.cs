using System;
using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class Actividades
    {
        [Key]
        public int idActividad { get; set; }

        [Required]
        [StringLength(50)]
        public string nombreActividad { get; set; }

        public string descripcionActividad { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime? fechaFin { get; set; }

        public int? idEstadoActividad { get; set; }
    }
}
