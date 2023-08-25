using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class PrecargaCabana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                                  table: "Cabanas",
                                  columns: new[] { "Nombre", "Descripcion", "JacuzziPrivado", "HabilitadaReservas", "NumeroHabitacion", "CapacidadMaxima", "Imagen", "TipoCabanaNombre" },
                                  values: new object[,]
                                  {
                                            { "CabanaUno", "Esta es la cabana 1", true, true, 1, 4, "RutaImagenCabana1", "TipoCabanaUno" },
                                            { "CabanaDos", "Esta es la cabana 2", true, true, 2, 2, "RutaImagenCabana2", "TipoCabanaDos" },
                                            { "CabanaTres", "Esta es la cabana 3", true, true, 3, 3, "RutaImagenCabana3", "TipoCabanaTres" },
                                            { "CabanaCuatro", "Esta es la cabana 4", true, true, 4, 5, "RutaImagenCabana4", "TipoCabanaCuatro" },
                                            { "CabanaCinco", "Esta es la cabana 5", true, true, 5, 2, "RutaImagenCabana5", "TipoCabanaCinco" },
                                            { "CabanaSeis", "Esta es la cabana 6", false, true, 6, 3, "RutaImagenCabana6", "TipoCabanaSeis" },
                                            { "CabanaSiete", "Esta es la cabana 7", false, false, 7, 5, "RutaImagenCabana7", "TipoCabanaSiete" },
                                            { "CabanaOcho", "Esta es la cabana 8", false, false, 8, 4, "RutaImagenCabana8", "TipoCabanaOcho" },
                                            { "CabanaNueve", "Esta es la cabana 9", false, false, 9, 2, "RutaImagenCabana9", "TipoCabanaNueve" },
                                            { "CabanaDiez", "Esta es la cabana 10", false, false, 10, 4, "RutaImagenCabana10", "TipoCabanaDiez" }
                                  });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
