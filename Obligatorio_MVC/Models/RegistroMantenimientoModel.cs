namespace Obligatorio_MVC.Models
{
    public class RegistroMantenimientoModel
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public string descripcion { get; set; }
        public int costo { get; set; }
        public string trabajador { get; set; }
    }
}
