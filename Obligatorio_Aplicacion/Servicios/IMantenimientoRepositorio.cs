using Obligatorio_Aplicacion.Comun;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Aplicacion.Servicios
{
    public interface IMantenimientoRepositorio : IRepositorio<Mantenimiento>
    {

        List<Mantenimiento> MantenimientoEntreDosFechas(int id, DateTime fechaInicio, DateTime fechaFin);
        List<Mantenimiento> AgregarNuevoMantenimiento(int id, DateTime fecha, int costo, string descripcion, string trabajador);
    }
}
