using Obligatorio_Aplicacion.InterfacesCasoUso;
using Obligatorio_Aplicacion.Servicios;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Aplicacion.CasosUso
{
    public class BuscarUsuarioLogin : IBuscarUsuarioLogin
    {
        IUsuarioRepositorio usuarioRepositorio;

        public BuscarUsuarioLogin(IUsuarioRepositorio usuarioRepositorio)
        {

            this.usuarioRepositorio = usuarioRepositorio;
        }



        public Usuario Ejecutar(string email)
        {
            return this.usuarioRepositorio.BuscarPorCorreo(email);
        }
    }

}
