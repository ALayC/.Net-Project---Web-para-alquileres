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
    public class CabanaObtenerPorCantidadMaxima: ICabanaObtenerPorCantidadMaxima
    {
        ICabanaRepositorio cabanaRepositorio;

        public CabanaObtenerPorCantidadMaxima(ICabanaRepositorio cabanaRepositorio)
        {
            this.cabanaRepositorio = cabanaRepositorio;
        }
        public IEnumerable<Cabana> Ejecutar(int max)
        {
            if (max == null) throw new ArgumentNullException("El nombre es nulo, no se puede continuar");
            return this.cabanaRepositorio.ObtenerPorCantidadMaxima(max);
        }
    }
}
