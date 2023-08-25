using Obligatorio_MVC.Models;

namespace Obligatorio_MVC
{
    public interface IMantenimientoService
    {

        Task<IEnumerable<MantenimientoModel>> ObtenerTodos();
        Task<IEnumerable<MantenimientoModel>> BuscarMantenimientoEntreFechas(int id, DateTime fechaInicio, DateTime fechaFin, string token);

        Task<IEnumerable<MantenimientoModel>> RegistroMantenimiento(int id, DateTime fecha, int costo, string descripcion, string trabajador, string token);

    }
}
