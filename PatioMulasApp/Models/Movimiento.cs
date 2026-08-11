using System.ComponentModel.DataAnnotations;

namespace PatioMulasApp.Models
{
    public class Movimiento
    {
        public int Id { get; set; }

        [Required]
        public int UnidadId { get; set; }

        [Required]
        public int ConductorId { get; set; }

        [Required]
        public string TipoMovimiento { get; set; } = "";

        [Required]
        public DateTime FechaHora { get; set; }

        public string UbicacionExterna { get; set; } = "";

        public string Observacion { get; set; } = "";
    }
}