using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio_LogicaNegocio.Entidades
{
    public class Mantenimiento
    {

        public DateTime Fecha { get; set; }
        [Key]
        public string Descripcion { get; set; }

        public decimal Costo { get; set; }

        public string Trabajador { get; set; }

        public int NumeroHabitacion { get; set; }

        public bool Validar()
        {
            return ValidarNombre() && ValidarDescripcion();
        }

        public bool ValidarMantenimiento() {


            return  ValidarDescripcion();

        }
        private bool ValidarNombre()
        {
            if (!string.IsNullOrEmpty(Descripcion))
            {
                for (int i = 0; i < Descripcion.Length; i++)
                {
                    if (!char.IsLetter(Descripcion[i]))
                        return false;
                }
                return true;
            }
            return false;
        }
        private bool ValidarDescripcion()
        {
            return Descripcion.Length >= 10 && Descripcion.Length <= 200;
        }

    }
}
