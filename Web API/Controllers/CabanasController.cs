using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Aplicacion.InterfacesCasoUso;
using Obligatorio_Aplicacion.Servicios;
using Obligatorio_LogicaNegocio.Entidades;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CabanasController : ControllerBase
    {
        private readonly ICabanaRepositorio ucObtenerListaCabanas;
        private readonly IBuscarTodasCabanas ucBuscarTodasCabanas;
        private readonly IBuscarCabanasHabilitadas ucBuscarCabanasHabilitadas;
        private readonly ICabanaObtenerPorCantidadMaxima ucObtenerPorCantidadMaxima;
        private readonly IBuscarCabanaPorTipo ucBuscarCabanaPorTipo;
        private readonly IBuscarPorNombre ucBuscarPorNombre;


        public CabanasController(ICabanaRepositorio ucObtenerListaCabanas, IBuscarTodasCabanas ucBuscarTodasCabanas, IBuscarCabanasHabilitadas ucBuscarCabanasHabilitadas, ICabanaObtenerPorCantidadMaxima ucObtenerPorCantidadMaxima, IBuscarCabanaPorTipo ucBuscarCabanaPorTipo, IBuscarPorNombre ucBuscarPorNombre)
        {
            this.ucObtenerListaCabanas = ucObtenerListaCabanas;
            this.ucBuscarTodasCabanas = ucBuscarTodasCabanas;
            this.ucBuscarCabanasHabilitadas = ucBuscarCabanasHabilitadas;
            this.ucObtenerPorCantidadMaxima = ucObtenerPorCantidadMaxima;
            this.ucBuscarCabanaPorTipo = ucBuscarCabanaPorTipo;
            this.ucBuscarPorNombre = ucBuscarPorNombre;
        }



        [HttpGet]
        [Route("BuscarPorTipoyMonto/{tipo}/{monto}")]          
        public IEnumerable<Cabana> BuscarPorTipoyMonto(string tipo, int monto)
        {

            return ucObtenerListaCabanas.BuscarPorTipoyMonto(tipo,monto);
        }



        [HttpGet]
        [Route("BuscarCabanaPorNombre/{nombre}")]
        public IEnumerable<Cabana> BuscarPorNombre(string nombre)
        {

            return ucBuscarPorNombre.Ejecutar(nombre);
        }
        [HttpGet]
        [Route("BuscarCabanaPorTipo/{tipo}")]
        public IEnumerable<Cabana> BuscarCabanaPorTipo(string tipo)
        {

            return ucBuscarCabanaPorTipo.Ejecutar(tipo);
        }
        [HttpGet]
        [Route("BuscarCabanaPorCantidadMaximaDePersonas/{maxpersonas}")]
        public IEnumerable<Cabana> BuscarCabanaPorCantidadMaximaDePersonas(int maxpersonas)
        {

            return ucObtenerPorCantidadMaxima.Ejecutar(maxpersonas);
        }
        [HttpGet]
        [Route("BuscarCabanasHabilitadas")]
        public IEnumerable<Cabana> BuscarCabanasHabilitadas()
        {

            return ucBuscarCabanasHabilitadas.Ejecutar();
        }
        [HttpGet]
        [Route("BuscarTodas")]
        public IEnumerable<Cabana> BuscarTodas()
        {
            return  ucBuscarTodasCabanas.Ejecutar();
           

        }
        [HttpGet]
        [Route("BuscarCabanas")]
        public IEnumerable<Cabana> BuscarCabanas()
        {

            return ucObtenerListaCabanas.BuscarTodas();
        }


        [HttpGet]
        [Route("BusquedaCapacidad/{min}/{max}")]
        public IEnumerable<CabanasFiltradasPorCapacidad> BusquedaCapacidad(int min, int max)
        {
            List<Cabana> cabanasFiltradas = ucObtenerListaCabanas.BusquedaCapacidad(min, max);
            List<CabanasFiltradasPorCapacidad> cabanasOrdenadas = new List<CabanasFiltradasPorCapacidad>();

            foreach (var item in cabanasFiltradas)
            {
                var mantenimientosAgrupados = item.Mantenimientos.GroupBy(x => x.Trabajador);
                foreach (var mantenimientos in mantenimientosAgrupados)
                {
                    var a = new CabanasFiltradasPorCapacidad()
                    {
                        nombreTrabajador = mantenimientos.Key,
                        total = mantenimientos.Sum(m => m.Costo),
                        nombreCabana = item.Nombre
                    };

                    cabanasOrdenadas.Add(a);
                }
            }
            return cabanasOrdenadas;
        }
        
    }
}
