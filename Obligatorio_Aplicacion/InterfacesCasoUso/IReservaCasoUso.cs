using Obligatorio_Aplicacion.Comun;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Aplicacion.InterfacesCasoUso
{
    public interface IReservaCasoUso
    {
        void RealizarReserva(Reserva datos);
        // Aquí puedes añadir otros métodos relacionados con la lógica de negocio de reservas.
    }
}
