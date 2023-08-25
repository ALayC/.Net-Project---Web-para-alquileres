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
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, usuarioActual.Email),
                new Claim(ClaimTypes.Role,"Operador")

            };
            var claveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:SecretTokenKey").Value!));

            var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims ,expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
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
