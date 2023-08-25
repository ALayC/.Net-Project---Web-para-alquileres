////using Microsoft.Build.Evaluation;
//using Obligatorio_LogicaNegocio.Entidades;

namespace Obligatorio_MVC.Models

{
    public class MantenimientoViewModel
    {
        public int id { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        //public List<Mantenimiento> mantenimientos { get; set; }

        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public int costo { get; set; }
        public string trabajador { get; set; }

        //public MantenimientoViewModel()
        //{
        //    mantenimientos = new List<Mantenimiento>();
        //}
        public string Error { get; set; }
    }

}
