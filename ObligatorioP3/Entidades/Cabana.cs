using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio_LogicaNegocio.Entidades
{
    public class Cabana
    {
        [Key]
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*[a-zA-Z]$",
         ErrorMessage = "El nombre debe incluir solo caracteres alfabéticos y espacios embebidos (no al principio ni al final)")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Descripcion { get; set; }
        public bool JacuzziPrivado { get; set; }
        public bool HabilitadaReservas { get; set; }
        public int NumeroHabitacion { get; set; }

        public int CapacidadMaxima { get; set; }

        public string Imagen { get; set; }
        public TipoCabana TipoCabana { get; set; }
        public List<Mantenimiento> Mantenimientos { get; set; }

        public bool Validar()
        {
            return ValidarNombre() && ValidarDescripcion();
        }
        private bool ValidarNombre()
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                for (int i = 0; i < Nombre.Length; i++)
                {
                    if (!char.IsLetter(Nombre[i]))
                        return false;
                }
                return true;
            }
            return false;

        }
        private bool ValidarDescripcion()
        {
            return Descripcion.Length >= 10 && Descripcion.Length < 500;
        }
    }
}
