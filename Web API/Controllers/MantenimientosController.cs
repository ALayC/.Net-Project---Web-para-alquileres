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
    public class MantenimientosController : ControllerBase
    {
        private readonly IMantenimientoRepositorio ucMantenimientoEntreDosFechas;

        private readonly IMantenimientoObtenerTodos ucMantenimientoObtenerTodos;
        private readonly IBuscarMantenimientoEntreFechas ucBuscarMantenimientoEntreFechas;
        private readonly IRegistroMantenimiento ucRegistroMantenimiento;

        public MantenimientosController(IMantenimientoRepositorio ucMantenimientoEntreDosFechas, IMantenimientoObtenerTodos ucMantenimientoObtenerTodos, IBuscarMantenimientoEntreFechas ucBuscarMantenimientoEntreFechas, IRegistroMantenimiento ucRegistroMantenimiento)
        {
            this.ucMantenimientoEntreDosFechas = ucMantenimientoEntreDosFechas;
            this.ucMantenimientoObtenerTodos = ucMantenimientoObtenerTodos;
            this.ucBuscarMantenimientoEntreFechas = ucBuscarMantenimientoEntreFechas;
            this.ucRegistroMantenimiento = ucRegistroMantenimiento;     
        }


        [HttpGet]
        public IEnumerable<Mantenimiento> ObtenerTodos()
        {

            return ucMantenimientoObtenerTodos.Ejecutar();
        }

        [HttpGet]
        [Route("BuscarMantenimientoEntreFechas/{id}/{fechaInicio}/{fechaFin}")]
        public IEnumerable<Mantenimiento> BuscarMantenimientoEntreFechas(int id, DateTime fechaInicio, DateTime fechaFin)
        {

            return ucBuscarMantenimientoEntreFechas.Ejecutar(id,  fechaInicio,  fechaFin);
        }



        [HttpPost]
        [Route("RegistroMantenimiento/{id}/{fecha}/{costo}/{descripcion}/{trabajador}")]
        public IEnumerable<Mantenimiento> RegistroMantenimiento(int id, DateTime fecha, int costo, string descripcion, string trabajador)
        {

            return ucRegistroMantenimiento.Ejecutar(id, fecha, costo, descripcion, trabajador);

        }
    }
}
