using System.ComponentModel.DataAnnotations;

namespace Web_API.DTOs
{
    public class UsuarioDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
