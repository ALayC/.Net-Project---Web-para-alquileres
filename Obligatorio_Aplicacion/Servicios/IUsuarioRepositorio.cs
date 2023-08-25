using Obligatorio_Aplicacion.Comun;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Obligatorio_Aplicacion.Servicios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        object Login(string email, string password);
        //object Logout(string email);
        Usuario BuscarPorCorreo(string email);

        void Agregar(Usuario usuario);
    }
}
