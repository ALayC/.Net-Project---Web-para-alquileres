using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class PrecargaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "Password" }, new[] { "emailUno@email.com", "123456Aa" });
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "Password" }, new[] { "emailDos@email.com", "123456Bb" });
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "Password" }, new[] { "emailTres@email.com", "123456Cc" });
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "Password" }, new[] { "emailCinco@email.com", "123456Ee" });
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "Password" }, new[] { "emailSeis@email.com", "123456Ff" });
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "Password" }, new[] { "emailSiete@email.com", "123456Gg" });
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "Password" }, new[] { "emailOcho@email.com", "123456Hh" });
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "Password" }, new[] { "emailNueve@email.com", "123456Ii" });
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "Password" }, new[] { "emailDiez@email.com", "123456Jj" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
