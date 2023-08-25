using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_LogicaNegocio.Entidades
{
    public class Usuario
    {
        [Key]
        public string Email { get; set; }
        //public string Password { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        //public bool Validar()
        //{
        //    return ValidarMail() && ValidarPassword();
        //}
        //private bool ValidarMail()
        //{
        //    try
        //    {
        //        var mailAddress = new System.Net.Mail.MailAddress(Email);
        //        return true;
        //    }
        //    catch (FormatException)
        //    {
        //        return false;
        //    }
        //}

        //private bool ValidarPassword()
        //{

        //    if (Password.Length < 6)
        //    {
        //        return false;
        //    }

        //    bool hasUpperCase = false;
        //    bool hasLowerCase = false;
        //    bool hasDigit = false;

        //    foreach (char c in Password)
        //    {
        //        if (char.IsUpper(c))
        //        {
        //            hasUpperCase = true;
        //        }
        //        else if (char.IsLower(c))
        //        {
        //            hasLowerCase = true;
        //        }
        //        else if (char.IsDigit(c))
        //        {
        //            hasDigit = true;
        //        }
        //    }

        //    if (!hasUpperCase || !hasLowerCase || !hasDigit)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        


    }
}
