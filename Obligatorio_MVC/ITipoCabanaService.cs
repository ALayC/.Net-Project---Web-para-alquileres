using Obligatorio_MVC.Models;

namespace Obligatorio_MVC
{
    public interface ITipoCabanaService
    {

        Task<IEnumerable<TipoCabanaModel>> BuscarTipoCabanaPorNombre();

        Task<IEnumerable<TipoCabanaModel>> ListarTipoCabana(string token);

        Task<IEnumerable<TipoCabanaModel>>Alta(string nombre, string descripcion, int CostoPorHuesped,string token);


        Task<IEnumerable<TipoCabanaModel>> BuscarTipoPorNombre(string nombre, string token);


        


    }
}
