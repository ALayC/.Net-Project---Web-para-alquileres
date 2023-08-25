//using Obligatorio_LogicaNegocio.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio_MVC.Models
{
    public class CabanaModel
    {



        [Key]
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$",
         ErrorMessage = "El nombre debe incluir solo caracteres alfabéticos y espacios embebidos (no al principio ni al final)")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        [DisplayName("Descripcion de la cabana")]
        public string Descripcion { get; set; }
        public bool JacuzziPrivado { get; set; }
        public bool HabilitadaReservas { get; set; }
        public int NumeroHabitacion { get; set; }

        public int CapacidadMaxima { get; set; }

        public string Imagen { get; set; }
        public TipoCabanaModel TipoCabana { get; set; }
        public List<MantenimientoModel> Mantenimientos { get; set; }

    }
}
