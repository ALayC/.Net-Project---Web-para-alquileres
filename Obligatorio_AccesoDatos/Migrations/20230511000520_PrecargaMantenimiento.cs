using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class PrecargaMantenimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 1", "07/05/2023", "800", "Juan Perez", "1", "CabanaUno" });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 2", "08/05/2023", "800", "Nicolas Perez", "2", "CabanaDos" });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 3", "08/05/2023", "1800", "Mauro Perez", "3", "CabanaTres" });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 4", "09/05/2023", "8200", "Juan Perez", "4", "CabanaCuatro" });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 5", "01/05/2023", "8600", "Nicolas Perez", "5", "CabanaCinco" });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 6", "02/05/2023", "8900", "Juan Perez", "6", "CabanaSeis" });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 7", "03/05/2023", "8700", "Mauro Perez", "7", "CabanaSiete" });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 8", "04/05/2023", "8700", "Juan Perez", "8", "CabanaOcho" });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 9", "05/05/2023", "7800", "Mauro Perez", "9", "CabanaNueve" });
            migrationBuilder.InsertData("Mantenimientos", new[] { "Descripcion", "Fecha", "Costo", "Trabajador", "NumeroHabitacion", "CabanaNombre" }, new[] { "Mantenimiento para la habitacion 10", "06/05/2023", "80", "Juan Perez", "10", "CabanaDiez" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
