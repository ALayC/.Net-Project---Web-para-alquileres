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
    public class BuscarCabanaPorTipo: IBuscarCabanaPorTipo
    {
        ICabanaRepositorio cabanaRepositorio;

        public BuscarCabanaPorTipo(ICabanaRepositorio cabanaRepositorio)
        {

            this.cabanaRepositorio = cabanaRepositorio;
        }
        public IEnumerable<Cabana> Ejecutar(string tipo)
        {
            return this.cabanaRepositorio.ObtenerPorTipo(tipo);
        }
    }
}
