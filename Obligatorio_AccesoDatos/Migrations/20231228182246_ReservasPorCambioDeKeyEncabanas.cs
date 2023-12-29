using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ReservasPorCambioDeKeyEncabanas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabanas_TipoCabanas_TipoCabanaNombre",
                table: "Cabanas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Cabanas_CabanaNombre",
                table: "Mantenimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCabanas",
                table: "TipoCabanas");

            migrationBuilder.DropIndex(
                name: "IX_Mantenimientos_CabanaNombre",
                table: "Mantenimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabanas",
                table: "Cabanas");

            migrationBuilder.DropIndex(
                name: "IX_Cabanas_TipoCabanaNombre",
                table: "Cabanas");

            migrationBuilder.DropColumn(
                name: "CabanaNombre",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "TipoCabanaNombre",
                table: "Cabanas");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "TipoCabanas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "TipoCabanas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CabanaId",
                table: "Mantenimientos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CabanaId",
                table: "Cabanas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TipoCabanaId",
                table: "Cabanas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCabanas",
                table: "TipoCabanas",
                column: "IdTipoCabana");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabanas",
                table: "Cabanas",
                column: "CabanaId");

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CabanaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NumeroHuespedes = table.Column<int>(type: "int", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reservas_Cabanas_CabanaId",
                        column: x => x.CabanaId,
                        principalTable: "Cabanas",
                        principalColumn: "CabanaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_CabanaId",
                table: "Mantenimientos",
                column: "CabanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabanas_TipoCabanaId",
                table: "Cabanas",
                column: "TipoCabanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CabanaId",
                table: "Reservas",
                column: "CabanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reservas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabanas_TipoCabanas_TipoCabanaId",
                table: "Cabanas",
                column: "TipoCabanaId",
                principalTable: "TipoCabanas",
                principalColumn: "IdTipoCabana",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Cabanas_CabanaId",
                table: "Mantenimientos",
                column: "CabanaId",
                principalTable: "Cabanas",
                principalColumn: "CabanaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabanas_TipoCabanas_TipoCabanaId",
                table: "Cabanas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Cabanas_CabanaId",
                table: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCabanas",
                table: "TipoCabanas");

            migrationBuilder.DropIndex(
                name: "IX_Mantenimientos_CabanaId",
                table: "Mantenimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabanas",
                table: "Cabanas");

            migrationBuilder.DropIndex(
                name: "IX_Cabanas_TipoCabanaId",
                table: "Cabanas");

            migrationBuilder.DropColumn(
                name: "CabanaId",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "CabanaId",
                table: "Cabanas");

            migrationBuilder.DropColumn(
                name: "TipoCabanaId",
                table: "Cabanas");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "TipoCabanas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "TipoCabanas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "CabanaNombre",
                table: "Mantenimientos",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoCabanaNombre",
                table: "Cabanas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCabanas",
                table: "TipoCabanas",
                column: "Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabanas",
                table: "Cabanas",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_CabanaNombre",
                table: "Mantenimientos",
                column: "CabanaNombre");

            migrationBuilder.CreateIndex(
                name: "IX_Cabanas_TipoCabanaNombre",
                table: "Cabanas",
                column: "TipoCabanaNombre");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabanas_TipoCabanas_TipoCabanaNombre",
                table: "Cabanas",
                column: "TipoCabanaNombre",
                principalTable: "TipoCabanas",
                principalColumn: "Nombre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Cabanas_CabanaNombre",
                table: "Mantenimientos",
                column: "CabanaNombre",
                principalTable: "Cabanas",
                principalColumn: "Nombre");
        }
    }
}
