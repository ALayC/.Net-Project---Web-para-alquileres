namespace Obligatorio_MVC.Models
{
    public class ModelParaBusquedaCapacidad
    {

        public int min { get; set; }
        public int max { get; set; }

        public CabanaModel cabana { get; set; }
        public TipoCabanaModel TipoCabana { get; set; }
    }
}
