using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionNOmbresRecargaDeDatosReales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insertar datos en TipoCabanas
            migrationBuilder.InsertData(
                table: "TipoCabanas",
                columns: new[] { "IdTipoCabana", "Nombre", "Descripcion", "CostoPorHuesped" },
                values: new object[,]
                {
            { 1, "Campo", "Cabana ubicada en el campo", 10m },
            { 2, "Playa", "Cabana ubicada en la playa", 200m },
            { 3, "Apartamento", "apartamento en balneario", 300m },
            { 4, "Hotel", "Habitacion de hotel en balneario", 400m }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
