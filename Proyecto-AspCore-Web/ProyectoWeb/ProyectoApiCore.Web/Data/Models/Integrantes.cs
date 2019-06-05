using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoApiCore.Web
{
    public class Integrantes
    {
        [Key]
        public int idIntegrante { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nro. Documento")]
        public string numeroDocumento { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Primer Nombre")]
        public string primerNombre { get; set; }

        [StringLength(50)]
        [Display(Name = "Segundo Nombre")]
        public string segundoNombre { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Primer Apellido")]
        public string primerApellido { get; set; }

        [StringLength(50)]
        [Display(Name = "Segundo Apellido")]
        public string segundoApellido { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? fechaNacimiento { get; set; }

        [Display(Name = "Tipo de Documento")]
        public int? idTipoDocumento { get; set; }
    }
}
