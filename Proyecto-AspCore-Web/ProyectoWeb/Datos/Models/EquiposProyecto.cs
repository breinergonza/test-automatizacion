using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class EquiposProyecto
    {
        [Key]
        public int idEquipoProyecto { get; set; }

        public int? idEquipo { get; set; }

        public int? idProyecto { get; set; }
    }
}
