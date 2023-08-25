using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Obligatorio_MVC.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio_MVC.Controllers
{

    public class CabanaController : Controller
    {

        private readonly ICabanaService cabanaService; 





        public CabanaController(ICabanaService cabanaService)
        {
            this.cabanaService = cabanaService;
        }

        public async Task <IActionResult> Index()
        {
            //string sesionUsuarioEmail = HttpContext.Session.GetString("SesionUsuario");
            //if (string.IsNullOrEmpty(sesionUsuarioEmail))
            //{
            //    return RedirectToAction("login", "Usuario");
            //}
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.ObtenerTodas();
            return View(cabanaModels);
        }
        public IActionResult AltaCabana()
        {
            //string sesionUsuarioEmail = HttpContext.Session.GetString("SesionUsuario");
            //if (string.IsNullOrEmpty(sesionUsuarioEmail))
            //{
            //    return RedirectToAction("login", "Usuario");
            //}
            return View();
        }
        [HttpPost]
        public IActionResult AltaCabana(string nombre, string descripcion, bool jacuzziPrivado, bool habilitadaReservas, int numeroHabitacion, int capacidadMaxima, IFormFile imagen, TipoCabanaModel tipoCabana, List<MantenimientoModel> listaMantenimiento)
        {
            //GuardarImagen(imagen, nombre, out string nombreResultante);
            //var nuevacabana = new Cabana()
            //{
            //    Nombre = nombre,
            //    Descripcion = descripcion,
            //    JacuzziPrivado = jacuzziPrivado,
            //    HabilitadaReservas = habilitadaReservas,
            //    NumeroHabitacion = numeroHabitacion,
            //    CapacidadMaxima = capacidadMaxima,
            //    Imagen = nombreResultante,
            //    TipoCabana = tipoCabana
            //};
            //if (nuevacabana.Validar())
            //{
            //    _cabanaRepositorio.Agregar(nuevacabana);
            //}
            //return RedirectToAction("Index", "Home");
            return View();
        }

        //private bool GuardarImagen(IFormFile imagen, string nombreCabana, out string nombreResultante)
        //{

        //    if (imagen is null || string.IsNullOrEmpty(nombreCabana))
        //    {
        //        nombreResultante = string.Empty;
        //        return false;
        //    }

        //    string rutaFisicaWwwRoot = _environment.WebRootPath;
        //    string nombreImagen = nombreCabana;
        //    string fileExtension = Path.GetExtension(imagen.FileName); if (fileExtension != ".png" && fileExtension != ".jpg") { TempData["Error"] = "La imagen no es valida"; nombreResultante = string.Empty; return false; }
        //    string rutaFisicaFoto = Path.Combine(rutaFisicaWwwRoot, "imagenes", "fotos", nombreImagen + fileExtension);

        //    try
        //    {
        //        using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
        //        {
        //            imagen.CopyTo(f);
        //        }
        //        nombreResultante = nombreImagen + fileExtension;
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        nombreResultante = string.Empty;
        //        return false;
        //    }
        //    return true;
        //}


        [Route("Cabana/BuscarCabanas")]
        public async Task<IActionResult> BuscarCabanas()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarCabanas(token);
            return View(cabanaModels);
        }

        [Route("Cabana/BuscarCabanaPorNombre/{nombre}")]
        public async Task<IActionResult> BuscarCabanaPorNombre(string nombre)
        {

            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarPorNombre(nombre, token);
            return View(cabanaModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> BuscarCabanaPorNombrePost(string nombre)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarPorNombre(nombre, token);
            return View(cabanaModels);
        }


        [Route("Cabana/BuscarCabanaPorTipo/{tipo}")]
        public async Task<IActionResult> BuscarCabanaPorTipo(string tipo)
        {

            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarCabanaPorTipo(tipo, token);
            return View(cabanaModels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuscarCabanaPorTipoPost(string tipo)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarCabanaPorTipo(tipo, token);
            return View(cabanaModels);
        }


        [Route("Cabana/BuscarCabanaPorCantidadMaximaDePersonas/{maxpersonas}")]
        public async Task<IActionResult> BuscarCabanaPorCantidadMaximaDePersonas(int maxpersonas)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarCabanaPorCantidadMaximaDePersonas(maxpersonas, token);
            return View(cabanaModels);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuscarCabanaPorCantidadMaximaDePersonasPost(int maxpersonas)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarCabanaPorCantidadMaximaDePersonas(maxpersonas, token);
            return View(cabanaModels);
        }


        [Route("Cabana/BuscarCabanasHabilitadas")]
        public async Task<IActionResult>  BuscarCabanasHabilitadas()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarCabanasHabilitadas(token);
            return View(cabanaModels);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuscarCabanasHabilitadasPost()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarCabanasHabilitadas(token);
            return View(cabanaModels);
        }




        [Route("Cabana/BuscarTodas")]
        public async Task<ActionResult> BuscarTodas()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarTodas(token);
           return View(cabanaModels);


        }

        [HttpPost]
        public async Task<IActionResult> BuscarPorTipoyMonto(ParaBuscarPorTipoyMontoModel model)
        {
            var token = HttpContext.Session.GetString("AccessToken");

            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BuscarPorTipoyMonto(model, token);
            return View(cabanaModels);
        }
        [HttpPost]
        public async Task<IActionResult> BusquedaCapacidad(int min, int max)
        {
            var token = HttpContext.Session.GetString("AccessToken");

            IEnumerable<CabanaModel> cabanaModels = await cabanaService.BusquedaCapacidad(min, max , token);
            return View(cabanaModels);
        }
        
    }
}
