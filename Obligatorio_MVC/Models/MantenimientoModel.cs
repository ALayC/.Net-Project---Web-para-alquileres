using System.ComponentModel.DataAnnotations;

namespace Obligatorio_MVC.Models
{
    public class MantenimientoModel
    {

        public DateTime Fecha { get; set; }
        [Key]
        public string Descripcion { get; set; }

        public decimal Costo { get; set; }

        public string Trabajador { get; set; }

        public int NumeroHabitacion { get; set; }
    }

}
