using Microsoft.EntityFrameworkCore;
using Obligatorio_Aplicacion.Servicios;
using Obligatorio_Aplicacion;
using Obligatorio_AccesoDatos;

using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_AccesoDatos.EntityFrameWork
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public ObligatorioDBContext _dbContext;
        public UsuarioRepositorio(ObligatorioDBContext dbContex)
        {
            this._dbContext = dbContex;
        }
        public void Actualizar(Usuario entidad)
        {
            if (entidad is null) throw new Exception("Datos de Usuario no pueden ser vacíos");
            if (entidad.id <= 0) throw new Exception("El Numero de id no es válido");
            var entidadBD = ObtenerPorId(entidad.id);
            if (entidadBD is null) throw new Exception("Cabaña no encontrada");
            //if (entidad.Validar())
            //{
            //    entidadBD.id = entidad.id;
            //    entidadBD.Email = entidad.Email;
            //    entidadBD.Password = entidad.Password;
            //}
            //else
            //{
            //    throw new Exception("No se pudo validar los datos de la cabaña");
            //}
        }

        public void Agregar(Usuario entidad)
        {
            try
            {
                if (entidad is null) throw new Exception("Datos de Usuario no pueden ser vacíos");
                _dbContext.Usuarios.Add(entidad);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                // hacer algo con el mensaje de la excepcion_
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                if (id <= 0) throw new Exception("El Usuario no es valido");
                var entidadBD = ObtenerPorId(id);
                if (entidadBD is null) throw new Exception("No se pudo obtener el Usuario");
                _dbContext.Usuarios.Remove(entidadBD);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // hacer algo con el mensaje de la excepcion_
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _dbContext.Usuarios.FirstOrDefault(x => x.id == id);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _dbContext.Usuarios.ToList();
        }

        //public Usuario ObtenerPorEmailYPass(string email, string password)
        //{
        //    return _dbContext.Usuarios.SingleOrDefault(u => u.Email == email && u.Password == password);
        //}

        public object Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public object Logout(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorCorreo(string email)
        {
            return _dbContext.Usuarios.FirstOrDefault(u => u.Email == email);
        }
    }
}
