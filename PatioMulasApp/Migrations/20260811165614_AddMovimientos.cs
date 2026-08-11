using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatioMulasApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UnidadId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConductorId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoMovimiento = table.Column<string>(type: "TEXT", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UbicacionExterna = table.Column<string>(type: "TEXT", nullable: false),
                    Observacion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");
        }
    }
}
