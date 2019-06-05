using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IC.DTOAdicionales
{
    public class AccesoUsuario
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string usuario { get; set; }

        [Required]
        public string contrasena { get; set; }
    }
}
