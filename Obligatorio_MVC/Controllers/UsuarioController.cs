using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text;
using Obligatorio_MVC.Models;

namespace Obligatorio_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UsuarioViewModel model)
        {
            if (!ModelState.IsValid) { ViewBag.Error = "Los datos de Usuario no son válidos."; return View(model); }
            try
            {
                var token = await usuarioService.Login(model);
                HttpContext.Session.SetString("AccessToken", token);
                return RedirectToAction("Index", "Autor");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
