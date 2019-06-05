using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class IntegrantesEquipo
    {
        [Key]
        public int idIntegranteEquipo { get; set; }

        public int? idIntegrante { get; set; }

        public int? idEquipo { get; set; }
    }
}
