using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class SistemaCitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Slug = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Ciudad = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    PrecioMensual = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    Habitaciones = table.Column<int>(type: "INTEGER", nullable: false),
                    Banos = table.Column<int>(type: "INTEGER", nullable: false),
                    MetrosCuadrados = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: false),
                    Amenidades = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Disponible = table.Column<bool>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropiedadId = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreCliente = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    FechaHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notas = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotosPropiedad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropiedadId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Orden = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosPropiedad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosPropiedad_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Estado",
                table: "Citas",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_FechaHora",
                table: "Citas",
                column: "FechaHora");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PropiedadId",
                table: "Citas",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_FotosPropiedad_PropiedadId",
                table: "FotosPropiedad",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_Ciudad",
                table: "Propiedades",
                column: "Ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_Slug",
                table: "Propiedades",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "FotosPropiedad");

            migrationBuilder.DropTable(
                name: "Propiedades");
        }
    }
}
