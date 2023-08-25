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
    public class BuscarTodas : IBuscarTodasCabanas
    {
        ICabanaRepositorio cabanaRepositorio;

        public BuscarTodas(ICabanaRepositorio cabanaRepositorio) { 
        
            this.cabanaRepositorio = cabanaRepositorio;
        }
        public IEnumerable<Cabana> Ejecutar()
        {
           return  this.cabanaRepositorio.ObtenerTodos();
        }
    }
}
