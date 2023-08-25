namespace Obligatorio_MVC.Models
{
    public class BuscarMantenimientoRequest
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public string descripcion { get; set; }
        public int costo { get; set; }
        public string trabajador { get; set; }



    }
}
