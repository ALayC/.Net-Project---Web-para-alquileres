using NuGet.Common;
using Obligatorio_MVC.Models;

namespace Obligatorio_MVC
{
    public interface ICabanaService
    {

        Task<IEnumerable<CabanaModel>> ObtenerTodas();
        Task<IEnumerable<CabanaModel>> BuscarPorNombre(string nombre, string token);
        Task<IEnumerable<CabanaModel>> BuscarCabanaPorTipo(string tipo, string token);
        Task<IEnumerable<CabanaModel>> BuscarCabanaPorCantidadMaximaDePersonas(int maxpersonas, string token  );
        Task<IEnumerable<CabanaModel>> BuscarCabanasHabilitadas(string token);
        Task<IEnumerable<CabanaModel>> BuscarTodas(string token);
        Task<IEnumerable<CabanaModel>> BuscarCabanas(string token);

        Task<IEnumerable<CabanaModel>> BuscarPorTipoyMonto(ParaBuscarPorTipoyMontoModel model, string token);
        //Task<IEnumerable<CabanaModel>> BusquedaCapacidad(ModelParaBusquedaCapacidad model, string token);
        Task<IEnumerable<CabanaModel>> BusquedaCapacidad(int min, int max ,string token);
    }
}
