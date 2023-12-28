using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text;
using Obligatorio_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

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
                var token = await usuarioService.Login(model);

                if (token != null)
                {
                    //almacena el token en la sesion
                    HttpContext.Session.SetString("AccessToken", token);
                    // Crear las claims (información del usuario)
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim("Token", token) // Almacena el token como una claim
            };

                    // Crear la identidad del usuario
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Crear el principal de usuario
                    var principal = new ClaimsPrincipal(claimsIdentity);

                    // Iniciar sesión con la autenticación basada en cookies
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // Redirigir a la página de inicio
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Credenciales inválidas.";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }




        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
