using Obligatorio_Aplicacion.Comun;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio_Aplicacion.Servicios;


namespace Obligatorio_Aplicacion
{


    public class AutenticacionService
    {
        private readonly IUsuarioRepositorio _usuarioRepo;

        public AutenticacionService(IUsuarioRepositorio usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        //public SesionUsuario Login(string email, string password)
        //{
        //    var usuario = _usuarioRepo.ObtenerTodos().FirstOrDefault(u => u.Email == email && u.Password == password);

        //    if (usuario == null)
        //    {
        //        throw new Exception("Credenciales inválidas");
        //    }

        //    var sesionUsuario = new SesionUsuario
        //    {
        //        Email = usuario.Email,
        //    };

        //    return sesionUsuario;
        //}
        public void Logout(SesionUsuario sesionUsuario) {
            sesionUsuario = null;
        }
    }

    public class SesionUsuario
    {
        // public int UsuarioId { get; set; }
        public string? Email { get; set; }
        //public string Nombre { get; set; }

    }

}
