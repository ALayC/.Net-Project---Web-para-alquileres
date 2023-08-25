using Obligatorio_Aplicacion.InterfacesCasoUso;
using Obligatorio_Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Aplicacion.CasosUso
{
    public class CabanaObtenerPorNombre : ICabanaObtenerPorNombre
    {
        ICabanaRepositorio cabanaRepositorio;

        public CabanaObtenerPorNombre(ICabanaRepositorio cabanaRepositorio)
        {
            this.cabanaRepositorio = cabanaRepositorio;
        }
        public void Ejecutar(string nombre)
        {
            if (!string.IsNullOrEmpty(nombre)) throw new ArgumentNullException("El nombre es nulo, no se puede continuar");
            this.cabanaRepositorio.ObtenerPorNombre(nombre);
        }
    }
}
