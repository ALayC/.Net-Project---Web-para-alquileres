using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Aplicacion.InterfacesCasoUso;
using Obligatorio_Aplicacion.Servicios;
using Obligatorio_LogicaNegocio.Entidades;
using Web_API.DTOs;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private static Usuario usuarioActual;
        private readonly IConfiguration configuration;
        private readonly IUsuarioRepositorio usarioRepositorio;
        private readonly IBuscarUsuarioLogin ucUsuarioLogin;
        public SeguridadController(IConfiguration configuration, IBuscarUsuarioLogin ucUsuarioLogin, IUsuarioRepositorio usarioRepositorio) {
            this.configuration = configuration;
            this.ucUsuarioLogin = ucUsuarioLogin;
            this.usarioRepositorio = usarioRepositorio;
        }





 
        [HttpPost("registrar")]
        public IActionResult Registrar(UsuarioDTO usuario) {
            if (!ModelState.IsValid)
            {
                return BadRequest("La informacion del usuario no es valida");
            }

            try
            {
                Seguridad.CrearPasswordHash(usuario.Password, out byte[] passwordHash, out byte[] passwordSalt);
                usuarioActual = new Usuario()
                {
                    Email = usuario.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
                usarioRepositorio.Agregar(usuarioActual);
                return Ok("Usuario registrado correctamente");//es lo mismo que status code 200
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message); 
            }
        
        }

        [HttpPost("login")]
        public IActionResult Login(UsuarioDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("La información del usuario no es válida");
            }

            try
            {
                // Usar el caso de uso para buscar al usuario por correo
                Usuario usuarioDb = ucUsuarioLogin.Ejecutar(usuario.Email);

                if (usuarioDb == null)
                {
                    return BadRequest("El Usuario proporcionado no existe");
                }

                if (!Seguridad.VerificarPasswordHash(usuario.Password, usuarioDb.PasswordHash, usuarioDb.PasswordSalt))
                {
                    return BadRequest("Credenciales incorrectas");
                }

                var token = Seguridad.CrearToken(usuarioDb, configuration);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
