using System.ComponentModel.DataAnnotations;

namespace Web_API.DTOs
{
    public class BuscarTodasCabanasDTO
    {
        public string Nombre { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Descripcion { get; set; }
        public bool JacuzziPrivado { get; set; }
        public bool HabilitadaReservas { get; set; }
        public int NumeroHabitacion { get; set; }

        public int CapacidadMaxima { get; set; }

    }
}
