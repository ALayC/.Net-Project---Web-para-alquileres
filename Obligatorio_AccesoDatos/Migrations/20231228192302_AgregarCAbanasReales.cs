using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCAbanasReales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insertar datos en Cabanas
            migrationBuilder.InsertData(
                table: "Cabanas",
                columns: new[] { "Nombre", "Descripcion", "JacuzziPrivado", "HabilitadaReservas", "NumeroHabitacion", "CapacidadMaxima", "Imagen", "TipoCabanaId" },
                values: new object[,]
                {
            { "Sabrina", "Comoda cabana de campo", true, true, 1, 4, "Sabrina.jpg", 1 },
            { "Uma", "Comoda cabana de playa", true, true, 2, 2, "Uma.jpg", 2 },
            { "Mermelada", "Apartamento en piriapolis", true, true, 3, 3, "Mermelada.jpg", 3 },
            { "Sugus", "Esta es la cabana 4", true, true, 4, 5, "Sugus.jpg", 4 }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
