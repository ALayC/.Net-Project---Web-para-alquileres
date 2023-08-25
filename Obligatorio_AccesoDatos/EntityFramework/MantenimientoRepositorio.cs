using Microsoft.VisualBasic;
using Obligatorio_Aplicacion.Servicios;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio_AccesoDatos.EntityFrameWork
{
    public class MantenimientoRepositorio : IMantenimientoRepositorio
    {
        public ObligatorioDBContext _dbContext;

        public MantenimientoRepositorio(ObligatorioDBContext dbContex)
        {
            this._dbContext = dbContex;
        }
        public void Actualizar(Mantenimiento entidad)
        {
            if (entidad is null) throw new Exception("Datos de Mantenimiento no pueden ser vacíos");
            if (entidad.NumeroHabitacion <= 0) throw new Exception("El Numero de Habitacion no es válido");
            var entidadBD = ObtenerPorId(entidad.NumeroHabitacion);
            if (entidadBD is null) throw new Exception("Mantenimiento no encontrada");
            if (entidad.Validar())
            {
                entidadBD.Fecha = entidad.Fecha;
                entidadBD.Descripcion = entidad.Descripcion;
                entidadBD.Costo = entidad.Costo;
                entidadBD.Trabajador = entidad.Trabajador;
                entidadBD.NumeroHabitacion = entidad.NumeroHabitacion;

            }
            else
            {
                throw new Exception("No se pudo validar los datos del Mantenimiento");
            }
        }

        public void Agregar(Mantenimiento entidad)
        {
            try
            {
                if (entidad is null) throw new Exception("Datos de Mantenimiento no pueden ser vacíos");
                _dbContext.Mantenimientos.Add(entidad);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                // hacer algo con el mensaje de la excepcion_
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Eliminar(int numeroHabitacion)
        {
            try
            {
                if (numeroHabitacion <= 0) throw new Exception("El Numero de Habitacion no es válido");
                var entidadBD = ObtenerPorId(numeroHabitacion);
                if (entidadBD is null) throw new Exception("No se pudo obtener la cabaña");
                _dbContext.Mantenimientos.Remove(entidadBD);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // hacer algo con el mensaje de la excepcion_
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public object Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Mantenimiento? ObtenerPorId(int numeroHabitacion)
        {
            return _dbContext.Mantenimientos.FirstOrDefault(x => x.NumeroHabitacion == numeroHabitacion);
        }

        public List<Mantenimiento> ObtenerTodos()
        {
            return _dbContext.Mantenimientos.ToList();
        }


        public List<Mantenimiento> MantenimientoEntreDosFechas(int id, DateTime fechaInicio, DateTime fechaFin)
        {
            var mantenimientoEntreFechas = _dbContext.Mantenimientos
                .Where(m => m.NumeroHabitacion == id && m.Fecha >= fechaInicio && m.Fecha <= fechaFin)
                .OrderByDescending(m => m.Costo)
                .ToList();

            return mantenimientoEntreFechas;
        }

        public List<Mantenimiento> AgregarNuevoMantenimiento(int id, DateTime fecha, int costo, string descripcion, string trabajador)
        {

            Mantenimiento entidad = new Mantenimiento();
            entidad.NumeroHabitacion = id;
            entidad.Fecha = fecha.Date;
            entidad.Costo = costo;
            entidad.Descripcion = descripcion;
            entidad.Trabajador = trabajador;

            bool chequeofecha = _dbContext.Mantenimientos
                                .Count(m => m.NumeroHabitacion == id && m.Fecha == fecha.Date) < 3;

            if (chequeofecha)
            {
                _dbContext.Mantenimientos.Add(entidad);
                _dbContext.SaveChanges();

            }


            var mantenimientoEntreFechas = _dbContext.Mantenimientos
                .Where(m => m.NumeroHabitacion == id && m.Fecha.Date == fecha.Date)
                .ToList();

            return mantenimientoEntreFechas;

        }

    }
}