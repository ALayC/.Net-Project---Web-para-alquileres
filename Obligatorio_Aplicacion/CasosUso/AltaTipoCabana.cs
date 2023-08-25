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
    public class AltaTipoCabana: IAltaTipo
    {
        ITipoCabanaRepositorio  tipoCabanaRepositorio;

        public AltaTipoCabana(ITipoCabanaRepositorio tipoCabanaRepositorio)
        {

            this.tipoCabanaRepositorio = tipoCabanaRepositorio;
        }
        public IEnumerable<TipoCabana> Ejecutar(string nombre, string descripcion, decimal CostoPorHuesped)
        {
            TipoCabana tipocabana = new TipoCabana();
            tipocabana.Nombre = nombre;
            tipocabana.Descripcion = descripcion;
            tipocabana.CostoPorHuesped = CostoPorHuesped;
           this.tipoCabanaRepositorio.Agregar(tipocabana);
            return this.tipoCabanaRepositorio.ObtenerTodos();
        }

    }
}
