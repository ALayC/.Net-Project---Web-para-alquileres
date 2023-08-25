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
    public class BuscarPorNombre: IBuscarPorNombre
    {
        ICabanaRepositorio cabanaRepositorio;

        public BuscarPorNombre(ICabanaRepositorio cabanaRepositorio)
        {

            this.cabanaRepositorio = cabanaRepositorio;
        }
        public IEnumerable<Cabana> Ejecutar(string nombre)
        {
            return this.cabanaRepositorio.ObtenerPorNombre(nombre);
        }
    }
}
