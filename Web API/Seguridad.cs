using Microsoft.IdentityModel.Tokens;
using Obligatorio_LogicaNegocio.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Web_API
{
    public static class Seguridad
    {
        public static void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        internal static string CrearToken(Usuario usuarioActual, IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim>
    {
        new Claim(ClaimTypes.Email, usuarioActual.Email),
        new Claim(ClaimTypes.NameIdentifier, usuarioActual.id.ToString()), // Agregar el ID del usuario como un claim
        new Claim(ClaimTypes.Role, "Operador") // Asegúrate de que este rol se asigna correctamente según la lógica de tu aplicación
    };

            var claveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:SecretTokenKey").Value!));
            var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1), // Usar UTC para evitar problemas de zona horaria
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        internal static bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var passwordHashCalculado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return passwordHashCalculado.SequenceEqual(passwordHash);
            }
        }
    }
}
