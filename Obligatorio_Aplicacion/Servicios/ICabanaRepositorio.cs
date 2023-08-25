using Obligatorio_Aplicacion.Comun;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Aplicacion.Servicios
{
    public interface ICabanaRepositorio : IRepositorio<Cabana>
    {
        List<Cabana> ObtenerPorNombre(string nombre);
        List<Cabana> ObtenerPorTipo(string tipo);
        List<Cabana> ObtenerPorCantidadMaxima(int max);
        List<Cabana> BuscarHabilitadas();
        List<Cabana> BuscarTodas();

        List<Cabana> BuscarPorTipoyMonto(string tipo, int monto);
        List<Cabana> BusquedaCapacidad(int min, int max);


    }
}
