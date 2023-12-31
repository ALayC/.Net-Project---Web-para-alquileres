﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_MVC.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Obligatorio_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService usuarioService;

        public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            this.usuarioService = usuarioService;
        }


        //private readonly AutenticacionService _autenticacionService;
        //private readonly ITipoCabanaRepositorio _tipoCabanaRepositorio;
        //private readonly ICabanaRepositorio _cabanaRepositorio;
        //public HomeController(ILogger<HomeController> logger, ITipoCabanaRepositorio tipoCabanaRepositorio)
        //{
        //    _logger = logger;
        //    _tipoCabanaRepositorio = tipoCabanaRepositorio;
        //}

        //private readonly ICabanaService cabanaService;


        //[AllowAnonymous]
        public IActionResult Index()
        {
            //string sesionUsuarioEmail = HttpContext.Session.GetString("SesionUsuario");
            //if (string.IsNullOrEmpty(sesionUsuarioEmail))
            //{
            //    //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            //    return RedirectToAction("login", "Usuario");
            //}
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    string sesionUsuarioEmail = HttpContext.Session.GetString("SesionUsuario");
        //    if (string.IsNullOrEmpty(sesionUsuarioEmail))
        //    {
        //        return RedirectToAction("login", "Usuario");
        //    }
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        [AllowAnonymous] // Esta acción es accesible sin iniciar sesión
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        //[AllowAnonymous]
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Login(UsuarioViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Error = "Datos de usario no validos";
        //        return View(model);
        //    }
        //    try
        //    {
        //        var token = await usuarioService.Login(model);
        //        HttpContext.Session.SetString("AccessToken", token);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = ex.Message;
        //        return View(model);
        //    }
        //}


        // ... dentro de la clase UsuarioController ...

        [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UsuarioViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Error = "Los datos de Usuario no son válidos.";
            return View(model);
        }
        try
        {
            var token = await usuarioService.Login(model);
            if (token != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim("Token", token) // Guarda el token en la identidad del usuario
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home"); // Asegúrate de que el controlador y la acción sean correctos
            }

            ViewBag.Error = "La autenticación ha fallado.";
            return View(model);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View(model);
        }
    }



    public IActionResult Registrar()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Datos de usario no validos";
                return View(model);
            }
            try
            {
                await usuarioService.Registrar(model);
                return RedirectToAction("Login");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }

        }

        //[HttpPost]
        //public async Task<IActionResult> Logout(UsuarioViewModel model)
        //{
        //    string sesionUsuarioEmail = HttpContext.Session.GetString("SesionUsuario");
        //    if (sesionUsuarioEmail != null)
        //    {
        //        var sesionUsuario = new SesionUsuario { Email = sesionUsuarioEmail };
        //        HttpContext.Session.Remove("SesionUsuario");
        //        return RedirectToAction("login", "Usuario");
        //        var model = new LogOutViewModel
        //        {
        //            Username = sesionUsuarioEmail,
        //            ReturnUrl = "/home"
        //        };
        //        return View("login", model);
        //    }
        //    return RedirectToAction("login", "Usuario");
        //}


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Limpiamos la sesión del usuario.
            HttpContext.Session.Remove("AccessToken");

            // Cerramos la sesión de autenticación basada en cookies.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirigimos al usuario a la acción de Login.
            return RedirectToAction("Index", "Home");
        }







        //public IActionResult BuscarTipoCabana(string nombre)
        //{
        //    string sesionUsuarioEmail = HttpContext.Session.GetString("SesionUsuario");
        //    if (string.IsNullOrEmpty(sesionUsuarioEmail))
        //    {
        //        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //        return RedirectToAction("login", "Usuario");
        //    }

        //    List<TipoCabana> ListaBusquedaCabana;
        //    ListaBusquedaCabana = _tipoCabanaRepositorio.BuscarTipoCabanaPorNombre(nombre);
        //    return View(ListaBusquedaCabana);
        //    //var eliminar = EditarTipoYCosto(null,,nombre);
        //}

        //[HttpPost]
        //public IActionResult EliminacionPorTipo()
        //{

        //    var selectedItems = Request.Form["selectedItems"].ToString().Split(',');
        //    foreach (var selectedItem in selectedItems)
        //    {
        //        var tipoCabana = _tipoCabanaRepositorio.ObtenerPorId(Convert.ToInt32(selectedItem));
        //        if (tipoCabana != null)
        //        {
        //            try
        //            {
        //                _tipoCabanaRepositorio.Eliminar(tipoCabana.IdTipoCabana);
        //            }
        //            catch (Exception ex)
        //            {
        //                TempData["ErrorEliminarTipoCabana"] = ex.Message;
        //            }
        //        }
        //    }
        //    List<TipoCabana> ListaBusquedaCabana;
        //    ListaBusquedaCabana = _tipoCabanaRepositorio.BuscarTipoCabanaPorNombre("");//falta resolver que va por parametro en BUscarTIpoCAbanaPOrNombre, puede ir en sesion
        //    return View("BuscarTipoCabana", ListaBusquedaCabana);
        //}
        //[HttpPost]
        //public IActionResult EditarTipoYCosto(TipoCabana model, int idTipoCabana)
        //{
        //    var descripcion = Request.Form["descripcion"].ToString();
        //    var costoHuesped = Request.Form["costo"].ToString();

        //    var tipoCabana = _tipoCabanaRepositorio.ObtenerPorId(idTipoCabana);
        //    tipoCabana.CostoPorHuesped = Int32.Parse(costoHuesped);
        //    tipoCabana.Descripcion = descripcion;
        //    if (tipoCabana != null)
        //    {
        //        try
        //        {
        //            _tipoCabanaRepositorio.Actualizar(tipoCabana);
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorEliminarTipoCabana"] = ex.Message;
        //        }
        //    }

        //    List<TipoCabana> ListaBusquedaCabana;
        //    ListaBusquedaCabana = _tipoCabanaRepositorio.BuscarTipoCabanaPorNombre("");
        //    return View("BuscarTipoCabana", ListaBusquedaCabana);


        //}

        //[HttpPost]
        //public IActionResult IngresarCabana()
        //{
        //    return RedirectToAction("AltaCabana", "Cabana");
        //}

        [HttpPost]
        public IActionResult IngresarTipoCabana()
        {
            return View("~/Views/TipoCabana/Alta.cshtml");
        }


        [HttpPost]
        public IActionResult BusquedaCabana()
        {
            return RedirectToAction("BuscarCabanas", "Cabana");
        }


        [HttpPost]
        public IActionResult ListarTipoCabana()

        {
            return RedirectToAction("ListarTipoCabana", "TIpoCAbana");
        }


        //[HttpPost]
        public IActionResult BusquedaMantenimientoEntreFechas()
        {
            return View("~/Views/Mantenimiento/BuscarMantenimientoEntreFechas.cshtml");
        }

        public IActionResult RegistroMantenimiento()
        {
            return View("~/Views/Mantenimiento/RegistroMantenimiento.cshtml");
        }

        public IActionResult BuscarTipoCabana()
        {
            return View("~/Views/TipoCabana/BuscarTipoPorNombre.cshtml");
        }
        public IActionResult BuscarPorTipoyMonto()
        {
            return View("~/Views/Cabana/FormParaBuscarPorTipoyMonto.cshtml");
        }

        public IActionResult BusquedaCapacidad()
        {
            return View("~/Views/Cabana/FormParaBusquedaCapacidad.cshtml");
        }
    }
}