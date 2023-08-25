using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio_MVC.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
