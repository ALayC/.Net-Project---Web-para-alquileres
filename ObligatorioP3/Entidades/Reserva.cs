using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio_LogicaNegocio.Entidades
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservaId { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [ForeignKey("Cabana")]
        public int CabanaId { get; set; }
        public virtual Cabana Cabana { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int NumeroHuespedes { get; set; }

        // Propiedad para almacenar el porcentaje de descuento (por ejemplo, 10% como 0.10)
        public decimal PorcentajeDescuento { get; set; }

        [NotMapped]
        public decimal CostoTotal
        {
            get
            {
                if (Cabana != null && Cabana.TipoCabana != null)
                {
                    var costoBase = NumeroHuespedes * Cabana.TipoCabana.CostoPorHuesped;
                    var descuento = costoBase * PorcentajeDescuento;
                    return costoBase - descuento;
                }
                return 0;
            }
        }
    }
}
