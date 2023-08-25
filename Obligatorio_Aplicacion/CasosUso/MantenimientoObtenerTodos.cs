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
    public class MantenimientoObtenerTodos: IMantenimientoObtenerTodos
    {
        IMantenimientoRepositorio mantenimientoRepositorio;

        public MantenimientoObtenerTodos(IMantenimientoRepositorio mantenimientoRepositorio)
        {

            this.mantenimientoRepositorio = mantenimientoRepositorio;
        }
        public IEnumerable<Mantenimiento> Ejecutar()
        {
            return this.mantenimientoRepositorio.ObtenerTodos();
        }
    }
}
