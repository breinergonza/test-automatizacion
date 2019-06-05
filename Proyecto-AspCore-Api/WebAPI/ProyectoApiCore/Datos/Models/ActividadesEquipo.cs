using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class ActividadesEquipo
    {
        [Key]
        public int idActividadEquipo { get; set; }

        public int? idEquipo { get; set; }

        public int? idActividad { get; set; }
    }
}
