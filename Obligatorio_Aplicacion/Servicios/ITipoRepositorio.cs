using Obligatorio_Aplicacion.Comun;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Aplicacion.Servicios
{
    public interface ITipoCabanaRepositorio : IRepositorio<TipoCabana>
    {
        IEnumerable<TipoCabana> AgregarTipo(TipoCabana entidad);
        List<TipoCabana> BuscarTipoCabanaPorNombre(string nombre);

        List<TipoCabana> ListarTipoCabana();



    }
}
