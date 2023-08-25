using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CargaDeNombreDeFotosCorrecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaUno_001.jpg' WHERE Nombre='CabanaUno'");
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaDos_001.jpg' WHERE Nombre='CabanaDos'");
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaTres_001.jpg' WHERE Nombre='CabanaTres'");
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaCuatro_001.jpg' WHERE Nombre='CabanaCuatro'");
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaCinco_001.jpg' WHERE Nombre='CabanaCinco'");
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaSeis_001.jpg' WHERE Nombre='CabanaSeis'");
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaSiete_001.jpg' WHERE Nombre='CabanaSiete'");
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaOcho_001.jpg' WHERE Nombre='CabanaOcho'");
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaNueve_001.jpg' WHERE Nombre='CabanaNueve'");
            migrationBuilder.Sql("UPDATE Cabanas SET Imagen='CabanaDiez_001.jpg' WHERE Nombre='CabanaDiez'");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
