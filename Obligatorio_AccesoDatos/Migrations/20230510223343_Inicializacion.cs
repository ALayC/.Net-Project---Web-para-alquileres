using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Inicializacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoCabanas",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoPorHuesped = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTipoCabana = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCabanas", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Cabanas",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    JacuzziPrivado = table.Column<bool>(type: "bit", nullable: false),
                    HabilitadaReservas = table.Column<bool>(type: "bit", nullable: false),
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false),
                    CapacidadMaxima = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCabanaNombre = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabanas", x => x.Nombre);
                    table.ForeignKey(
                        name: "FK_Cabanas_TipoCabanas_TipoCabanaNombre",
                        column: x => x.TipoCabanaNombre,
                        principalTable: "TipoCabanas",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Descripcion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Trabajador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false),
                    CabanaNombre = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Descripcion);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Cabanas_CabanaNombre",
                        column: x => x.CabanaNombre,
                        principalTable: "Cabanas",
                        principalColumn: "Nombre");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabanas_TipoCabanaNombre",
                table: "Cabanas",
                column: "TipoCabanaNombre");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_CabanaNombre",
                table: "Mantenimientos",
                column: "CabanaNombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cabanas");

            migrationBuilder.DropTable(
                name: "TipoCabanas");
        }
    }
}
