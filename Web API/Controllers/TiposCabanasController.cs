using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Obligatorio_Aplicacion.Servicios;
using Obligatorio_LogicaNegocio.Entidades;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TiposCabanasController : ControllerBase
    {
        private readonly ITipoCabanaRepositorio ucBuscarTipoCabanaPorNombre;

        public TiposCabanasController(ITipoCabanaRepositorio ucBuscarTipoCabanaPorNombre)
        {
            this.ucBuscarTipoCabanaPorNombre = ucBuscarTipoCabanaPorNombre;
        }

        [HttpPost]
        [Route("Alta/{nombre}/{descripcion}/{CostoPorHuesped}")]
        public ActionResult<TipoCabana> Alta(string nombre, string descripcion, decimal CostoPorHuesped)
        {
            TipoCabana tipoCabana = new TipoCabana();
            tipoCabana.Nombre = nombre;
            tipoCabana.Descripcion = descripcion;
            tipoCabana.CostoPorHuesped = CostoPorHuesped;

           ucBuscarTipoCabanaPorNombre.Agregar(tipoCabana);
            return Ok();

        }


        [HttpGet]
        [Route("ListarTipoCabana")]
        public IEnumerable<TipoCabana> ListarTipoCabana()
        {
            return ucBuscarTipoCabanaPorNombre.ListarTipoCabana();

        }

        [HttpGet]
        [Route("BuscarTipoPorNombre/{nombre}")]
        public IEnumerable<TipoCabana> BuscarTipoPorNombre(string nombre)
        {
            return ucBuscarTipoCabanaPorNombre.BuscarTipoCabanaPorNombre(nombre);

        }

        
    }
}

