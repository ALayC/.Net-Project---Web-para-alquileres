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
    public class ReservaCasoUso : IReserva
    {
        IReserva _reservaRepositorio;
        // Inyectar otros servicios si es necesario, por ejemplo, para verificar la disponibilidad.

        public ReservaCasoUso(IReserva reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
        }

        public void Actualizar(Reserva entidad)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Reserva entidad)
        {
            throw new NotImplementedException();
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

        public void RealizarReserva( datos)
        {
            // Validar los datos de la reserva.
            // Verificar la disponibilidad de la cabaña.
            // Crear y configurar la entidad Reserva.
            // Utilizar _reservaRepositorio para agregar la reserva a la base de datos.
        }
    }
}


}