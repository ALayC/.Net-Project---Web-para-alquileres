using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text;
using Obligatorio_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Obligatorio_MVC.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
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
                // Llamada al servicio para realizar el login y obtener el token
                var token = await usuarioService.Login(model);

                // Almacenar el token en la sesión
                HttpContext.Session.SetString("AccessToken", token);

                // Redirigir a otra vista después del login exitoso
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
