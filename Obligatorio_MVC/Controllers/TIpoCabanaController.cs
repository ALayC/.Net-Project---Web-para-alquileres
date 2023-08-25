using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Obligatorio_MVC.Models;
using Obligatorio_MVC.Servicios;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio_MVC.Controllers
{
    public class TIpoCabanaController : Controller
    {

        private readonly ITipoCabanaService tipoCabanaService;

        public TIpoCabanaController(ITipoCabanaService tipoCabanaService)
        {
            this.tipoCabanaService = tipoCabanaService;
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
        public IActionResult Privacy()
        {
            //string sesionUsuarioEmail = HttpContext.Session.GetString("SesionUsuario");
            //if (string.IsNullOrEmpty(sesionUsuarioEmail))
            //{
            //    return RedirectToAction("login", "Usuario");
            //}
            return View();
        }

        [HttpPost]
        [Route("TIpoCabana/Alta/{nombre}/{descripcion}/{CostoPorHuesped}")]
        public async Task<IActionResult> Alta(string nombre, string descripcion, int CostoPorHuesped)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<TipoCabanaModel> tipoCabanaModels = await tipoCabanaService.Alta(nombre, descripcion, CostoPorHuesped, token);
            return View();
        }

        [Route("TIpoCabana/ListarTipoCabana")]
        public async Task<IActionResult> ListarTipoCabana()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<TipoCabanaModel> tipoCabanaModels = await tipoCabanaService.ListarTipoCabana(token);
            return View(tipoCabanaModels);
        }

        [Route("TIpoCabana/BuscarTipoPorNombre/{nombre}")]
        public async Task<IActionResult> BuscarTipoPorNombre(string nombre)
        {

            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<TipoCabanaModel> tipoCabanaModels = await tipoCabanaService.BuscarTipoPorNombre(nombre, token);
            return View("ListaDelaBusquedaPorNombre", tipoCabanaModels);
        }
    }

}

