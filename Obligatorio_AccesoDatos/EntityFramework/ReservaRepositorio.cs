using Obligatorio_Aplicacion.InterfacesCasoUso;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}