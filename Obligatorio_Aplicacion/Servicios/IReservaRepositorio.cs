using Obligatorio_Aplicacion.Comun;
using Obligatorio_LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Aplicacion.Servicios
{
   
    public interface IReservaRepositorio : IRepositorio<Reserva>
    {
        bool VerificarDisponibilidad(int cabanaId, DateTime fechaInicio, DateTime fechaFin);
        // Otros métodos específicos para el repositorio de reservas.
    }

}
