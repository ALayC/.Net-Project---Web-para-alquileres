using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Obligatorio_MVC.Models;
using Obligatorio_MVC.Servicios;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;

namespace Obligatorio_MVC.Controllers
{
    [Authorize]
    public class MantenimientoController : Controller
    {
        private readonly IMantenimientoService mantenimientoService;

        public MantenimientoController(IMantenimientoService mantenimientoService)
        {
            this.mantenimientoService = mantenimientoService;
        }

        public IActionResult Index()
        {
            //string sesionUsuarioEmail = HttpContext.Session.GetString("SesionUsuario");
            //if (string.IsNullOrEmpty(sesionUsuarioEmail))
            //{
            //    return RedirectToAction("login", "Usuario");
            //}

            return View();
        }



        [HttpPost]
        [Route("Mantenimiento/BuscarMantenimientoEntreFechas")]
        public async Task<IActionResult> BuscarMantenimientoEntreFechas(BuscarMantenimientoRequest request)
        {
            var token = HttpContext.Session.GetString("AccessToken");

            IEnumerable<MantenimientoModel> mantenimientoModels = await mantenimientoService.BuscarMantenimientoEntreFechas(request.Id, request.FechaInicio, request.FechaFin, token);
            return View("ListaBuscarMantenimientoEntreFechas", mantenimientoModels);
        }


        [HttpPost]
        [Route("Mantenimiento/RegistroMantenimiento")]
        public async Task<IActionResult> RegistroMantenimiento(RegistroMantenimientoModel request)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<MantenimientoModel> mantenimientoModels = await mantenimientoService.RegistroMantenimiento(request.Id, request.Fecha, request.costo, request.descripcion, request.trabajador, token);
            return View("ListarRegistroMantenimiento", mantenimientoModels);
        }

    }
}
