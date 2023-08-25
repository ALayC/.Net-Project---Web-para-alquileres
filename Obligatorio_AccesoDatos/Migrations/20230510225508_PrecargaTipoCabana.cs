using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class PrecargaTipoCabana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaUno", "Este es el tipo de cabana 1", "10" });
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaDos", "Este es el tipo de cabana 2", "200" });
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaTres", "Este es el tipo de cabana 3", "300" });
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaCuatro", "Este es el tipo de cabana 4", "400" });
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaCinco", "Este es el tipo de cabana 5", "500" });
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaSeis", "Este es el tipo de cabana 6", "600" });
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaSiete", "Este es el tipo de cabana 7", "700" });
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaOcho", "Este es el tipo de cabana 8", "700" });
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaNueve", "Este es el tipo de cabana 9", "100" });
            migrationBuilder.InsertData("TipoCabanas", new[] { "Nombre", "Descripcion", "CostoPorHuesped" }, new[] { "TipoCabanaDiez", "Este es el tipo de cabana 10", "800" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
