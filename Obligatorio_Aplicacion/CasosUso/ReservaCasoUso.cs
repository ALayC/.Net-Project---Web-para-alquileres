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
    // Obligatorio_Aplicacion.CasosUso
    public class ReservaCasoUso
    {
        private readonly IReservaRepositorio _reservaRepositorio;
        // Aquí puedes inyectar otros servicios necesarios.

        public ReservaCasoUso(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
        }

        public void RealizarReserva(Reserva datos)
        {
            if (datos == null)
            {
                throw new ArgumentNullException(nameof(datos), "Los datos de la reserva no pueden ser nulos.");
            }

            // Verificar la disponibilidad de la cabaña para las fechas solicitadas.
            if (!_reservaRepositorio.VerificarDisponibilidad(datos.CabanaId, datos.FechaInicio, datos.FechaFin))
            {
                throw new InvalidOperationException("La cabaña no está disponible para las fechas seleccionadas.");
            }

            // Aquí puedes agregar lógica adicional para calcular el costo total, aplicar descuentos, etc.

            // Agregar la reserva a la base de datos.
            _reservaRepositorio.Agregar(datos);
        }
    }

}


