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
    public class RegistroMantenimiento : IRegistroMantenimiento
    {
        IMantenimientoRepositorio mantenimientoRepositorio;

        public RegistroMantenimiento(IMantenimientoRepositorio mantenimientoRepositorio)
        {
            this.mantenimientoRepositorio = mantenimientoRepositorio;
        }

        public IEnumerable<Mantenimiento> Ejecutar(int id, DateTime fecha, int costo, string descripcion, string trabajador)
        {
           return this.mantenimientoRepositorio.AgregarNuevoMantenimiento(id, fecha, costo, descripcion, trabajador);
        }
    }
}
