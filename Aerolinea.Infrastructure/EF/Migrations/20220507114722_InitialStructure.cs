using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aerolinea.Vuelos.Infrastructure.EF.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    horaSalida = table.Column<DateTime>(type: "DateTime", nullable: false),
                    horaLLegada = table.Column<DateTime>(type: "DateTime", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    precio = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    fecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    codDestino = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codOrigen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codAeronave = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    activo = table.Column<int>(type: "int", nullable: false),
                    stockAsientos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanillaAsientoVuelo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    asiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<int>(type: "int", nullable: false),
                    vueloId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanillaAsientoVuelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanillaAsientoVuelo_Vuelo_vueloId",
                        column: x => x.vueloId,
                        principalTable: "Vuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripulacionVuelo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codTripulacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    activo = table.Column<int>(type: "int", nullable: false),
                    vueloId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripulacionVuelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripulacionVuelo_Vuelo_vueloId",
                        column: x => x.vueloId,
                        principalTable: "Vuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanillaAsientoVuelo_vueloId",
                table: "PlanillaAsientoVuelo",
                column: "vueloId");

            migrationBuilder.CreateIndex(
                name: "IX_TripulacionVuelo_vueloId",
                table: "TripulacionVuelo",
                column: "vueloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanillaAsientoVuelo");

            migrationBuilder.DropTable(
                name: "TripulacionVuelo");

            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}
