using System;
using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class Integrantes
    {
        [Key]
        public int idIntegrante { get; set; }

        [Required]
        [StringLength(50)]
        public string numeroDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string primerNombre { get; set; }

        [StringLength(50)]
        public string segundoNombre { get; set; }

        [Required]
        [StringLength(50)]
        public string primerApellido { get; set; }

        [StringLength(50)]
        public string segundoApellido { get; set; }

        public DateTime? fechaNacimiento { get; set; }

        public int? idTipoDocumento { get; set; }
    }
}
