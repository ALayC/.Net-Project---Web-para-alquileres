
using Obligatorio_Aplicacion.Servicios;
using Obligatorio_LogicaNegocio.Entidades;


namespace Obligatorio_AccesoDatos.EntityFrameWork
{
    public class TipoCabanaRepositorio : ITipoCabanaRepositorio
    {
        public ObligatorioDBContext _dbContext;
        public TipoCabanaRepositorio(ObligatorioDBContext dbContex)
        {
            this._dbContext = dbContex;
        }

        public IEnumerable<TipoCabana> AgregarTipo(TipoCabana entidad)
        {
            try
            {
                if (entidad is null) throw new Exception("Datos de Mantenimiento no pueden ser vacíos");
                _dbContext.TipoCabanas.Add(entidad);
                _dbContext.SaveChanges();
                return _dbContext.TipoCabanas;  // return all TipoCabana entities after the new one has been added

            }
            catch (Exception ex)
            {
                // hacer algo con el mensaje de la excepcion_
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public void Actualizar(TipoCabana entidad)
        {
            if (entidad is null) throw new Exception("Datos de Tipo dCabaña no pueden ser vacíos");
            if (entidad.IdTipoCabana <= 0) throw new Exception("El Numero de Habitacion no es válido");
            var entidadBD = ObtenerPorId(entidad.IdTipoCabana);
            if (entidadBD is null) throw new Exception("Cabaña no encontrada");
            if (entidad.Validar())
            {
                entidadBD.IdTipoCabana = entidad.IdTipoCabana;
                entidadBD.Nombre = entidad.Nombre;
                entidadBD.Descripcion = entidad.Descripcion;
                entidadBD.CostoPorHuesped = entidad.CostoPorHuesped;

            }
            else
            {
                throw new Exception("No se pudo validar los datos de la cabaña");
            }
        }

        public void Agregar(TipoCabana entidad)
        {
            try
            {
                if (entidad is null) throw new Exception("Datos de Mantenimiento no pueden ser vacíos");
                _dbContext.TipoCabanas.Add(entidad);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                // hacer algo con el mensaje de la excepcion_
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Eliminar(int numeroHabitacion,TipoCabana tipoCabana)
        {

            try
            {
                if (numeroHabitacion <= 0) throw new Exception("El Numero de Habitacion no es válido");
                var entidadBD = ObtenerPorId(numeroHabitacion);
                if (entidadBD is null) throw new Exception("No se pudo obtener la cabaña");
                _dbContext.TipoCabanas.Remove(entidadBD);
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

        public TipoCabana? ObtenerPorId(int IdTipoCabana)
        {
            return _dbContext.TipoCabanas.FirstOrDefault(x => x.IdTipoCabana == IdTipoCabana);
        }

        public List<TipoCabana> ObtenerTodos()
        {
            return _dbContext.TipoCabanas.ToList();
        }

        public List<TipoCabana> BuscarTipoCabanaPorNombre(string nombre) {

                var tiposCabanas = _dbContext.TipoCabanas
                    .Where(tc => tc.Nombre.Contains(nombre))
                    .ToList();

                return tiposCabanas;
            

        }
        public TipoCabana EliminacionPorTipo(TipoCabana tipoCabanas) {

            var Tipo = BuscarTipoCabanaPorNombre(tipoCabanas.Nombre);
            if (Tipo is null) throw new Exception("No se pudo obtener la cabaña");
            _dbContext.TipoCabanas.Remove(tipoCabanas);
            _dbContext.SaveChanges();
            return null;
        }

        public void Eliminar(int id)
        {
            try
            {
                var entidadBD = ObtenerPorId(id);
                if (entidadBD is null) throw new Exception("No se pudo obtener la cabaña");
                bool tipoCabanaEnUso = _dbContext.Cabanas.Any(cabana => cabana.TipoCabana.IdTipoCabana == id);
                if (!tipoCabanaEnUso)
                {
                _dbContext.TipoCabanas.Remove(entidadBD);
                _dbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("El tipo está en uso");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error al eliminar el tipo de cabaña");
            }
        }

        public List<TipoCabana> ListarTipoCabana()
        {
            return _dbContext.TipoCabanas.ToList();
        }


    }
}
