﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_LogicaNegocio.Entidades
{
    public class TipoCabana
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoCabana { get; set; } // Clave primaria numérica

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } // 'Nombre' ahora es una propiedad regular

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Descripcion { get; set; }

        public decimal CostoPorHuesped { get; set; }
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
            return Descripcion.Length >= 10 && Descripcion.Length <= 500;
        }
    }
}
