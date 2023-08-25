using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio_MVC.Models
{
    public class UsuarioViewModel
    {
        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

    }
}
