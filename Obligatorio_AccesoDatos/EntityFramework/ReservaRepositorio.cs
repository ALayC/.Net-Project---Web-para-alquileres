using Obligatorio_Aplicacion.Servicios;
using Obligatorio_LogicaNegocio.Entidades;

namespace Obligatorio_AccesoDatos.EntityFramework
{




    public class ReservaRepositorio : IReservaRepositorio
    {
        public ObligatorioDBContext _dbContext;

        public ReservaRepositorio(ObligatorioDBContext dbContex)
        {
            this._dbContext = dbContex;
        }

        public void Actualizar(Reserva entidad)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Reserva entidad)
        {
            _dbContext.Reservas.Add(entidad);

            // Guardar los cambios en la base de datos
            _dbContext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Reserva? ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public bool VerificarDisponibilidad(int cabanaId, DateTime fechaInicio, DateTime fechaFin)
        {
            // Verificar que no existan reservas que se solapen con las fechas proporcionadas.
            // Una reserva se solapa si comienza antes de que termine el rango de fechas proporcionado
            // y termina después de que comienza el rango de fechas proporcionado.

            bool existeReservaSolapada = _dbContext.Reservas.Any(reserva =>
                reserva.CabanaId == cabanaId &&
                reserva.FechaFin > fechaInicio &&
                reserva.FechaInicio < fechaFin);

            // Si existeReservaSolapada es verdadero, entonces la cabaña NO está disponible.
            // Por lo tanto, devolvemos el inverso del valor.
            return !existeReservaSolapada;
        }
    }
}