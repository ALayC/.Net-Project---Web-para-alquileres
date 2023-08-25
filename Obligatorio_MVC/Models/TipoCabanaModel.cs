using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio_MVC.Models
{
    public class TipoCabanaModel
    {
        [Key]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal CostoPorHuesped { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoCabana { get; set; }
    }
}
