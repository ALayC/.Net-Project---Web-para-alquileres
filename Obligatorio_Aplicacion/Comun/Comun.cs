using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Aplicacion.Comun
{
    public interface IRepositorio<T>
    {
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
        T? ObtenerPorId(int id);
        List<T> ObtenerTodos();

    }
}
