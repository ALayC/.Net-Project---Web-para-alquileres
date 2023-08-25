using Obligatorio_Aplicacion.CasosUso;
using Obligatorio_Aplicacion.InterfacesCasoUso;
using Obligatorio_Aplicacion.Servicios;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Aplicacion.CasosUso
{
    public class BuscarMantenimientoEntreFechas : IBuscarMantenimientoEntreFechas
    {
        IMantenimientoRepositorio mantenimientoRepositorio;
        public BuscarMantenimientoEntreFechas(IMantenimientoRepositorio mantenimientoRepositorio)
        {
            this.mantenimientoRepositorio = mantenimientoRepositorio;
        }
        public IEnumerable<Mantenimiento> Ejecutar(int id, DateTime fechaInicio, DateTime fechaFin)
        {
           return this.mantenimientoRepositorio.MantenimientoEntreDosFechas(id, fechaInicio, fechaFin);
        }
    }
}
