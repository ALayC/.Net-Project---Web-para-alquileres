using Microsoft.EntityFrameworkCore;
using Obligatorio_Aplicacion.Servicios;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_AccesoDatos.EntityFrameWork
{
    public class CabanaRepositorio : ICabanaRepositorio
    {
        public ObligatorioDBContext _dbContext;

        public CabanaRepositorio(ObligatorioDBContext dbContex)
        {
            this._dbContext = dbContex;
        }
        public void Actualizar(Cabana entidad)
        {
            try
            {
                if (entidad is null) throw new Exception("Datos de Cabaña no pueden ser vacíos");
                if (entidad.NumeroHabitacion <= 0) throw new Exception("El Numero de Habitacion no es válido");
                var entidadBD = ObtenerPorId(entidad.NumeroHabitacion);
                if (entidadBD is null) throw new Exception("Cabaña no encontrada");
                if (entidad.Validar())
                {
                    entidadBD.CapacidadMaxima = entidad.CapacidadMaxima;
                    entidadBD.Nombre = entidad.Nombre;
                    entidadBD.Descripcion = entidad.Descripcion;
                    entidadBD.JacuzziPrivado = entidad.JacuzziPrivado;
                    entidadBD.HabilitadaReservas = entidad.HabilitadaReservas;
                    entidadBD.Imagen = entidad.Imagen;
                }
                else
                {
                    throw new Exception("No se pudo validar los datos de la cabaña");
                }
            }
            catch (Exception ex)
            {
                // hacer algo con el mensaje de la excepcion_
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Agregar(Cabana entidad)
        {
            try
            {
                if (entidad is null) throw new Exception("Datos de la Cabaña no pueden ser vacíos");
                if (!_dbContext.Cabanas.Any(c => c.Nombre == entidad.Nombre))
                {
                    _dbContext.Cabanas.Add(entidad);
                    _dbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Ese nombre ya existe");

                }


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
                _dbContext.Cabanas.Remove(entidadBD);
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

        public Cabana? ObtenerPorId(int numeroHabitacion)
        {
            return _dbContext.Cabanas.FirstOrDefault(x => x.NumeroHabitacion == numeroHabitacion);
        }

        public List<Cabana> ObtenerTodos()
        {
            return _dbContext.Cabanas.ToList();
        }
        public List<Cabana> ObtenerPorNombre(string nombre)
        {

            var tiposCabanas = _dbContext.Cabanas
        .Where(tc => tc.Nombre.Contains(nombre))
        .ToList();

            return tiposCabanas;
        }
        public List<Cabana> ObtenerPorTipo(string tipo)
        {
            var tiposCabanas = _dbContext.Cabanas
            .Where(tc => tc.TipoCabana.Nombre.Contains(tipo))
            .ToList();


            return tiposCabanas;
        }
        public List<Cabana> ObtenerPorCantidadMaxima(int max)
        {

            var maximo = _dbContext.Cabanas
             .Where(c => c.CapacidadMaxima >= max)
             .ToList();


            return maximo;
        }
        public List<Cabana> BuscarHabilitadas()
        {

            var habilitadas = _dbContext.Cabanas
                .Where(c => c.HabilitadaReservas)
                .ToList();

            return habilitadas;
        }
        public List<Cabana> BuscarTodas()
        {
            var todas = _dbContext.Cabanas.ToList();
            return todas;
        }

        public List<Cabana> BuscarPorTipoyMonto(string tipo, int monto)
        {

            return _dbContext.Cabanas
            .Include(c => c.TipoCabana)
            .Where(c => c.TipoCabana.Nombre == tipo &&
                        c.TipoCabana.CostoPorHuesped <= monto &&
                        c.JacuzziPrivado == true &&
                        c.HabilitadaReservas == true)
            .ToList();
        }
        public List<Cabana> BusquedaCapacidad(int min, int max)
        {

            var todas = _dbContext.Cabanas.Include(c=> c.Mantenimientos).ToList();
            List<Cabana> cabanasFiltradas = new List<Cabana>();
            List<CabanasFiltradasPorCapacidad> Cabanasordenadas = new List<CabanasFiltradasPorCapacidad>();

            foreach (Cabana cabana in todas)
            {
                if (cabana.CapacidadMaxima >= min && cabana.CapacidadMaxima <= max)
                {
                    cabanasFiltradas.Add(cabana);
                }
            }

            foreach (var item in cabanasFiltradas)
            {
                var mantenimientosAgrupados = item.Mantenimientos.GroupBy(x => x.Trabajador);
                foreach (var mantenimientos in mantenimientosAgrupados)
                {
                    var a = new CabanasFiltradasPorCapacidad()
                    {
                        nombreTrabajador = mantenimientos.Key,
                        total = mantenimientos.Sum(m => m.Costo),
                        nombreCabana = item.Nombre
                    };

                    Cabanasordenadas.Add(a);
                }
            }

            return todas;

        }
    }
}
